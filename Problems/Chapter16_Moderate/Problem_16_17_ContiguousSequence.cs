namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;

  public static class Problem_16_17_ContiguousSequence
  {
    public static int Execute(int[] input)
    {
      // consider throwing exception rather than returning zero because zero could be
      // a legitimate answer
      if (input == null || input.Length == 0)
      {
        return 0;
      }

      int overallMaximumSubsequence = input[0];
      int previousMaximumSubsequence = input[0];
      for (int i = 1; i < input.Length; i++)
      {
        int currentValue = input[i];

        // we can either continue the previous subsequence or start a new one
        int currentMaximumSubsequence = Math.Max(currentValue, previousMaximumSubsequence + currentValue);
        previousMaximumSubsequence = currentMaximumSubsequence;

        // save the max seen so far
        overallMaximumSubsequence = Math.Max(overallMaximumSubsequence, currentMaximumSubsequence);
      }

      return overallMaximumSubsequence;
    }
  }
}
