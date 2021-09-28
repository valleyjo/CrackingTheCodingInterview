namespace CrackingTheCodingInterview.Problems.Chapter2_LinkedLists
{
  using System;
  using System.Collections.Generic;
  using System.Threading;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_2_7_Intersection
  {
    /*

    store all the references for one list in memory.
    check against those for the second list
    O(N) space
    O(N) time

    save space by checking each node in one against each node in two
    O(1) space
    O(NM) time

    Save values to stacks, get to end, pop off until different.O(N) space O(N) time

    intersecting lists will point to the same node at some point
    test cases:
    list one ends first
    list two ends first
    same length no intersection
    intersection
    */
    public static AListNode<int> Execute(AListNode<int> one, AListNode<int> two)
    {
      if (one == null || two == null)
      {
        return null;
      }

      var oneReferences = new HashSet<AListNode<int>>();
      AListNode<int> head = one;
      while (head != null)
      {
        oneReferences.Add(head);
        head = head.Next;
      }

      head = two;
      while (head != null)
      {
        if (oneReferences.Contains(head))
        {
          return head;
        }

        head = head.Next;
      }

      return null;
    }

    public static AListNode<int> ExecuteSaveSpace(AListNode<int> one, AListNode<int> two)
    {
      if (one == null || two == null)
      {
        return null;
      }

      FindLengthAndTail(one, out int oneLength, out AListNode<int> oneTail);
      FindLengthAndTail(two, out int twoLength, out AListNode<int> twoTail);

      if (oneTail != twoTail)
      {
        return null;
      }

      AListNode<int> longerList;
      AListNode<int> shorterList;
      if (oneLength > twoLength)
      {
        longerList = one;
        shorterList = two;
      }
      else
      {
        longerList = two;
        shorterList = one;
      }

      for (int i = 0; i < Math.Abs(oneLength - twoLength); i++)
      {
        longerList = longerList.Next;
      }

      // we know the lists intersect so no need to worry about null refs or
      // a case where list nodes are never equal
      while (longerList != shorterList)
      {
        longerList = longerList.Next;
        shorterList = shorterList.Next;
      }

      return longerList;
    }

    private static void FindLengthAndTail(AListNode<int> head, out int length, out AListNode<int> tail)
    {
      length = 0;
      tail = head;

      while (head != null)
      {
        tail = head;
        head = head.Next;
        length++;
      }
    }
  }
}
