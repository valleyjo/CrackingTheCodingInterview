namespace CrackingTheCodingInterview.Problems.Special
{
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

      Execute(counts, 0, results, string.Empty);

      return results;
    }

    private static void Execute(int[] counts, int startingIndex, List<string> results, string prefix)
    {
      if (prefix.Length == DeckSize)
      {
        results.Add(prefix);
        return;
      }

      Execute(counts, startingIndex + 1, results, prefix);

      for (; startingIndex < counts.Length; startingIndex++)
      {
        string extendedPrefix = prefix;
        for (int letterCount = counts[startingIndex]; letterCount > 0 && extendedPrefix.Length < DeckSize; letterCount--)
        {
          extendedPrefix += IndexToChar(startingIndex);
          Execute(counts, startingIndex + 1, results, extendedPrefix);
        }
      }
    }

    private static char IndexToChar(int i) => (char)(i + 'A');
  }
}
