using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class Tangent : FunctionBase
    {

        public Tangent(string value)
            : base(value)
        {
        }

        public override decimal Calculate(params decimal[] args)
        {
            return (decimal)Math.Tan((double)args[0]);
        }

    }
}
