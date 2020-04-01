﻿using AA.Calculator.ONP.BaseTokens;

namespace AA.Calculator.ONP.Tokens.Basic
{
	public class Multiplication : OperatorBase
    {

        public override int Precedence
        {
            get
            {
                return 2;
            }
        }

        public Multiplication(string value) : base(value)
        {
        }

        public override double Calculate(double left, double right)
        {
            return left * right;
        }
    }
}
