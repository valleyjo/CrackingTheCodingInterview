namespace CrackingTheCodingInterview.Problems.Chapter17_Hard
{
  using System;
  using System.Collections.Generic;

  public static class Problem_17_11_MinimumWordDistance
  {
    private static readonly List<int> EmptyLocationList = new();

    public static int Execute(string[] words, string wordOne, string wordTwo)
    {
      if (words == null || words.Length == 0 || string.IsNullOrEmpty(wordOne) || string.IsNullOrEmpty(wordTwo))
      {
        return -1;
      }

      // pre-compute
      Dictionary<string, List<int>> wordLocations = GetWordLocations(words);

      return GetSmallestDifference(GetOrEmpty(wordLocations, wordOne), GetOrEmpty(wordLocations, wordTwo));
    }

    private static List<int> GetOrEmpty(Dictionary<string, List<int>> dict, string key)
    {
      if (dict.TryGetValue(key, out List<int> locations))
      {
        return locations;
      }

      return EmptyLocationList;
    }

    private static int GetSmallestDifference(List<int> wordOneLocations, List<int> wordTwoLocations)
    {
      if (wordOneLocations == null || wordOneLocations.Count == 0 || wordTwoLocations == null || wordTwoLocations.Count == 0)
      {
        return -1;
      }

      int minDistance = int.MaxValue;
      for (int oneIndex = 0, twoIndex = 0; oneIndex < wordOneLocations.Count && twoIndex < wordTwoLocations.Count;)
      {
        int oneLoc = wordOneLocations[oneIndex];
        int twoLoc = wordTwoLocations[twoIndex];
        minDistance = Math.Min(minDistance, Math.Abs(oneLoc - twoLoc));

        if (oneLoc < twoLoc)
        {
          oneIndex++;
        }
        else
        {
          twoIndex++;
        }
      }

      return minDistance;
    }

    private static Dictionary<string, List<int>> GetWordLocations(string[] words)
    {
      var results = new Dictionary<string, List<int>>();
      for (int i = 0; i < words.Length; i++)
      {
        string word = words[i];
        if (!results.ContainsKey(word))
        {
          results[word] = new List<int>();
        }

        results[word].Add(i);
      }

      return results;
    }
  }
}
