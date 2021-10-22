namespace CrackingTheCodingInterview.Problems.Tests.Chapter16_Moderate
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Range = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Chapter_16_16_SubSort.Range;
  using Solution = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Chapter_16_16_SubSort;

  [TestClass]
  public class Chapter_16_16_SubSortTests
  {
    [TestMethod]
    public void EmptyTest()
    {
      Solution.Execute(Array.Empty<int>()).Should().BeEquivalentTo(new Range(-1, -1));
    }

    [TestMethod]
    public void NullTest()
    {
      Solution.Execute(null).Should().BeEquivalentTo(new Range(-1, -1));
    }

    [TestMethod]
    public void AlreadySorted()
    {
      Solution.Execute(new int[] { 0, 1, 2, 3, 4, 5, }).Should().BeEquivalentTo(new Range(-1, -1));
    }

    [TestMethod]
    public void EntireRangeTest()
    {
      Solution.Execute(new int[] { 5, 4, 3, 2, 1, }).Should().BeEquivalentTo(new Range(0, 4));
    }

    [TestMethod]
    public void MiddleRangeTest()
    {
      Solution.Execute(new int[] { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19, }).Should().BeEquivalentTo(new Range(3, 9));
    }
  }
}
