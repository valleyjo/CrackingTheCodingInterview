namespace CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming
{
  using System;
  using System.Collections.Generic;

  public static class Problem_8_07_PermutationsWithoutDups
  {
    public static List<string> Execute(string input)
    {
      var results = new List<string>();
      Execute(input, 0, string.Empty, new HashSet<int>(), results);
      return results;
    }

    public static void Execute(string input, int index, string currentPermutation, HashSet<int> usedIndexes, List<string> results)
    {
      if (currentPermutation.Length == input.Length)
      {
        results.Add(currentPermutation);
        return;
      }

      for (int i = 0; i < input.Length; i++)
      {
        if (!usedIndexes.Contains(i))
        {
          var copy = new HashSet<int>(usedIndexes);
          copy.Add(i);
          string nextPartialPermutation = currentPermutation + input[i];
          Execute(input, i, nextPartialPermutation, copy, results);
        }
      }
    }
  }
}
