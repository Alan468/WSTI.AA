using AA.Calculator.ONP.Enums;

namespace AA.Calculator.ONP.BaseTokens
{
	public abstract class OperatorBase : Token
    {

        public virtual int Precedence
        {
            get
            {
                return 1;
            }
        }

        public virtual Associativity Associativity
        {
            get
            {
                return Associativity.Left;
            }
        }

        public OperatorBase(string value)
            : base(value)
        {
        }

        public abstract decimal Calculate(decimal left, decimal right);

    }
}
