namespace CrackingTheCodingInterview.Problems.Chapter3_StacksAndQueues
{
  using System;
  using System.Text;

  public class Problem_3_1_ThreeInOne
  {
    private const int NumberOfStacks = 3;
    private const uint MaxStackSize = uint.MaxValue / NumberOfStacks;
    private readonly int[] data;
    private readonly int[] stackIndexes;
    private readonly uint stackSize;

    public Problem_3_1_ThreeInOne(uint stackSize)
    {
      if (stackSize > MaxStackSize)
      {
        throw new ArgumentException($"{nameof(stackSize)} must be smaller than {uint.MaxValue / NumberOfStacks}", nameof(stackSize));
      }

      this.data = new int[stackSize * 3];
      this.stackIndexes = new int[NumberOfStacks];
      this.stackSize = stackSize;
      for (int i = 0; i < NumberOfStacks; i++)
      {
        this.stackIndexes[i] = -1;
      }
    }

    public void Push(uint stackId, int value)
    {
      this.ThrowIfInvalid(stackId);
      if (this.IsFull(stackId))
      {
        throw new OutOfMemoryException($"stackSize {MaxStackSize} exceeded");
      }

      this.stackIndexes[stackId]++;
      this.data[this.stackIndexes[stackId]] = value;
    }

    public int Pop(uint stackId)
    {
      this.ThrowIfInvalid(stackId);
      int value = this.data[this.stackIndexes[stackId]];
      this.stackIndexes[stackId]--;
      return value;
    }

    public bool IsFull(uint stackId)
    {
      this.ThrowIfInvalid(stackId);
      return !this.IsEmpty(stackId) && this.stackIndexes[stackId] == this.stackSize - 1;
    }

    public bool IsEmpty()
    {
      bool isEmpty = true;
      foreach (int index in this.stackIndexes)
      {
        isEmpty &= index == -1;
      }

      return isEmpty;
    }

    public bool IsEmpty(uint stackId)
    {
      this.ThrowIfInvalid(stackId);
      return this.stackIndexes[stackId] == -1;
    }

    public int Peak(uint stackId)
    {
      this.ThrowIfInvalid(stackId);
      return this.data[this.stackIndexes[stackId]];
    }

    public override string ToString()
    {
      // TODO: this breaks for a stack size > int.maxValue
      var stackSegments = new ArraySegment<int>[NumberOfStacks];
      for (int i = 0; i < NumberOfStacks; i++)
      {
        stackSegments[i] = new ArraySegment<int>(this.data, (int)this.stackSize * i, (int)this.stackSize);
      }

      var builder = new StringBuilder();
      for (int i = 0; i < stackSegments.Length; i++)
      {
        ArraySegment<int> stackSegment = stackSegments[i];
        builder.Append($"stack {i}: [");
        builder.Append(string.Join(", ", stackSegment));
        builder.Append($"] | {Environment.NewLine}");
      }

      return builder.ToString();
    }

    private void ThrowIfInvalid(uint stackId)
    {
      if (stackId >= this.stackIndexes.Length)
      {
        throw new ArgumentException($"{nameof(stackId)} must be between 0 and {this.stackIndexes.Length}", nameof(stackId));
      }
    }
  }
}
