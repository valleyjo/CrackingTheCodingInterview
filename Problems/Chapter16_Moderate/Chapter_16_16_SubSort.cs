namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;

  public static class Chapter_16_16_SubSort
  {
    private static readonly Range InvalidRange = new(-1, -1);

    public static Range Execute(int[] input)
    {
      if (input == null || input.Length == 0)
      {
        return InvalidRange;
      }

      int start = FindStartIndex(input);
      if (start == input.Length - 1)
      {
        // array is already sorted
        // ambiguous between invalid input
        // maybe 0,0
        return InvalidRange;
      }

      int end = FindEndIndex(input);

      int min = input[start];
      int max = input[end];
      for (int i = start; i <= end; i++)
      {
        min = Math.Min(input[i], min);
        max = Math.Max(input[i], max);
      }

      start = ShrinkLeft(input, min);
      end = ShrinkRight(input, max);

      return new Range(start, end);
    }

    private static int ShrinkRight(int[] input, int max)
    {
      for (int i = input.Length - 1; i >= 0; i--)
      {
        if (input[i] < max)
        {
          return i;
        }
      }

      return input.Length - 1;
    }

    private static int ShrinkLeft(int[] input, int min)
    {
      for (int i = 0; i < input.Length; i++)
      {
        if (input[i] > min)
        {
          return i;
        }
      }

      return 0;
    }

    private static int FindStartIndex(int[] input)
    {
      for (int i = 0; i < input.Length - 2; i++)
      {
        if (input[i] > input[i + 1])
        {
          return i + 1;
        }
      }

      return input.Length - 1;
    }

    private static int FindEndIndex(int[] input)
    {
      for (int i = input.Length - 2; i >= 0; i--)
      {
        if (input[i] > input[i + 1])
        {
          return i + 1;
        }
      }

      return 0;
    }

    public struct Range
    {
      public Range(int start, int end)
      {
        this.Start = start;
        this.End = end;
      }

      public int Start { get; }

      public int End { get; }
    }
  }
}
