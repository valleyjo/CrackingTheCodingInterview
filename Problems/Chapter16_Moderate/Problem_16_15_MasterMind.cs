namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;

  // TODO: Add tests
  public static class Problem_16_15_MasterMind
  {
    private static readonly Result InvalidResult = new(-1, -1);

    public static Result Execute(string value, string guess)
    {
      // direct hits are never calculated as pseudo-hits
      // how to count double pseudo hits?
      // calculate pseudo-hits first, subtract direct hits?
      if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(guess) || value.Length != 4 || guess.Length != 4)
      {
        // TODO: real invalid result
        return InvalidResult;
      }

      int directHits = 0;
      Dictionary<char, int> guessCharCounts = GetDefaultDicionary();
      Dictionary<char, int> valueCharCounts = GetDefaultDicionary();

      for (int i = 0; i < value.Length; i++)
      {
        char valueChar = value[i];
        char guessChar = guess[i];

        if (!IsValidInputChar(valueChar) || !IsValidInputChar(guessChar))
        {
          throw new ArgumentException("input char must be one of: 'r', 'g', 'b', 'y'");
        }

        if (valueChar == guessChar)
        {
          directHits++;
        }
        else
        {
          guessCharCounts[guessChar]++;
          valueCharCounts[valueChar]++;
        }
      }

      int pseudoHits = 0;
      foreach (KeyValuePair<char, int> kvp in guessCharCounts)
      {
        pseudoHits += Math.Min(valueCharCounts[kvp.Key], kvp.Value);
      }

      return new Result(directHits, pseudoHits);
    }

    private static bool IsValidInputChar(char c) => c == 'r' || c == 'g' || c == 'b' || c == 'y';

    private static Dictionary<char, int> GetDefaultDicionary() => new()
      {
        { 'r', 0 },
        { 'g', 0 },
        { 'b', 0 },
        { 'y', 0 },
      };

    public struct Result
    {
      public Result(int direct, int indirect)
      {
        this.Direct = direct;
        this.Indirect = indirect;
      }

      public int Direct { get; }

      public int Indirect { get; }
    }
  }
}
