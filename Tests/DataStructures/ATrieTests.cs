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

    [TestMethod]
    public void ShortestUniquePrefix_OneWordTest()
    {
      var trie = new ATrie();
      trie.AddWord("dove");
      trie.GetShortestUniquePrefix("dove").Should().Be("d");
    }

    [TestMethod]
    public void ShortestUniquePrefix_DoesNotExistTest()
    {
      var trie = new ATrie();
      trie.GetShortestUniquePrefix("dove").Should().Be(string.Empty);
    }

    [TestMethod]
    public void ShortestUniquePrefix_TwoWordsSamePrefixTest()
    {
      var trie = new ATrie();
      trie.AddWord("broom");
      trie.AddWord("brown");
      trie.GetShortestUniquePrefix("broom").Should().Be("broo");
      trie.GetShortestUniquePrefix("brown").Should().Be("brow");
    }

    [TestMethod]
    public void ShortestUniquePrefix_WordIsPrefixOfOtherTest()
    {
      var trie = new ATrie();
      trie.AddWord("brown");
      trie.AddWord("brow");
      trie.GetShortestUniquePrefix("brown").Should().Be("brown");
      trie.GetShortestUniquePrefix("brow").Should().Be("brow");
      trie.GetShortestUniquePrefix("bro").Should().Be("bro");
    }
  }
}
