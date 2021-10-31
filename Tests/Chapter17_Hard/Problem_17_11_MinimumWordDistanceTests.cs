namespace CrackingTheCodingInterview.Problems.Chapter17_Hard.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter17_Hard.Problem_17_11_MinimumWordDistance;

  [TestClass]
  public class Problem_17_11_MinimumWordDistance
  {
    [TestMethod]
    public void WordsParamTest()
    {
      Solution.Execute(null, "Fred", "Smudgie").Should().Be(-1);
      Solution.Execute(Array.Empty<string>(), "Smudgie", "Smudgie").Should().Be(-1);
    }

    [TestMethod]
    public void WordOneParamTest()
    {
      Solution.Execute(new string[] { "Smudgie", "Freddy", }, null, "Smudgie").Should().Be(-1);
      Solution.Execute(new string[] { "Smudgie", "Freddy", }, string.Empty, "Smudgie").Should().Be(-1);
    }

    [TestMethod]
    public void WordTwoParamTest()
    {
      Solution.Execute(new string[] { "Smudgie", "Freddy", }, "Smudgie", null).Should().Be(-1);
      Solution.Execute(new string[] { "Smudgie", "Freddy", }, "Smudgie", string.Empty).Should().Be(-1);
    }

    [TestMethod]
    public void WordOneNotExistTest()
    {
      string[] words = "freddy the cat loves to play with the bird toy smudgie the cat loves to be with his food freddy the cat loves treats".Split(" ");
      Solution.Execute(words, "joey", "freddy").Should().Be(-1);
    }

    [TestMethod]
    public void WordTwoNotExistTest()
    {
      string[] words = "freddy the cat loves to play with the bird toy smudgie the cat loves to be with his food freddy the cat loves treats".Split(" ");
      Solution.Execute(words, "freddy", "joey").Should().Be(-1);
    }

    [TestMethod]
    public void MinDistanceFoundTest()
    {
      string[] words = "freddy the cat loves to play with the bird toy smudgie the cat loves to lay and play freddy the cat loves treats smudgie and freddy the cat are brothers".Split(" ");
      Solution.Execute(words, "cat", "play").Should().Be(3);
      Solution.Execute(words, "play", "cat").Should().Be(3);
    }
  }
}
