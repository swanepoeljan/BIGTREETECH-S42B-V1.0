using System;
using System.Collections.Generic;
using System.Linq;

namespace TrueStepTerminal
{
	public class PidAutotuneCalc
	{
		public Dictionary<TimeSpan, float> AngleError { get; }

		public Dictionary<TimeSpan, float> Angle { get; }

		public readonly double[] AngleDouble;
		public readonly double[] AngleErrorDouble;

		public PidAutotuneCalc(int pointsCount)
		{
			AngleDouble = new double[pointsCount];
			AngleErrorDouble = new double[pointsCount];

			AngleError = new Dictionary<TimeSpan, float>();
			Angle = new Dictionary<TimeSpan, float>();

			StartTime = DateTime.Now;
		}

		public TimeSpan AddAngleError(float angleError)
		{
			var span = DateTime.Now - StartTime;
			if (!AngleError.ContainsKey(span))
			{
				AngleError.Add(span, angleError);

				Array.Copy(AngleErrorDouble, 1, AngleErrorDouble, 0, AngleErrorDouble.Length - 1);
				AngleErrorDouble[AngleErrorDouble.Length - 1] = angleError;
			}
			return span;
		}

		public TimeSpan AddAngle(float angle)
		{
			var span = DateTime.Now - StartTime;
			if (!Angle.ContainsKey(span))
			{
				Angle.Add(span, angle);

				const int MAX_ANGLE = 16384;
				var correctAngle = (angle - MAX_ANGLE / 2) * 5 / MAX_ANGLE;
				Array.Copy(AngleDouble, 1, AngleDouble, 0, AngleDouble.Length - 1);
				AngleDouble[AngleDouble.Length - 1] = correctAngle;
			}
			return span;
		}

		public float GetAvgAngleError { get { return AngleError.Values.Select(i => Math.Abs(i)).ToArray().Average(); } }

		public float GetMaxAngleError { get { return AngleError.Values.Select(i => Math.Abs(i)).ToArray().Max(); } }

		public DateTime StartTime { get; private set; }

		public void Clear()
		{
			StartTime = DateTime.Now;
			Array.Clear(AngleDouble, 0, AngleDouble.Length);
			Array.Clear(AngleErrorDouble, 0, AngleErrorDouble.Length);
			AngleError.Clear();
			Angle.Clear();
		}
	}
}
