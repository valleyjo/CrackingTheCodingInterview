namespace CrackingTheCodingInterview.Problems.Chapter08_RecursionAndDynamicProgramming
{
  using System.Collections.Generic;

  public static class Problem_8_08_PermutationsWithDups
  {
    public static List<string> Execute(string input)
    {
      var results = new List<string>();
      Execute(input, string.Empty, BuildFrequencies(input), results);
      return results;
    }

    public static void Execute(string input, string currentPermutation, Dictionary<char, int> charCounts, List<string> results)
    {
      if (currentPermutation.Length == input.Length)
      {
        results.Add(currentPermutation);
        return;
      }

      foreach (KeyValuePair<char, int> kvp in charCounts)
      {
        if (kvp.Value > 0)
        {
          charCounts[kvp.Key]--;
          Execute(input, currentPermutation + kvp.Key, charCounts, results);
          charCounts[kvp.Key]++;
        }
      }
    }

    private static Dictionary<char, int> BuildFrequencies(string input)
    {
      var result = new Dictionary<char, int>();
      foreach (char c in input)
      {
        if (result.ContainsKey(c))
        {
          result[c]++;
        }
        else
        {
          result[c] = 1;
        }
      }

      return result;
    }
  }
}
