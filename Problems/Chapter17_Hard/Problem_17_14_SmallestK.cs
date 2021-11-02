namespace CrackingTheCodingInterview.Problems.Chapter17_Hard
{
  using System;
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_17_14_SmallestK
  {
    public static List<int> Execute(int[] input, int k)
    {
      var results = new List<int>();
      if (input == null || input.Length == 0 || k < 1)
      {
        return results;
      }

      var maxHeap = new AHeap(isMinHeap: false);
      foreach (int v in input)
      {
        if (maxHeap.Count < k)
        {
          maxHeap.Insert(v);
        }
        else if (v < maxHeap.Peek())
        {
          maxHeap.Remove();
          maxHeap.Insert(v);
        }
      }

      while (maxHeap.Count > 0)
      {
        results.Add(maxHeap.Peek());
        maxHeap.Remove();
      }

      return results;
    }
  }
}
