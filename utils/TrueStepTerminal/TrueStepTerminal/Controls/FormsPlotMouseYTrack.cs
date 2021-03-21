using ScottPlot;
using ScottPlot.Plottable;
using System.Drawing;

namespace TrueStepTerminal.Controls
{
	public class FormsPlotMouseYTrack : FormsPlot
	{
		public FormsPlotMouseYTrack()
		{
			MouseMove += FormsPlotMouseXTrack_MouseMove;
			MouseHorisontalLine = Plot.AddHorizontalLine(0, Color.Green, 1, LineStyle.Dash);

			ZeroHorisontalLine = Plot.AddHorizontalLine(0, Color.Gray, 1, LineStyle.DashDot);

			YMaxWarningHorisontalLine = Plot.AddHorizontalLine(0, Color.Orange, 1, LineStyle.DashDot);
			YMinWarningHorisontalLine = Plot.AddHorizontalLine(0, Color.Orange, 1, LineStyle.DashDot);
		}

		public HLine MouseHorisontalLine { get; private set; }

		public HLine ZeroHorisontalLine { get; private set; }

		private HLine YMaxWarningHorisontalLine { get; }

		private HLine YMinWarningHorisontalLine { get; }

		public double YWarningLine
		{
			get { return YMaxWarningHorisontalLine.Y; }
			set
			{
				YMaxWarningHorisontalLine.Y = value;
				YMinWarningHorisontalLine.Y = -value;
				YMaxWarningHorisontalLine.IsVisible = YMinWarningHorisontalLine.IsVisible = value != 0;
			}
		}

		private void FormsPlotMouseXTrack_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			var form = sender as FormsPlot;
			(_, double coordinateY) = form.GetMouseCoordinates();

			MouseHorisontalLine.Y = coordinateY;

			form.Render(false, true);
		}
	}
}
