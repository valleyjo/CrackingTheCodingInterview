namespace CrackingTheCodingInterview.Problems.Chapter03_StacksAndQueues
{
  using System;
  using System.Collections.Generic;

  /*
  convert FIFO to LIFO

  can use one stack as storage, and move between stacks over for each operaton

  save time by only reversing operations when actually needed
  */
  public class Problem_3_4_QueueViaStacks
  {
    private readonly Stack<int> primary;
    private readonly Stack<int> secondary;

    public Problem_3_4_QueueViaStacks()
    {
      this.primary = new Stack<int>();
      this.secondary = new Stack<int>();
    }

    public void Enqueue(int value)
    {
      this.primary.Push(value);
    }

    public int Dequeue()
    {
      if (this.primary.Count == 0 && this.secondary.Count == 0)
      {
        throw new InvalidOperationException("Can't dequeue empty queue");
      }

      // reverse the stacks
      int value;
      if (this.secondary.Count > 0)
      {
        value = this.secondary.Pop();
      }
      else
      {
        ReverseStacks(this.primary, this.secondary);
        value = this.secondary.Pop();
      }

      return value;
    }

    private static void ReverseStacks(Stack<int> source, Stack<int> dest)
    {
      while (source.Count > 0)
      {
        dest.Push(source.Pop());
      }
    }
  }
}
