﻿using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class Sqrt : FunctionBase
    {

        public Sqrt(string value)
            : base(value)
        {
        }

        public override double Calculate(params double[] args)
        {
            return Math.Sqrt(args[0]);
        }

    }
}
