namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Chapter_16_19_PondSizes;

  [TestClass]
  public class Chapter_16_18_PondSizesTests
  {
    [TestMethod]
    public void ThreePondTest()
    {
      int[,] grid = new int[,]
      {
        { 0, 2, 1, 0, },
        { 0, 1, 0, 1, },
        { 1, 1, 0, 1, },
        { 0, 1, 0, 1, },
      };

      Solution.Execute(grid).Should().BeEquivalentTo(new List<int> { 2, 4, 1, });
    }

    [TestMethod]
    public void NullTest()
    {
      Solution.Execute(null).Should().BeEquivalentTo(new List<int>());
    }

    [TestMethod]
    public void EmptyTest()
    {
      Solution.Execute(new int[0, 0]).Should().BeEquivalentTo(new List<int>());
    }
  }
}
