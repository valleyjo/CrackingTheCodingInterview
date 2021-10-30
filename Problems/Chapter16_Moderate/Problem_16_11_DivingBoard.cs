namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;

  // TODO: Add tests
  public static class Problem_16_11_DivingBoard
  {
    public static List<int> Execute(int k, int s, int l)
    {
      var results = new List<int>();
      for (int sCount = 0; sCount <= k; sCount++)
      {
        int lCount = k - sCount;
        results.Add((lCount * l) + (sCount * s));
      }

      return results;
    }
  }
}
