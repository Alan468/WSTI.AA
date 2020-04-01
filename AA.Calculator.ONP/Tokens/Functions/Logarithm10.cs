using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class Logarithm10 : FunctionBase
    {

        public Logarithm10(string value)
            : base(value)
        {
        }

        public override double Calculate(params double[] args)
        {
            return Math.Log10(args[0]);
        }

    }
}
