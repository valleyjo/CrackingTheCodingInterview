namespace CrackingTheCodingInterview.Problems.Chapter17_Hard.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter17_Hard.Problem_17_15_LongestWord;

  [TestClass]
  public class Problem_17_15_LongestWordTests
  {
    [TestMethod]
    public void NullTest()
    {
      Solution.Execute(null).Should().Be(string.Empty);
    }

    [TestMethod]
    public void EmptyTest()
    {
      Solution.Execute(Array.Empty<string>()).Should().Be(string.Empty);
    }

    [TestMethod]
    public void NoLongestWordTest()
    {
      string[] input = { "cat", "freddy", "dog", "smudgie", "do", "walk", };
      Solution.Execute(input).Should().Be(string.Empty);
    }

    [TestMethod]
    public void OneLongestWord()
    {
      string[] input = { "dogwalkher", "cat", "walker", "dog", "her", "do", "walk", "dogwalker", };
      Solution.Execute(input).Should().Be("dogwalkher");
    }
  }
}
