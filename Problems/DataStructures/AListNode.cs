namespace CrackingTheCodingInterview.Problems.DataStructures
{
    using System.Text;

    public class AListNode<T>
    {
        public T Data { get; set; }

        public AListNode<T> Next { get; set; }

        public static AListNode<T> FromArray(T[] array)
        {
            var head = new AListNode<T>();
            AListNode<T> cur = head;

            foreach (T element in array)
            {
                var newNode = new AListNode<T>();
                newNode.Data = element;
                cur.Next = newNode;
                cur = newNode;
            }

            return head.Next;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            AListNode<T> node = this;
            while (node.Next != null)
            {
                sb.Append($"({node.Data}) -> ");
                node = node.Next;
            }

            sb.Append($"({node.Data})");

            return sb.ToString();
        }
    }
}
