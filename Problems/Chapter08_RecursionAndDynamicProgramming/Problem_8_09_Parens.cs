namespace CrackingTheCodingInterview.Problems.Chapter08_RecursionAndDynamicProgramming
{
  using System.Collections.Generic;

  public static class Problem_8_09_Parens
  {
    public static List<string> Execute(uint count)
    {
      var results = new List<string>();
      Execute(0, 0, count, string.Empty, results);
      return results;
    }

    public static void Execute(uint openCount, uint closedCount, uint pairCount, string current, List<string> results)
    {
      if (openCount > pairCount || closedCount > pairCount)
      {
        return;
      }

      if (openCount == closedCount && openCount == pairCount)
      {
        results.Add(current);
        return;
      }

      if (openCount != closedCount)
      {
        Execute(openCount, closedCount + 1, pairCount, current + ")", results);
      }

      Execute(openCount + 1, closedCount, pairCount, current + "(", results);
    }
  }
}
