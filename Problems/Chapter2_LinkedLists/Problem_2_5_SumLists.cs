namespace CrackingTheCodingInterview.Problems.Chapter2_LinkedLists
{
  using System;
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_2_5_SumLists
  {
    public static AListNode<int> SumForward(AListNode<int> one, AListNode<int> two)
    {
      ThrowIfNull(one, two);

      BuildStack(one, out Stack<int> oneStack);
      BuildStack(two, out Stack<int> twoStack);

      var head = new AListNode<int>();
      AListNode<int> cur = head;
      int carry = 0;
      while (oneStack.Count > 0 || twoStack.Count > 0 || carry > 0)
      {
        int result;
        if (oneStack.Count > 0 && twoStack.Count > 0)
        {
          result = oneStack.Pop() + twoStack.Pop() + carry;
        }
        else if (oneStack.Count > 0)
        {
          result = oneStack.Pop() + carry;
        }
        else if (twoStack.Count > 0)
        {
          result = twoStack.Pop() + carry;
        }
        else
        {
          result = carry;
        }

        carry = result / 10;
        var next = new AListNode<int>(result % 10);
        cur.Next = next;
        cur = next;
      }

      BuildStack(head.Next, out Stack<int> resultStack);
      AListNode<int> resultHead = new AListNode<int>(resultStack.Pop());
      AListNode<int> resultCur = resultHead;
      while (resultStack.Count > 0)
      {
        resultCur.Next = new AListNode<int>(resultStack.Pop());
        resultCur = resultCur.Next;
      }

      return resultHead;
    }

    public static AListNode<int> SumReverse(AListNode<int> one, AListNode<int> two)
    {
      ThrowIfNull(one, two);

      int carry = 0;
      var head = new AListNode<int>();
      var cur = head;
      while (one != null || two != null || carry > 0)
      {
        int result;
        if (one != null && two != null)
        {
          result = one.Data + two.Data + carry;
          one = one.Next;
          two = two.Next;
        }
        else if (one != null)
        {
          result = one.Data + carry;
          one = one.Next;
        }
        else if (two != null)
        {
          result = two.Data + carry;
          two = two.Next;
        }
        else
        {
          result = carry;
        }

        carry = result / 10;
        var next = new AListNode<int>(result % 10);
        cur.Next = next;
        cur = next;
      }

      return head.Next;
    }

    private static void ThrowIfNull(AListNode<int> one, AListNode<int> two)
    {
      if (one == null)
      {
        throw new ArgumentNullException(nameof(one));
      }

      if (two == null)
      {
        throw new ArgumentNullException(nameof(two));
      }
    }

    private static void BuildStack(AListNode<int> head, out Stack<int> stack)
    {
      stack = new Stack<int>();
      while (head != null)
      {
        stack.Push(head.Data);
        head = head.Next;
      }
    }
  }
}
