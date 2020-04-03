using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class Round : FunctionBase
    {

        public Round(string value)
            : base(value)
        {
        }

        public override decimal Calculate(params decimal[] args)
        {
            return Math.Round(args[0]);
        }

    }
}
