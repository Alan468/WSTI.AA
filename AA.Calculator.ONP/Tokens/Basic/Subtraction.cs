using AA.Calculator.ONP.BaseTokens;

namespace AA.Calculator.ONP.Tokens.Basic
{
	public class Subtraction : OperatorBase
    {

        public Subtraction(string value) : base(value)
        {
        }

        public override double Calculate(double left, double right)
        {
            return left - right;
        }
    }
}
