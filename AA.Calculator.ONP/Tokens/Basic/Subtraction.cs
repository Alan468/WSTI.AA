using AA.Calculator.ONP.BaseTokens;

namespace AA.Calculator.ONP.Tokens.Basic
{
	public class Subtraction : OperatorBase
    {

        public Subtraction(string value) : base(value)
        {
        }

        public override decimal Calculate(decimal left, decimal right)
        {
            return left - right;
        }
    }
}
