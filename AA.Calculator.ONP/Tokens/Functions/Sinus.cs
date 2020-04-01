using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class Sinus : FunctionBase
    {

        public Sinus(string value)
            : base(value)
        {
        }

        public override double Calculate(params double[] args)
        {
            return Math.Sin(args[0]);
        }

    }
}
