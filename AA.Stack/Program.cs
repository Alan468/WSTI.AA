using AA.Stack.Models;
using System;
using System.Collections.Generic;

namespace AA.Stack
{
	class Program
	{
		private static List<int> TestLengths = new List<int>() { 10000, 100000, 1000000, 10000000 };

		private static void Main()
		{
			Console.WriteLine($"\t     Stos   \t  Ilość  \t Czas [ms]");

			TestLengths.ForEach(quantity => { ArrayStackTest(quantity); });
			TestLengths.ForEach(quantity => { StackTest(quantity); });
			TestLengths.ForEach(quantity => { ListStackTest(quantity); });
		}

		public static void ArrayStackTest(int quantity)
		{
			var stack = new ArrayStack<int>(quantity);

			var start = DateTime.Now;
			for (var i = 0; i < quantity; i++)
			{
				stack.Push(i);
			}
			for (var i = 0; i < quantity; i++)
			{
				stack.Pop();
			}
			var duration = DateTime.Now.Ticks - start.Ticks;

			Console.WriteLine($"\t ArrayStack \t {quantity}  \t {duration / 10000}ms");
		}

		public static void ListStackTest(int quantity)
		{
			var stack = new ListStack<int>();

			var start = DateTime.Now;
			for (var i = 0; i < quantity; i++)
			{
				stack.Push(i);
			}
			for (var i = 0; i < quantity; i++)
			{
				stack.Pop();
			}
			var duration = DateTime.Now.Ticks - start.Ticks;

			Console.WriteLine($"\t  ListStack  \t {quantity}  \t {duration / 10000}ms");
		}

		public static void StackTest(int quantity)
		{
			var stack = new Stack<int>();

			var start = DateTime.Now;
			for (var i = 0; i < quantity; i++)
			{
				stack.Push(i);
			}
			for (var i = 0; i < quantity; i++)
			{
				stack.Pop();
			}
			var duration = DateTime.Now.Ticks - start.Ticks;

			Console.WriteLine($"\t   C# Stack  \t {quantity}   \t {duration / 10000}ms");
		}
	}
}
