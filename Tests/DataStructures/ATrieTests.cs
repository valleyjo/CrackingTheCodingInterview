namespace CrackingTheCodingInterview.Tests.DataStructures
{
  using System;
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  [TestClass]
  public class ATrieTests
  {
    [TestMethod]
    public void InitNullTest()
    {
      Action act = () => new ATrie(null);
      act.Should().NotThrow();
    }

    [TestMethod]
    public void InitEmptyTest()
    {
      Action act = () => new ATrie(new List<string>());
      act.Should().NotThrow();
    }

    [TestMethod]
    public void AddWordTest()
    {
      var trie = new ATrie(new List<string>());
      trie.AddWord("Freddy");
      trie.ContainsWord("Freddy").Should().BeTrue();
    }

    [TestMethod]
    public void ContainsPrefixTest()
    {
      var trie = new ATrie(new List<string>());
      trie.AddWord("Freddy");
      trie.ContainsPrefix("Fred").Should().BeTrue();
      trie.ContainsPrefix("Freddy").Should().BeTrue();
    }

    [TestMethod]
    public void ContainsWordTest()
    {
      var trie = new ATrie(new List<string>());
      trie.AddWord("Freddy");
      trie.ContainsWord("Fred").Should().BeFalse();
      trie.ContainsWord("Freddy").Should().BeTrue();
    }
  }
}
