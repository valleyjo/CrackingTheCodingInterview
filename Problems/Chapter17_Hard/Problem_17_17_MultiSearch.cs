namespace CrackingTheCodingInterview.Problems.Chapter17_Hard
{
  using System;
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_17_17_MultiSearch
  {
    /*
    requirements:
    return all matches for all T

    assumptions:
    valid input -> not empty not null
    input.Length >= 2

    signiture:
    List<Match> FindMatches(string input, string[] targets)
    Match:
    - int index
    - string value (a value from target)

    Some test cases:

    Approaches:
    brute force -> foreach T for each index in b see if it matches -> time: B*T space: 1
    foreach char in B -> foreach sub-word until longest word in T -> see if in Trie, if yes, add match

    Steps:

    */
    public static List<Match> Execute(string input, string[] targets)
    {
      var results = new List<Match>();
      if (string.IsNullOrEmpty(input) || targets == null || targets.Length == 0)
      {
        return results;
      }

      var trie = new ATrie(targets);
      for (int start = 0; start < input.Length; start++)
      {
        for (int end = start + 1; end <= input.Length; end++)
        {
          string substring = input.Substring(start, end - start);

          // no word in targets starts with this prefix, no need to continue with this prefix
          if (!trie.ContainsPrefix(substring))
          {
            break;
          }

          if (trie.ContainsWord(substring))
          {
            results.Add(new Match(start, end, substring));
          }
        }
      }

      return results;
    }

    public readonly struct Match
    {
      public Match(int start, int end, string value)
      {
        this.Start = start;
        this.End = end;
        this.Value = value;
      }

      public string Value { get; }

      public int Start { get; }

      public int End { get; }
    }
  }
}
