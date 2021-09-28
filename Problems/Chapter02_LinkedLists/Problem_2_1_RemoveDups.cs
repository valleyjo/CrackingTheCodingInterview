namespace CrackingTheCodingInterview.Problems.Chapter02_LinkedLists
{
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_2_1_RemoveDups
  {
    /*
    1 -> 2 -> 3
         ^    ^
    */
    public static void ExecuteWithSpace(AListNode<int> head)
    {
      if (head == null)
      {
        return;
      }

      var hashSet = new HashSet<int>() { head.Data };
      AListNode<int> prev = head;
      AListNode<int> cur = prev.Next;

      while (cur != null)
      {
        if (hashSet.Contains(cur.Data))
        {
          prev.Next = cur.Next;
        }
        else
        {
          prev = cur;
        }

        hashSet.Add(cur.Data);
        cur = cur.Next;
      }
    }

    public static void ExecuteWithoutSpace(AListNode<int> head)
    {
      if (head == null)
      {
        return;
      }

      AListNode<int> primary = head;
      while (primary != null)
      {
        AListNode<int> prev = head;
        AListNode<int> cur = prev.Next;
        int value = primary.Data;

        while (cur != null)
        {
          if (cur.Data == value && cur != primary)
          {
            prev.Next = cur.Next;
          }
          else
          {
            prev = cur;
          }

          cur = cur.Next;
        }

        primary = primary.Next;
      }
    }
  }
}
