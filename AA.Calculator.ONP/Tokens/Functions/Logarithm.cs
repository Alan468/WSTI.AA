using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class Logarithm : FunctionBase
    {

        public Logarithm(string value)
            : base(value)
        {
        }

        public override double Calculate(params double[] args)
        {
            return Math.Log(args[0]);
        }

    }
}
