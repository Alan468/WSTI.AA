using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class ArcSinus : FunctionBase
    {

        public ArcSinus(string value)
            : base(value)
        {
        }

        public override decimal Calculate(params decimal[] args)
        {
            return (decimal)Math.Asin((double)args[0]);
        }

    }
}
