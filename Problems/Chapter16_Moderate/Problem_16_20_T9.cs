namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;
  using System.Text;

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

      Execute(results, input, 0, string.Empty, new Trie(words));
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

    private static void Execute(List<string> results, string input, int index, string prefix, Trie prefixes)
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

    // TODO extract and test
    private class Trie
    {
      private readonly TrieNode root = new();

      public Trie(List<string> words)
      {
        foreach (string word in words)
        {
          this.AddWord(word);
        }
      }

      public void AddWord(string word)
      {
        this.root.AddWord(word, 0);
      }

      public bool ContainsPrefix(string prefix) => this.root.ContainsPrefix(prefix, 0) != null;

      public bool ContainsWord(string word)
      {
        TrieNode node = this.root.ContainsPrefix(word, 0);
        return node != null && node.IsTerminal;
      }

      private class TrieNode
      {
        private readonly Dictionary<char, TrieNode> children = new();

        public bool IsTerminal { get; private set; }

        public void AddWord(string word, int index)
        {
          if (index == word.Length)
          {
            return;
          }
          else if (index == word.Length - 1)
          {
            this.IsTerminal = true;
          }

          char c = word[index];
          if (!this.children.TryGetValue(c, out TrieNode nextNode))
          {
            nextNode = new TrieNode();
            this.children[c] = nextNode;
          }

          nextNode.AddWord(word, index + 1);
        }

        public TrieNode ContainsPrefix(string prefix, int index)
        {
          char c = prefix[index];
          if (this.children.ContainsKey(c))
          {
            // we are at the last char and it exists in the trie
            if (prefix.Length - 1 == index)
            {
              return this;
            }

            return this.children[c].ContainsPrefix(prefix, index + 1);
          }

          return null;
        }
      }
    }
  }
}
