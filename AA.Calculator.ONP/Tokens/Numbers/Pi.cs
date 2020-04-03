using AA.Calculator.ONP.BaseTokens;
using System;

namespace AA.Calculator.ONP.Tokens.Numbers
{
    public class Pi : NumberBase
    {

        public Pi(string value)
            : base(value)
        {
        }

        public override decimal Value => (decimal)Math.PI;
        
    }
}
