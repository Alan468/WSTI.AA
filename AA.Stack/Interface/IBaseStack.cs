namespace AA.Stack.Interfaces
{
	public interface IBaseStack<Type>
	{		
		public bool Push(Type item);

		public Type Pop();

		public Type Peek();

		public bool Empty();

		public int Size();

		public void Clear();
	}
}
