using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrueStepTerminal.Helper
{
	public static class ThreadHelperClass
	{
		delegate void SetTextCallback(Form f, Control ctrl, string text);
		/// <summary>
		/// Set text property of various controls
		/// </summary>
		/// <param name="form">The calling form</param>
		/// <param name="ctrl"></param>
		/// <param name="text"></param>
		public static void SetText(Form form, Control ctrl, string text)
		{
			// InvokeRequired required compares the thread ID of the 
			// calling thread to the thread ID of the creating thread. 
			// If these threads are different, it returns true. 
			if (ctrl.InvokeRequired)
			{
				SetTextCallback d = new SetTextCallback(SetText);
				form.Invoke(d, new object[] { form, ctrl, text });
			}
			else
			{
				ctrl.Text = text;
			}
		}

		delegate void SetValueCallback(Form f, NumericUpDown ctrl, decimal value);
		/// <summary>
		/// Set text property of various controls
		/// </summary>
		/// <param name="form">The calling form</param>
		/// <param name="ctrl">NumericUpDown</param>
		/// <param name="value"></param>
		public static void SetNumericUpDownValue(Form form, NumericUpDown ctrl, decimal value)
		{
			if (ctrl.InvokeRequired)
			{
				SetValueCallback d = new SetValueCallback(SetNumericUpDownValue);
				form.Invoke(d, new object[] { form, ctrl, value });
			}
			else
			{
				ctrl.Value = value;
			}
		}

		delegate void SetEnableCallback(Form f, Control ctrl, bool state);
		/// <summary>
		/// Set text property of various controls
		/// </summary>
		/// <param name="form">The calling form</param>
		/// <param name="ctrl"></param>
		/// <param name="state"></param>
		public static void SetEnable(Form form, Control ctrl, bool state)
		{
			if (ctrl.InvokeRequired)
			{
				var d = new SetEnableCallback(SetEnable);
				form.Invoke(d, new object[] { form, ctrl, state });
			}
			else
			{
				ctrl.Enabled = state;
			}
		}



		public static async Task WaitForExitAsync1(this Process process, CancellationToken cancellationToken = default)
		{
			var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

			void Process_Exited(object sender, EventArgs e)
			{
				tcs.TrySetResult(true);
			}

			process.EnableRaisingEvents = true;
			process.Exited += Process_Exited;

			try
			{
				if (process.HasExited)
				{
					return;
				}

				using (cancellationToken.Register(() => tcs.TrySetCanceled()))
				{
					await tcs.Task.ConfigureAwait(false);
				}
			}
			finally
			{
				process.Exited -= Process_Exited;
			}
		}


		public static async Task<int> StartProcess(
			string filename,
			string arguments,
			string workingDirectory = null,
			int? timeout = null,
			TextWriter outputTextWriter = null,
			TextWriter errorTextWriter = null)
		{
			using (var process = new Process()
			{
				StartInfo = new ProcessStartInfo()
				{
					CreateNoWindow = true,
					Arguments = arguments,
					FileName = filename,
					RedirectStandardOutput = outputTextWriter != null,
					RedirectStandardError = errorTextWriter != null,
					UseShellExecute = false,
					WorkingDirectory = workingDirectory
				}
			})
			{
				var cancellationTokenSource = timeout.HasValue ?
					new CancellationTokenSource(timeout.Value) :
					new CancellationTokenSource();

				process.Start();

				var tasks = new List<Task>(3) { process.WaitForExitAsync(cancellationTokenSource.Token) };
				if (outputTextWriter != null)
				{
					tasks.Add(ReadAsync(
						x =>
						{
							process.OutputDataReceived += x;
							process.BeginOutputReadLine();
						},
						x => process.OutputDataReceived -= x,
						outputTextWriter,
						cancellationTokenSource.Token));
				}

				if (errorTextWriter != null)
				{
					tasks.Add(ReadAsync(
						x =>
						{
							process.ErrorDataReceived += x;
							process.BeginErrorReadLine();
						},
						x => process.ErrorDataReceived -= x,
						errorTextWriter,
						cancellationTokenSource.Token));
				}

				await Task.WhenAll(tasks);
				return process.ExitCode;
			}
		}

		/// <summary>
		/// Waits asynchronously for the process to exit.
		/// </summary>
		/// <param name="process">The process to wait for cancellation.</param>
		/// <param name="cancellationToken">A cancellation token. If invoked, the task will return
		/// immediately as cancelled.</param>
		/// <returns>A Task representing waiting for the process to end.</returns>
		public static Task WaitForExitAsync(
			this Process process,
			CancellationToken cancellationToken = default)
		{
			process.EnableRaisingEvents = true;

			var taskCompletionSource = new TaskCompletionSource<object>();

			void handler(object sender, EventArgs args)
			{
				process.Exited -= handler;
				taskCompletionSource.TrySetResult(null);
			}

			process.Exited += handler;

			if (cancellationToken != default)
			{
				cancellationToken.Register(
					() =>
					{
						process.Exited -= handler;
						taskCompletionSource.TrySetCanceled();
					});
			}

			return taskCompletionSource.Task;
		}

		/// <summary>
		/// Reads the data from the specified data recieved event and writes it to the
		/// <paramref name="textWriter"/>.
		/// </summary>
		/// <param name="addHandler">Adds the event handler.</param>
		/// <param name="removeHandler">Removes the event handler.</param>
		/// <param name="textWriter">The text writer.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public static Task ReadAsync(
			this Action<DataReceivedEventHandler> addHandler,
			Action<DataReceivedEventHandler> removeHandler,
			TextWriter textWriter,
			CancellationToken cancellationToken = default)
		{
			var taskCompletionSource = new TaskCompletionSource<object>();

			DataReceivedEventHandler handler = null;
			handler = new DataReceivedEventHandler(
				(sender, e) =>
				{
					lock (sender)
					{
						if (e.Data == null)
						{
							removeHandler(handler);
							taskCompletionSource.TrySetResult(null);
						}
						else
						{
							textWriter.WriteLine(e.Data);
							textWriter.Flush();
						}
					}
				});

			addHandler(handler);

			if (cancellationToken != default)
			{
				cancellationToken.Register(
					() =>
					{
						removeHandler(handler);
						taskCompletionSource.TrySetCanceled();
					});
			}

			return taskCompletionSource.Task;
		}

	}
}
