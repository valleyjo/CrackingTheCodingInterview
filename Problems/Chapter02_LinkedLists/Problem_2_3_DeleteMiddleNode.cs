namespace CrackingTheCodingInterview.Problems.Chapter02_LinkedLists
{
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_2_3_DeleteMiddleNode
  {
    /*
    Remove "middle" node w/ only access to this node.
    end nodes or null nodes just return

    1: Copy data
    copy data of next node to this node.
    remove the next node from the list
    O(1)

    2: Remove reference
    can we set the reference of (this) to (this).Next?
    I don't think this is possible
    */
    public static void Execute(AListNode<int> node)
    {
      if (node == null || node.Next == null)
      {
        return;
      }

      // copy the data from the next node
      // skip the next node to remove it
      node.Data = node.Next.Data;
      node.Next = node.Next.Next;
    }
  }
}
