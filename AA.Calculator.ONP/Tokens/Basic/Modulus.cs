using AA.Calculator.ONP.BaseTokens;

namespace AA.Calculator.ONP.Tokens.Basic
{
	public class Modulus : OperatorBase
    {
        public override int Precedence
        {
            get
            {
                return 2;
            }
        }

        public Modulus(string value) : base(value)
        {
        }

        public override decimal Calculate(decimal left, decimal right)
        {
            return left % right;
        }
    }
}
