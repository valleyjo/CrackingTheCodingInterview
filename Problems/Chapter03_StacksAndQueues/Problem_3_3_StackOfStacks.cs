namespace CrackingTheCodingInterview.Problems.Chapter03_StacksAndQueues
{
  using System;
  using System.Collections.Generic;

  public class Problem_3_3_StackOfStacks
  {
    private readonly List<Stack<int>> data;
    private readonly int capacity;
    private int activeStack;

    public Problem_3_3_StackOfStacks(int capacity)
    {
      if (capacity < 1)
      {
        throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than 0");
      }

      this.capacity = capacity;
      this.data = new List<Stack<int>>() { new Stack<int>(), };
      this.activeStack = 0;
    }

    public void Push(int value)
    {
      if (this.data[this.activeStack].Count < this.capacity)
      {
        this.data[this.activeStack].Push(value);
      }
      else
      {
        var nextStack = new Stack<int>();
        nextStack.Push(value);
        this.data.Add(nextStack);
        this.activeStack++;
      }
    }

    public int Pop()
    {
      if (this.data[this.activeStack].Count > 0)
      {
        return this.data[this.activeStack].Pop();
      }
      else
      {
        // resize the list?
        this.data.RemoveAt(this.activeStack);
        this.activeStack--;
        if (this.activeStack == -1)
        {
          throw new InvalidOperationException("Cannot pop empty stack");
        }

        return this.data[this.activeStack].Pop();
      }
    }

    public int Peak() => this.data[this.activeStack].Peek();

    public int PopAt(int index)
    {
      if (index < 0 || index > this.activeStack)
      {
        throw new ArgumentOutOfRangeException("Index must be greater than zero and less than the number of stacks");
      }

      return this.data[index].Pop();
    }
  }
}
