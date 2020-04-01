namespace AA.Calculator.ONP.BaseTokens
{
	public abstract class FunctionBase : Token
    {

        public virtual int OperandsCount
        {
            get
            {
                return 1;
            }
        }

        public FunctionBase(string value)
            : base(value)
        {
        }

        public abstract double Calculate(params double[] args);

    }
}
