using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class ABS : FunctionBase
    {

        public ABS(string value)
            : base(value)
        {
        }

        public override decimal Calculate(params decimal[] args)
        {
            return Math.Abs(args[0]);
        }

    }
}
