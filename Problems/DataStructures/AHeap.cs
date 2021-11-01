namespace CrackingTheCodingInterview.Problems.DataStructures
{
  using System;
  using System.Collections.Generic;

  public class AHeap
  {
    private readonly List<int> data;
    private readonly int defaultValue;
    private readonly Func<int, int, int> compare;

    public AHeap(bool isMinHeap = true)
    {
      static int MinComparer(int x, int y)
      {
        if (x == y)
        {
          return 0;
        }
        else if (x < y)
        {
          return -1;
        }
        else
        {
          return 1;
        }
      }

      static int MaxComparer(int x, int y)
      {
        if (x == y)
        {
          return 0;
        }
        else if (x < y)
        {
          return 1;
        }
        else
        {
          return -1;
        }
      }

      this.compare = isMinHeap ? MinComparer : MaxComparer;
      this.defaultValue = isMinHeap ? int.MaxValue : int.MinValue;
      this.data = new List<int>();
    }

    public int Count => this.data.Count;

    public int Peek()
    {
      if (this.data.Count >= 1)
      {
        return this.data[0];
      }

      throw new InvalidOperationException("Peek not supported when heap is empty");
    }

    public void Insert(int value)
    {
      this.data.Add(value);
      this.HeapifyUp(this.data.Count - 1);
    }

    public void Remove()
    {
      if (this.data.Count == 0)
      {
        throw new InvalidOperationException("Remove not allowed when the heap is empty");
      }

      this.data[0] = this.data[^1];
      this.data.RemoveAt(this.data.Count - 1);
      this.HeapifyDown(0);
    }

    private void HeapifyDown(int index)
    {
      if (index >= this.data.Count)
      {
        return;
      }

      int currentValue = this.data[index];
      int leftIndex = (index * 2) + 1;
      int rightIndex = (index * 2) + 2;
      int leftValue = leftIndex < this.data.Count ? this.data[leftIndex] : this.defaultValue;
      int rightValue = rightIndex < this.data.Count ? this.data[rightIndex] : this.defaultValue;
      int swapValue = int.MinValue;
      int swapIndex = -1;

      if (this.compare(currentValue, rightValue) <= 0 && this.compare(currentValue, leftValue) <= 0)
      {
        return;
      }
      else if (this.compare(leftValue, rightValue) < 0)
      {
        // swap the left child
        swapValue = leftValue;
        swapIndex = leftIndex;
      }
      else
      {
        // swap the right child
        swapValue = rightValue;
        swapIndex = rightIndex;
      }

      this.data[swapIndex] = currentValue;
      this.data[index] = swapValue;
      this.HeapifyDown(swapIndex);
    }

    private void HeapifyUp(int index)
    {
      if (index == 0)
      {
        return;
      }

      int currentValue = this.data[index];
      int parentIndex = index / 2;
      int parentValue = this.data[parentIndex];
      if (this.compare(currentValue, parentValue) < 0)
      {
        this.data[parentIndex] = currentValue;
        this.data[index] = parentValue;
        this.HeapifyUp(parentIndex);
      }
    }
  }
}
