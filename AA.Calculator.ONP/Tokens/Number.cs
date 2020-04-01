using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens
{
	public class Number : NumberBase
	{

		public override double Value
		{
			get
			{
				if (Entry.IndexOf("0x", StringComparison.InvariantCultureIgnoreCase) == 0)
					return (double)Convert.ToInt32(Entry, 16);
				else
					return double.Parse(Entry);
			}
		}

		public Number(double value)
			: this(value.ToString())
		{
		}

		public Number(string value)
			: base(value)
		{
		}

	}
}
