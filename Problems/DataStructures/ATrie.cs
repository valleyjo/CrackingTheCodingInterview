namespace CrackingTheCodingInterview.Problems.DataStructures
{
  using System.Collections.Generic;

  public class ATrie
  {
    private readonly TrieNode root = new();

    public ATrie(IEnumerable<string> words = null)
    {
      if (words == null)
      {
        return;
      }

      foreach (string word in words)
      {
        this.AddWord(word);
      }
    }

    public void AddWord(string word)
    {
      if (!string.IsNullOrEmpty(word))
      {
        this.root.AddWord(word, 0);
      }
    }

    public bool ContainsPrefix(string prefix) => this.root.ContainsPrefix(prefix, 0) != null;

    public bool ContainsWord(string word)
    {
      TrieNode node = this.root.ContainsPrefix(word, 0);
      return node != null && node.IsTerminal;
    }

    public string GetShortestUniquePrefix(string word)
    {
      (_, string prefix) = this.root.GetUniquePrefix(word, 0);
      return prefix;
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
        if (string.IsNullOrEmpty(prefix) || index < 0)
        {
          return null;
        }

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

      public (int ChildCount, string Prefix) GetUniquePrefix(string word, int index)
      {
        if (index == word.Length)
        {
          return new(this.children.Count, string.Empty);
        }

        char nextChar = word[index];

        if (this.children.ContainsKey(nextChar))
        {
          (int ChildCount, string Prefix) result =
            this.children[nextChar].GetUniquePrefix(word, index + 1);

          int isTerminalCount = this.IsTerminal && index != word.Length - 1 ? 1 : 0;
          int nextChildCount = result.ChildCount + this.children.Count + isTerminalCount;

          if (!string.IsNullOrEmpty(result.Prefix))
          {
            // we already found the prefix, return it up the stack
            return result;
          }
          else if (nextChildCount > (word.Length - index) || index == 0)
          {
            // when the child count is greater than the remaining characters for
            // the first time we found the shortest unique prefix
            return new(-1, word.Substring(0, index + 1 + isTerminalCount));
          }
          else
          {
            // child count is equal to the remaining characters, this means we
            // are on a branch which contains the shortest unique prefix
            return new(nextChildCount, string.Empty);
          }
        }

        return new(-1, string.Empty);
      }
    }
  }
}
