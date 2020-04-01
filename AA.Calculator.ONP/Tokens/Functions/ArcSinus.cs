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

        public override double Calculate(params double[] args)
        {
            return Math.Asin(args[0]);
        }

    }
}
