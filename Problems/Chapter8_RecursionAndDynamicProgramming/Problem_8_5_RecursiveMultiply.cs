namespace CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming
{
  using System;

  public static class Problem_8_5_RecursiveMultiply
  {
    public static uint Execute(uint a, uint b)
    {
      uint result = 0;
      uint min = Math.Min(a, b);
      uint max = Math.Max(a, b);
      for (uint i = 0; i < min; i++)
      {
        result += max;
      }

      uint other = 0;
      do
      {
        int shift = (int)Math.Log2(min);
        other += max << shift;
        min -= 1U << shift;
      }
      while (min > 0);

      return other;
    }

    public static uint ExecuteRecursive(uint a, uint b) => ExecuteResursiveInternal(Math.Min(a, b), Math.Max(a, b));

    private static uint ExecuteResursiveInternal(uint smaller, uint bigger)
    {
      if (smaller == 0)
      {
        return 0;
      }

      if (smaller == 1)
      {
        return bigger;
      }

      uint half = ExecuteResursiveInternal(smaller >> 1, bigger);
      if (smaller % 2 == 0)
      {
        return half + half;
      }

      return half + half + bigger;
    }
  }
}
