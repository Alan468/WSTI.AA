using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens
{
	public class Number : NumberBase
	{

		public override decimal Value
		{
			get
			{
				if (Entry.IndexOf("0x", StringComparison.InvariantCultureIgnoreCase) == 0)
					return (decimal)Convert.ToInt32(Entry, 16);
				else
					return decimal.Parse(Entry);
			}
		}

		public Number(decimal value)
			: this(value.ToString())
		{
		}

		public Number(string value)
			: base(value)
		{
		}

	}
}
