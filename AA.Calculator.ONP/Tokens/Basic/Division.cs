using AA.Calculator.ONP.BaseTokens;

namespace AA.Calculator.ONP.Tokens.Basic
{
	public class Division : OperatorBase
    {
        public override int Precedence
        {
            get
            {
                return 2;
            }
        }


        public Division(string value) : base(value)
        {
        }

        public override decimal Calculate(decimal left, decimal right)
        {
            return left / right;
        }
    }
}
