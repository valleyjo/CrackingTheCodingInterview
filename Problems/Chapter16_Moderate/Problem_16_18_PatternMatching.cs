namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;
  using System.Text;

  public static class Problem_16_18_PatternMatching
  {
    public static bool Execute(string pattern, string value)
    {
      if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(value))
      {
        return false;
      }

      var patternValues = new HashSet<string>();
      for (int i = 0; i < value.Length; i++)
      {
        int length = value.Length - i;
        string substring = value.Substring(0, length);
        for (int j = 0; j < substring.Length; j++)
        {
          int secondLength = substring.Length - j;
          string firstHalf = substring.Substring(0, secondLength);
          string secondHalf = substring.Substring(j);
          patternValues.Add(firstHalf);
          patternValues.Add(secondHalf);
        }
      }

      foreach (string a in patternValues)
      {
        foreach (string b in patternValues)
        {
          string possibleValue = BuildValueFromPattern(pattern, a, b);
          if (string.Equals(possibleValue, value, StringComparison.OrdinalIgnoreCase))
          {
            return true;
          }
        }
      }

      return false;
    }

    private static string BuildValueFromPattern(string pattern, string a, string b)
    {
      var sb = new StringBuilder();
      foreach (char c in pattern)
      {
        if (c == 'a')
        {
          sb.Append(a);
        }
        else
        {
          sb.Append(b);
        }
      }

      return sb.ToString();
    }
  }
}
