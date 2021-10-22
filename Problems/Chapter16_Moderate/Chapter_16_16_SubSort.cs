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
        return InvalidRange;
      }

      int end = FindEndIndex(input);

      int min = input[start];
      int max = input[start];
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
      for (int end = input.Length - 1; end >= 0 && input[end] >= max; end--)
      {
        if (input[end] < max)
        {
          return end;
        }
      }

      return input.Length - 1;
    }

    private static int ShrinkLeft(int[] input, int min)
    {
      for (int start = 0; start < input.Length; start++)
      {
        if (input[start] > min)
        {
          return start;
        }
      }

      return 0;
    }

    private static int FindStartIndex(int[] input)
    {
      int i = 0;
      for (i = 0; i < input.Length - 2 && input[i] <= input[i + 1]; i++)
      {
      }

      return i == input.Length - 2 && input[i] <= input[i + 1] ? i + 1 : i;
    }

    private static int FindEndIndex(int[] input)
    {
      int i = 0;
      for (i = input.Length - 2; i >= 0 && input[i] <= input[i + 1]; i--)
      {
      }

      return i;
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
