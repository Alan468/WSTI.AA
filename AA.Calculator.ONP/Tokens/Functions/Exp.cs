using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class Exp : FunctionBase
    {

        public Exp(string value)
            : base(value)
        {
        }

        public override double Calculate(params double[] args)
        {
            return Math.Exp(args[0]);
        }

    }
}
