using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class Cosinus : FunctionBase
    {

        public Cosinus(string value)
            : base(value)
        {
        }

        public override double Calculate(params double[] args)
        {
            return Math.Cos(args[0]);
        }

    }
}
