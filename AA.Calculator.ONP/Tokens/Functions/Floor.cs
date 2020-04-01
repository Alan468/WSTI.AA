﻿using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Functions
{
	public class Floor : FunctionBase
    {

        public Floor(string value)
            : base(value)
        {
        }

        public override double Calculate(params double[] args)
        {
            return Math.Floor(args[0]);
        }

    }
}