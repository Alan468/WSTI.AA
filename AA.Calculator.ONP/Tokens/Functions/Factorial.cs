using AA.Calculator.ONP.BaseTokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class Factorial : FunctionBase
    {

        public Factorial(string value)
            : base(value)
        {
        }

        public override decimal Calculate(params decimal[] args)
        {
            var number = args[0];
            decimal result = 1;
            while (number != 1)
            {
                result *= number;
                number -= 1;
            }
            return result;
        }

    }
}
