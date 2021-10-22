namespace CrackingTheCodingInterview.Problems.Tests.Chapter16_Moderate
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Chapter_16_15_MasterMind;

  [TestClass]
  public class Chapter_16_14_MasterMindTests
  {
    [TestMethod]
    public void EmptyTest()
    {
      Solution.Execute(string.Empty, string.Empty).Should().BeEquivalentTo(new Solution.Result(-1, -1));
    }

    [TestMethod]
    public void SameTest()
    {
      Solution.Execute("rrrr", "rrrr").Should().BeEquivalentTo(new Solution.Result(4, 0));
    }

    [TestMethod]
    public void NoHitsTest()
    {
      Solution.Execute("rrrr", "gggg").Should().BeEquivalentTo(new Solution.Result(0, 0));
    }

    [TestMethod]
    public void AllPseudoHitsTest()
    {
      Solution.Execute("rgby", "yrgb").Should().BeEquivalentTo(new Solution.Result(0, 4));
    }

    [TestMethod]
    public void BothHitsTest()
    {
      Solution.Execute("rgbb", "rbyy").Should().BeEquivalentTo(new Solution.Result(1, 1));
    }

    [TestMethod]
    public void InvalidLengthTest()
    {
      Solution.Execute("rgbba", "rbyy").Should().BeEquivalentTo(new Solution.Result(-1, -1));
    }

    [TestMethod]
    public void InvalidCharTest()
    {
      Action act = () => Solution.Execute("rgab", "rbyy");
      act.Should().Throw<ArgumentException>();
    }
  }
}
