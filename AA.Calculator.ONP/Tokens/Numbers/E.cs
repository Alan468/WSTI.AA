using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Numbers
{
    public class E : NumberBase
    {

        public E(string value)
            : base(value)
        {
        }

        public override decimal Value => (decimal)Math.E;

    }
}
