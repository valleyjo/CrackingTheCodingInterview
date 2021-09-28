namespace CrackingTheCodingInterview.Problems.Chapter02_LinkedLists
{
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_2_4_Partition
  {
    /*
    Create two new lists: one < partition, two >= partition
    go through the input list and copy the data to the right list.
    append both lists for the return value.
    O(N) time -> best possible
    O(n) space -> can it be done in place?
    maintain pointers for "lower" half and "upper half"
    Pointers can be at the start and the end.
    for each node:
      remove it from the list
      append it to the begining or end
    return the start of the list
     */
    public static AListNode<int> Execute(AListNode<int> node, int partition)
    {
      if (node == null)
      {
        return null;
      }

      var lowerHalf = new List<int>();
      var upperHalf = new List<int>();
      AListNode<int> cur = node;
      while (cur != null)
      {
        if (cur.Data < partition)
        {
          lowerHalf.Add(cur.Data);
        }
        else
        {
          upperHalf.Add(cur.Data);
        }

        cur = cur.Next;
      }

      BuildList(lowerHalf, out AListNode<int> lowerHalfHead, out AListNode<int> lowerHalfTail);
      BuildList(upperHalf, out AListNode<int> upperHalfHead, out _);

      lowerHalfTail.Next = upperHalfHead;
      return lowerHalfHead;
    }

    private static void BuildList(List<int> lowerHalf, out AListNode<int> head, out AListNode<int> tail)
    {
      // create a dummy node to maintain the head
      tail = new AListNode<int>();
      head = tail;
      foreach (int val in lowerHalf)
      {
        var next = new AListNode<int>(val);
        tail.Next = next;
        tail = next;
      }

      // head was a dummy node so remove it from the from of the list now
      head = head.Next;
    }
  }
}
