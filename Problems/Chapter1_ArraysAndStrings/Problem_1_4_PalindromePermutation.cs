namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings
{
  using System.Collections.Generic;

  public class Problem_1_4_PalindromePermutation
  {
    public static bool Execute(string s)
    {
      if (string.IsNullOrEmpty(s))
      {
        return false;
      }

      var charCounts = new Dictionary<char, int>();
      foreach (char c in s)
      {
        if (charCounts.ContainsKey(c))
        {
          charCounts[c]++;
        }
        else
        {
          charCounts.Add(c, 1);
        }
      }

      bool foundOddCount = false;
      foreach (var kvp in charCounts)
      {
        if (kvp.Value % 2 == 1)
        {
          if (foundOddCount)
          {
            return false;
          }
          else
          {
            foundOddCount = true;
          }
        }
      }

      return true;
    }
  }
}
