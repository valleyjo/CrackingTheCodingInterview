namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;
  using System.Threading;

  public static class Chapter_16_24_PairsWithSum
  {
    public static List<Result> Execute(int[] input, int sum)
    {
      var results = new List<Result>();
      if (input == null || input.Length == 0)
      {
        return results;
      }

      var map = new Dictionary<int, int>();
      foreach (int v in input)
      {
        int delta = sum - v;
        if (map.ContainsKey(delta) && map[delta] >= 1)
        {
          map[delta]--;
          results.Add(new Result() { One = delta, Two = v });
        }
        else
        {
          map[v] = 1;
        }
      }

      return results;
    }

    public struct Result
    {
      public int One { get; set; }

      public int Two { get; set; }
    }
  }
}
