using ScottPlot;
using ScottPlot.Plottable;
using System.Drawing;

namespace TrueStepTerminal
{
	public class FormsPlotMouseXTrack : FormsPlot
	{

		
		public FormsPlotMouseXTrack()
		{
			base.MouseMove += FormsPlotMouseXTrack_MouseMove;
			HorisontalLine = base.Plot.AddHorizontalLine(0, Color.Red, 1, LineStyle.Dash);
		}

		public HLine HorisontalLine { get; private set; }

		private void FormsPlotMouseXTrack_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			var form = sender as FormsPlot;
			(double coordinateX, double coordinateY) = form.GetMouseCoordinates();

			HorisontalLine.Y = coordinateY;

			form.Render(false, true);
		}
	}
}
