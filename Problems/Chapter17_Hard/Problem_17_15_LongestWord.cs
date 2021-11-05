namespace CrackingTheCodingInterview.Problems.Chapter17_Hard
{
  using System;
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_17_15_LongestWord
  {
    public static string Execute(string[] input)
    {
      if (input == null || input.Length == 0)
      {
        return string.Empty;
      }

      var trie = new ATrie(input);
      string longestWord = string.Empty;

      foreach (string word in input)
      {
        if (IsMadeOfOtherWords(word, 0, trie))
        {
          if (word.Length > longestWord.Length)
          {
            longestWord = word;
          }
        }
      }

      return longestWord;
    }

    private static bool IsMadeOfOtherWords(string word, int start, ATrie trie)
    {
      for (int end = start + 1; end <= word.Length; end++)
      {
        string substring = word.Substring(start, end - start);

        // if the prefix does not exist, bail out early
        if (!trie.ContainsPrefix(substring))
        {
          return false;
        }

        if (substring != word && trie.ContainsWord(substring))
        {
          if (end == word.Length || IsMadeOfOtherWords(word, end, trie))
          {
            return true;
          }
        }
      }

      return false;
    }
  }
}
