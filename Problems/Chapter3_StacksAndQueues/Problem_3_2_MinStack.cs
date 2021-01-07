namespace CrackingTheCodingInterview.Problems.Chapter3_StacksAndQueues
{
  using System;
  using System.Collections.Generic;

  public class Problem_3_2_MinStack
  {
    private readonly List<MinStackRecord> data;
    private int minValue;

    public Problem_3_2_MinStack()
    {
      this.data = new List<MinStackRecord>();
      this.minValue = int.MaxValue;
    }

    public void Push(int value)
    {
      if (value < this.minValue)
      {
        this.minValue = value;
      }

      this.data.Add(new MinStackRecord(value, this.minValue));
    }

    public int Pop()
    {
      this.ThrowIfEmpty();
      int value = this.data[^1].Data;
      this.data.RemoveAt(this.data.Count - 1);
      return value;
    }

    public bool IsEmpty() => this.data.Count > 0;

    public int GetMin()
    {
      this.ThrowIfEmpty();
      return this.data[^1].MinValue;
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
