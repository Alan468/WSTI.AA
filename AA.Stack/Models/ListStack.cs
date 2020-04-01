using AA.Stack.Exceptions;
using AA.Stack.Interfaces;

namespace AA.Stack.Models
{
	public class ListStack<Type> : IBaseStack<Type>
	{
		private Element<Type> top;
		private int size;

		public ListStack()
		{
			this.size = 0;
		}

		public bool Push(Type item)
		{
			top = new Element<Type>(top, item);
			size++;
			return true;
		}

		public Type Pop()
		{
			if (Empty())
			{
				throw new StackUnderflowException();
			}
			var item = top.item;
			top = top.next;
			size--;
			return item;
		}

		public Type Peek()
		{
			if (Empty())
			{
				throw new StackUnderflowException();
			}
			return top.item;
		}

		public bool Empty()
		{
			return top == null;
		}

		public int Size()
		{
			return size;
		}

		public void Clear()
		{
			top = null;
			size = 0;
		}
	}
}
