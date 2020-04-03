using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class Ceiling : FunctionBase
    {

        public Ceiling(string value)
            : base(value)
        {
        }

        public override decimal Calculate(params decimal[] args)
        {
            return Math.Ceiling(args[0]);
        }

    }
}
