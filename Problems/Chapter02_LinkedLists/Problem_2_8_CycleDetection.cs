namespace CrackingTheCodingInterview.Problems.Chapter2_LinkedLists
{
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_2_8_CycleDetection
  {
    public static AListNode<int> Execute(AListNode<int> head)
    {
      AListNode<int> slow = head;
      AListNode<int> fast = head;
      do
      {
        if (fast == null || fast.Next == null)
        {
          return null;
        }

        slow = slow.Next;
        fast = fast.Next.Next;
      }
      while (slow != fast);

      // slow and fast are pointing to the intersection
      // the intersection and the head of the list are K away from
      // the start of the loop. Advance both together until they meet
      // to identify the start of the loop
      while (head != slow)
      {
        head = head.Next;
        slow = slow.Next;
      }

      return head;
    }
  }
}
