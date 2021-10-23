namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Chapter_16_20_T9;

  [TestClass]
  public class Chapter_16_20_T9Tests
  {
    [TestMethod]
    public void TrieVersionTest()
    {
      var words = new List<string>() { "fred", "smudgie", "cat", "caterpiller", "car", "cap" };
      Solution.Execute("227", words).Should().BeEquivalentTo(new List<string>() { "car", "cap" });
    }

    [TestMethod]
    public void UpFrontConversionTest()
    {
      var words = new List<string>() { "fred", "smudgie", "cat", "caterpiller", "car", "cap" };
      Solution.ExecuteFaster("227", words).Should().BeEquivalentTo(new List<string>() { "car", "cap" });
    }
  }
}
