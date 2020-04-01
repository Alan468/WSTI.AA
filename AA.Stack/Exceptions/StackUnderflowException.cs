using System;

namespace AA.Stack.Exceptions
{
	public class StackUnderflowException : Exception
	{
		public StackUnderflowException() : base("Stack is empty")
		{
		}
	}
}
