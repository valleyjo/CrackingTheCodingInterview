namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;

  public class Problem_16_02_WordFrequencies
  {
    private Dictionary<string, int> wordCounts;

    public int Execute(string[] book, string wordToFind)
    {
      if (book == null || string.IsNullOrEmpty(wordToFind))
      {
        return 0;
      }

      if (this.wordCounts == null)
      {
        this.wordCounts = BuildWordCounts(book);
      }

      return this.wordCounts.ContainsKey(wordToFind) ? this.wordCounts[wordToFind] : 0;
    }

    private static Dictionary<string, int> BuildWordCounts(string[] book)
    {
      var wordCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

      // assume no word count more than 2^32
      foreach (string word in book)
      {
        if (wordCounts.ContainsKey(word))
        {
          wordCounts[word]++;
        }
        else
        {
          wordCounts[word] = 1;
        }
      }

      return wordCounts;
    }
  }
}
