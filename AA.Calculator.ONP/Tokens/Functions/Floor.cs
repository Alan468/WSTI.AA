using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class Floor : FunctionBase
    {

        public Floor(string value)
            : base(value)
        {
        }

        public override decimal Calculate(params decimal[] args)
        {
            return Math.Floor(args[0]);
        }

    }
}
