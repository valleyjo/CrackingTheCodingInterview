namespace CrackingTheCodingInterview.Problems.Special
{
  using System;
  using System.Collections.Generic;

  public static class Problem_g_04_ScrabbleDecks
  {
    private const int DeckSize = 7;

    // Assume counts contains 0 for missing letters
    public static List<string> Execute(int[] counts)
    {
      var results = new List<string>();
      if (counts == null)
      {
        return results;
      }

      Execute(counts, results, string.Empty);

      return results;
    }

    private static void Execute(int[] counts, List<string> results, string prefix)
    {
      if (prefix.Length > DeckSize)
      {
        return;
      }
      else if (prefix.Length == DeckSize)
      {
        results.Add(prefix);
        return;
      }

      foreach (KeyValuePair<char, int> kvp in counts)
      {
        string extendedPrefix = prefix;
        for (int i = kvp.Value; i > 0; i--)
        {
          extendedPrefix += kvp.Key;
          Execute(counts, results, extendedPrefix);
        }
      }
    }

    private static char IndexToChar(int i) => (char)(i + 'A');
  }
}
