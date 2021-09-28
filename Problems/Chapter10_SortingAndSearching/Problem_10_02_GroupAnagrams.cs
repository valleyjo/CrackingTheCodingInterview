namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  public class Problem_10_02_GroupAnagrams
  {
    public static string[] Execute(string[] anagrams)
    {
      var groupingMap = new Dictionary<string, List<string>>();
      foreach (string anagram in anagrams ?? Enumerable.Empty<string>())
      {
        string uniqueRepresentation = GetUniqueRepresentation(anagram);
        if (groupingMap.TryGetValue(uniqueRepresentation, out List<string> others))
        {
          others.Add(anagram);
        }
        else
        {
          groupingMap.Add(uniqueRepresentation, new List<string>() { anagram });
        }
      }

      int index = 0;
      foreach (KeyValuePair<string, List<string>> kvp in groupingMap)
      {
        foreach (string anagram in kvp.Value)
        {
          anagrams[index++] = anagram;
        }
      }

      return anagrams;
    }

    public static string[] ExecuteMapWithSorting(string[] anagrams)
    {
      var groupingMap = new Dictionary<string, List<string>>();
      foreach (string anagram in anagrams ?? Enumerable.Empty<string>())
      {
        char[] chars = anagram.ToCharArray();
        Array.Sort(chars);
        string uniqueRepresentation = new string(chars);
        if (groupingMap.TryGetValue(uniqueRepresentation, out List<string> others))
        {
          others.Add(anagram);
        }
        else
        {
          groupingMap.Add(uniqueRepresentation, new List<string>() { anagram });
        }
      }

      int index = 0;
      foreach (KeyValuePair<string, List<string>> kvp in groupingMap)
      {
        foreach (string anagram in kvp.Value)
        {
          anagrams[index++] = anagram;
        }
      }

      return anagrams;
    }

    public static string[] ExecuteWithSorting(string[] input)
    {
      if (input == null)
      {
        return null;
      }

      Array.Sort(input, (string s, string p) =>
        {
          char[] sChars = s.ToCharArray();
          char[] pChars = p.ToCharArray();
          Array.Sort(sChars);
          Array.Sort(pChars);
          return string.Compare(new string(sChars), new string(pChars));
        });

      return input;
    }

    private static string GetUniqueRepresentation(string anagram)
    {
      var charCounts = new Dictionary<char, int>();
      foreach (char c in anagram)
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

      var sb = new StringBuilder();
      foreach (KeyValuePair<char, int> kvp in charCounts)
      {
        sb.Append(kvp.Key);
        sb.Append(kvp.Value);
      }

      return sb.ToString();
    }
  }
}
