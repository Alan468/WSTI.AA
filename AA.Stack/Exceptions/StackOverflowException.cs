using System;

namespace AA.Stack.Exceptions
{
	public class StackOverflowException : Exception
	{
		public StackOverflowException() : base("Stack is full")
		{

		}
	}
}
