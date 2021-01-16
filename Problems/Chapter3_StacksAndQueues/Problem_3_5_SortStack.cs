namespace CrackingTheCodingInterview.Problems.Chapter3_StacksAndQueues
{
  using System;
  using System.Collections.Generic;
  using System.Data.SqlTypes;

  public class Problem_3_5_SortStack
  {
    /*
    modify stack in place
    */
    public static void Execute(Stack<int> stack)
    {
      if (stack == null)
      {
        throw new ArgumentNullException(nameof(stack));
      }

      var tmp = new Stack<int>();
      int numberOfSortedElements = 0;
      while (numberOfSortedElements < stack.Count)
      {
        int max = stack.Pop();
        while (stack.Count > numberOfSortedElements)
        {
          if (stack.Peek() > max)
          {
            tmp.Push(max);
            max = stack.Pop();
          }
          else
          {
            tmp.Push(stack.Pop());
          }
        }

        stack.Push(max);
        numberOfSortedElements++;

        while (tmp.Count > 0)
        {
          stack.Push(tmp.Pop());
        }
      }
    }
  }
}
