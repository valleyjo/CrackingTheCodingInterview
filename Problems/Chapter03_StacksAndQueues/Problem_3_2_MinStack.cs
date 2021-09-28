namespace CrackingTheCodingInterview.Problems.Chapter3_StacksAndQueues
{
  using System;
  using System.Collections.Generic;

  public class Problem_3_2_MinStack
  {
    private readonly LinkedList<MinStackRecord> data;
    private int minValue;

    public Problem_3_2_MinStack()
    {
      this.data = new LinkedList<MinStackRecord>();
      this.minValue = int.MaxValue;
    }

    public void Push(int value)
    {
      if (value < this.minValue)
      {
        this.minValue = value;
      }

      this.data.AddLast(new MinStackRecord(value, this.minValue));
    }

    public int Pop()
    {
      this.ThrowIfEmpty();
      MinStackRecord record = this.data.Last.Value;
      this.data.RemoveLast();
      return record.Data;
    }

    public bool IsEmpty() => this.data.Count == 0;

    public int GetMin()
    {
      this.ThrowIfEmpty();
      return this.data.Last.Value.MinValue;
    }

    private void ThrowIfEmpty()
    {
      if (this.IsEmpty())
      {
        throw new InvalidOperationException("Stack is empty");
      }
    }

    private struct MinStackRecord
    {
      public MinStackRecord(int value, int minValue)
      {
        this.MinValue = minValue;
        this.Data = value;
      }

      public int Data { get; }

      public int MinValue { get; }
    }
  }
}
