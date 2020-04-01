using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class ArcCosinus : FunctionBase
    {

        public ArcCosinus(string value)
            : base(value)
        {
        }

        public override double Calculate(params double[] args)
        {
            return Math.Acos(args[0]);
        }

    }
}
