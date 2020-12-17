namespace CrackingTheCodingInterview.Problems.DataStructures
{
  using System.Text;

  /// <summary>
  /// Basic linked list node. Contains Data and Next members. Prefixed with "A"
  /// because Alex wrote this class.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class AListNode<T>
  {
    public AListNode()
      : this(default)
    {
    }

    public AListNode(T data)
      : this(data, null)
    {
    }

    public AListNode(T data, AListNode<T> next)
    {
      this.Data = data;
      this.Next = next;
    }

    public T Data { get; set; }

    public AListNode<T> Next { get; set; }

    public static AListNode<T> FromArray(T[] array)
    {
      var head = new AListNode<T>();
      AListNode<T> cur = head;

      foreach (T element in array)
      {
        var newNode = new AListNode<T>(element);
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
