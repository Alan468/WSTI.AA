namespace AA.Calculator.ONP.BaseTokens
{
	public abstract class NumberBase : Token
    {

        public abstract decimal Value
        {
            get;
        }

        public NumberBase(string value)
            : base(value)
        {
        }

    }
}
