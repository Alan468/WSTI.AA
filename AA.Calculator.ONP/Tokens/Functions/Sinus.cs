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

        public override decimal Calculate(params decimal[] args)
        {
            return (decimal)Math.Sin((double)args[0]);
        }

    }
}
