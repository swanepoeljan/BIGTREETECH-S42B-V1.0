using System;
using System.Collections.Generic;
using System.IO;

namespace TrueStepTerminal.Helper
{
	public class ThrouputStream : IDisposable
	{
		private readonly InputStreamClass inputStream;
		private readonly OutputStreamClass outputStream;

		private Queue<byte[]> queue = new Queue<byte[]>();
		private System.Threading.EventWaitHandle queueEvent = new System.Threading.EventWaitHandle(false, System.Threading.EventResetMode.AutoReset);

		public ThrouputStream()
		{
			inputStream = new InputStreamClass(this);
			outputStream = new OutputStreamClass(this);
		}

		public Stream InputStream
		{
			get { return inputStream; }
		}

		public Stream OutputStream
		{
			get { return outputStream; }
		}

		public void Dispose()
		{
			inputStream.Dispose();
			outputStream.Dispose();
		}

		private class InputStreamClass : Stream
		{
			private readonly Queue<byte[]> queue;
			private readonly ThrouputStream parent;
			private byte[] currentBlock = null;
			private int currentBlockPos = 0;
			private bool closed = false;
			private int readTimeoutMs = System.Threading.Timeout.Infinite;

			public InputStreamClass(ThrouputStream parent)
			{

				this.parent = parent;
				queue = parent.queue;
			}

			public override bool CanRead
			{
				get { return true; }
			}

			public override bool CanSeek
			{
				get { return false; }
			}

			public override bool CanWrite
			{
				get { return false; }
			}

			public override void Flush()
			{
				// Do nothing, always flushes.
			}

			public override long Length
			{
				get { throw new NotSupportedException(); }
			}

			public override long Position
			{
				get
				{
					throw new NotSupportedException();
				}
				set
				{
					throw new NotSupportedException();
				}
			}

			public override bool CanTimeout
			{
				get
				{
					return true;
				}
			}

			public override int ReadTimeout
			{
				get
				{
					return readTimeoutMs;
				}
				set
				{
					readTimeoutMs = value;
				}
			}

			public override int Read(byte[] buffer, int offset, int count)
			{
				if (currentBlock == null)
				{
					int queueCount;
					lock (queue)
					{
						queueCount = queue.Count;
						if (queueCount > 0)
							currentBlock = queue.Dequeue();
					}

					if (currentBlock == null && !parent.outputStream.IsClosed)
					{
						parent.queueEvent.WaitOne(readTimeoutMs);

						lock (queue)
						{
							if (queue.Count == 0)
								return 0;

							currentBlock = queue.Dequeue();
						}
					}

					currentBlockPos = 0;
				}

				if (currentBlock == null)
					return 0;

				int read = Math.Min(count, currentBlock.Length - currentBlockPos);
				Array.Copy(currentBlock, currentBlockPos, buffer, offset, read);
				currentBlockPos += read;
				if (currentBlockPos == currentBlock.Length)
				{
					// did read whole block
					currentBlockPos = 0;
					currentBlock = null;
				}

				return read;
			}

			public override long Seek(long offset, SeekOrigin origin)
			{
				throw new NotImplementedException();
			}

			public override void SetLength(long value)
			{
				throw new NotImplementedException();
			}

			public override void Write(byte[] buffer, int offset, int count)
			{
				throw new NotImplementedException();
			}

			public override void Close()
			{
				closed = true;
				base.Close();
			}
		}

		private class OutputStreamClass : Stream
		{
			private bool isClosed = false;

			private readonly Queue<byte[]> queue;
			private readonly ThrouputStream parent;

			public OutputStreamClass(ThrouputStream parent)
			{
				this.parent = parent;
				queue = parent.queue;
			}

			public override bool CanRead
			{
				get { return false; }
			}

			public override bool CanSeek
			{
				get { return false; }
			}

			public override bool CanWrite
			{
				get { return true; }
			}

			public override void Flush()
			{
				// always flush
			}

			public override long Length
			{
				get { throw new NotSupportedException(); }
			}

			public override long Position
			{
				get
				{
					throw new NotSupportedException();
				}
				set
				{
					throw new NotSupportedException();
				}
			}

			public override int Read(byte[] buffer, int offset, int count)
			{
				throw new NotSupportedException();
			}

			public override long Seek(long offset, SeekOrigin origin)
			{
				throw new NotSupportedException();
			}

			public override void SetLength(long value)
			{
				throw new NotSupportedException();
			}

			public override void Write(byte[] buffer, int offset, int count)
			{
				byte[] copy = new byte[count];
				Array.Copy(buffer, offset, copy, 0, count);
				lock (queue)
				{
					queue.Enqueue(copy);
					try
					{
						parent.queueEvent.Set();
					}
					catch (Exception)
					{ }
				}
			}

			public override void Close()
			{
				isClosed = true;
				base.Close();

				// Signal event, to stop waiting consumer
				try
				{
					parent.queueEvent.Set();
				}
				catch (Exception)
				{ }
			}

			public bool IsClosed
			{
				get { return isClosed; }
			}
		}

	}

}
