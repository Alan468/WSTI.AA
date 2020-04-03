using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class Sqrt : FunctionBase
    {

        public Sqrt(string value)
            : base(value)
        {
        }

        public override decimal Calculate(params decimal[] args)
        {
            return (decimal)Math.Sqrt((double)args[0]);
        }

    }
}
