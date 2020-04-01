using AA.Stack.Exceptions;
using AA.Stack.Interfaces;

namespace AA.Stack.Models
{
	public class ArrayStack<Type> : IBaseStack<Type>
	{
        private const int DEFAULT_SIZE = 10;

        private int top;
        private int size;
        private object[] items;

        public ArrayStack()
        {
            this.top = -1;
            this.size = DEFAULT_SIZE;
            this.items = new object[DEFAULT_SIZE];
        }

        public ArrayStack(int size)
        {
            if (size < 1)
            {
                throw new IllegalArgumentException();
            }
            this.top = -1;
            this.size = size;
            this.items = new object[size];
        }

        public bool Push(Type item)
        {
            if ((top + 1) >= size)
            {
                throw new StackOverflowException();
            }
            items[++top] = item;
            return true;
        }

        public Type Pop()
        {
            if (Empty())
            {
                throw new StackUnderflowException();
            }
            return (Type)items[top--];
        }

        public Type Peek()
        {
            if (Empty())
            {
                throw new StackUnderflowException();
            }
            return (Type)items[top];
        }

        public bool Empty()
        {
            return top <= -1;
        }

        public int Size()
        {
            return top + 1;
        }

        public void Clear()
        {
            top = -1;
            items = new object[size];
        }
    }
}
