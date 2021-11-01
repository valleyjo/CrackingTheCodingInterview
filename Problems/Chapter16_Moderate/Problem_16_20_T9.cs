namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;
  using System.Text;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_16_20_T9
  {
    private static readonly Dictionary<char, char[]> NumberToLetterMapping = new()
    {
      { '2', new char[] { 'a', 'b', 'c', } },
      { '3', new char[] { 'd', 'e', 'f', } },
      { '4', new char[] { 'g', 'h', 'i', } },
      { '5', new char[] { 'j', 'k', 'l', } },
      { '6', new char[] { 'm', 'n', 'o', } },
      { '7', new char[] { 'p', 'q', 'r', 's', } },
      { '8', new char[] { 't', 'u', 'v', } },
      { '9', new char[] { 'w', 'x', 'y', 'z', } },
    };

    public static List<string> Execute(string input, List<string> words)
    {
      var results = new List<string>();
      if (string.IsNullOrEmpty(input) || words == null || words.Count == 0)
      {
        return results;
      }

      Execute(results, input, 0, string.Empty, new ATrie(words));
      return results;
    }

    public static List<string> ExecuteFaster(string input, List<string> words)
    {
      if (string.IsNullOrEmpty(input) || words == null || words.Count == 0)
      {
        return new List<string>();
      }

      Dictionary<char, char> letterToNumMapping = GetLetterToNumberMapping();
      var t9ToEnglishMapping = new Dictionary<string, List<string>>();
      foreach (string word in words)
      {
        string t9 = ConvertToT9(word, letterToNumMapping);
        if (t9ToEnglishMapping.TryGetValue(t9, out List<string> englishWords))
        {
          englishWords.Add(word);
        }
        else
        {
          t9ToEnglishMapping.Add(t9, new List<string>() { word });
        }
      }

      if (t9ToEnglishMapping.ContainsKey(input))
      {
        return t9ToEnglishMapping[input];
      }

      return new List<string>();
    }

    private static string ConvertToT9(string word, Dictionary<char, char> letterToNumMapping)
    {
      var sb = new StringBuilder();
      foreach (char c in word)
      {
        sb.Append(letterToNumMapping[c]);
      }

      return sb.ToString();
    }

    private static Dictionary<char, char> GetLetterToNumberMapping()
    {
      var result = new Dictionary<char, char>();
      foreach (KeyValuePair<char, char[]> kvp in NumberToLetterMapping)
      {
        foreach (char c in kvp.Value)
        {
          result.Add(c, kvp.Key);
        }
      }

      return result;
    }

    private static void Execute(List<string> results, string input, int index, string prefix, ATrie prefixes)
    {
      if (index == input.Length)
      {
        if (prefixes.ContainsWord(prefix))
        {
          results.Add(prefix);
        }

        return;
      }

      foreach (char c in NumberToLetterMapping[input[index]])
      {
        string newPrefix = prefix + c;
        if (prefixes.ContainsPrefix(newPrefix))
        {
          Execute(results, input, index + 1, prefix + c, prefixes);
        }
      }
    }
  }
}
