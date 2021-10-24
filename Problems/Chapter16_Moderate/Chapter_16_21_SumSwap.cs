namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;
  using System.Text;

  public static class Chapter_16_21_SumSwap
  {
    /*
    Test cases:
    null / empty
    one value in an array
    two values
    many values
    valid replacemenet
    invalid replacement
    starting off with the same sum
     */
    public static int[] Execute(int[] one, int[] two)
    {
      if (one == null || two == null || one.Length == 0 || two.Length == 0)
      {
        return Array.Empty<int>();
      }

      var twoMap = new HashSet<int>(two);
      int sumOne = SumArray(one);
      int sumTwo = SumArray(two);
      int delta = sumOne - sumTwo;
      if (delta % 2 != 0)
      {
        return Array.Empty<int>();
      }

      delta /= 2;

      foreach (int v in one)
      {
        int matchingPair = v - delta;
        if (twoMap.Contains(matchingPair))
        {
          return new int[] { v, matchingPair };
        }
      }

      return Array.Empty<int>();
    }

    private static int SumArray(int[] one)
    {
      int total = 0;
      foreach (int v in one)
      {
        total += v;
      }

      return total;
    }
  }
}
