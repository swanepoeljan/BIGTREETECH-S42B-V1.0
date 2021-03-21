using System.ComponentModel;

namespace TrueStepTerminal
{
	public class Parameters
	{
		public class ParameterItem
		{
			private string paramName;

			public string Name => paramName;

			[Browsable(false)]
			public string ValueStr { get; set; }
			public double Value
			{
				get
				{
					double.TryParse(ValueStr, out double result);
					return result;
				}
				set { ValueStr = value.ToString(); }
			}

			public ParameterItem(string name, double value)
			{
				paramName = name;
				ValueStr = value.ToString();
			}

			public ParameterItem(string name, string value)
			{
				paramName = name;
				ValueStr = value;
			}
		}

		public BindingList<ParameterItem> Items = new BindingList<ParameterItem>();
	}
}
