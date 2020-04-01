namespace AA.Stack.Models
{
	public class Element<TNode>
	{

		public Element<TNode> next { get; set; }
		public TNode item { get; set; }

		public Element(Element<TNode> next, TNode item)
		{
			this.next = next;
			this.item = item;
		}
	}
}
