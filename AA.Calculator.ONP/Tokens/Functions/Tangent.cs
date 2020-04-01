using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class Tangent : FunctionBase
    {

        public Tangent(string value)
            : base(value)
        {
        }

        public override double Calculate(params double[] args)
        {
            return Math.Tan(args[0]);
        }

    }
}
