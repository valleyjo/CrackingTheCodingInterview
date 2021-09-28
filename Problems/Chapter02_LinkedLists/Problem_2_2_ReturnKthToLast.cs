namespace CrackingTheCodingInterview.Problems.Chapter2_LinkedLists
{
  using System;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public class Problem_2_2_ReturnKthToLast
  {
    /*
    count the list and then run through again stopping k from the end
    O(N) two loops

    once we are K from the begining, start the second runner. When first runner
    reaches end, return second runner.

    edge cases:
    list length < k
    null
    k = 0
    k = list length
    */
    public static int ExecuteZeroBased(AListNode<int> head, int k)
    {
      if (head == null || k < 0)
      {
        throw new ArgumentException($"{nameof(head)} is null or k value '{k}' is less than zero.");
      }

      AListNode<int> leader = head;
      for (int i = 0; i < k; i++)
      {
        if (leader == null)
        {
          throw new ArgumentException($"k value '{k}' is greater than length of list");
        }

        leader = leader.Next;
      }

      // set K at the begining of the list and continue
      // at the end of the list, kBehind will be k behind the end
      AListNode<int> kBehind = head;
      while (leader.Next != null)
      {
        leader = leader.Next;
        kBehind = kBehind.Next;
      }

      return kBehind.Data;
    }

    public static int ExecuteOneBased(AListNode<int> head, int k)
    {
      if (head == null || k < 1)
      {
        throw new ArgumentException($"'{nameof(head)}' is null or k value '{k}' is less than 1");
      }

      AListNode<int> leader = head;
      AListNode<int> kBehind = head;

      for (int i = 1; i <= k; i++)
      {
        if (leader == null)
        {
          throw new ArgumentException($"k value '{k}' is greater than length of list");
        }

        leader = leader.Next;
      }

      while (leader != null)
      {
        leader = leader.Next;
        kBehind = kBehind.Next;
      }

      return kBehind.Data;
    }
  }
}
