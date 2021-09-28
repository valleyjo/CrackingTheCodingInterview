namespace CrackingTheCodingInterview.Problems.Chapter02_LinkedLists
{
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;

  /*
  palindrome = same fwd and backward
  challenge here is that we don't have direct access to the end
  copy to external ds
  O(n) memory
  O(n) time

  anything recursive is O(N) anyway and possibly more difficult to implement
  could do it with a stack too but that is almost the same thing as using a list
  */
  public static class Problem_2_6_Palindrome
  {
    public static bool Execute(AListNode<int> head)
    {
      if (head == null || head.Next == null)
      {
        return false;
      }

      // O(n) time and space
      var data = new List<int>();
      AListNode<int> cur = head;
      while (cur != null)
      {
        data.Add(cur.Data);
        cur = cur.Next;
      }

      // O(n) time
      for (int start = 0, end = data.Count - 1; start < end; start++, end--)
      {
        if (data[start] != data[end])
        {
          return false;
        }
      }

      return true;
    }
  }
}
