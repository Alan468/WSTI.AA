using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class ArcTangent : FunctionBase
    {

        public ArcTangent(string value)
            : base(value)
        {
        }

        public override decimal Calculate(params decimal[] args)
        {
            return (decimal)Math.Atan((double)args[0]);
        }

    }
}
