namespace CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming
{
  using System.Collections.Generic;

  public static class Problem_8_4_PowerSet
  {
    public static List<List<int>> Execute(int[] a)
    {
      if (a == null || a.Length == 0)
      {
        return null;
      }

      var result = new List<List<int>>();
      Execute(a, result);
      return result;
    }

    private static void Execute(int[] a, List<List<int>> results)
    {
      foreach (int value in a)
      {
        var newResults = new List<List<int>>();
        newResults.Add(new List<int>() { value });

        foreach (List<int> result in results)
        {
          var copy = new List<int>(result);
          copy.Add(value);
          newResults.Add(copy);
        }

        results.AddRange(newResults);
      }
    }
  }
}
