using System;

namespace AA.Stack.Exceptions
{
	public class IllegalArgumentException : Exception
	{
		public IllegalArgumentException() : base("Invalid size")
		{

		}
	}
}
