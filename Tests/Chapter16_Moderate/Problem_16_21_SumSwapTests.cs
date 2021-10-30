namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Problem_16_21_SumSwap;

  [TestClass]
  public class Problem_16_21_SumSwapTests
  {
    [TestMethod]
    public void OneElementTest()
    {
      Solution.Execute(new int[] { 1 }, new int[] { 0 }).Should().BeEquivalentTo(Array.Empty<int>());
    }

    [TestMethod]
    public void TwoElementTest()
    {
      Solution.Execute(new int[] { 1, 2, }, new int[] { 1, 0, }).Should().BeEquivalentTo(new int[] { 1, 0, }, (c) => c.WithoutStrictOrdering());
    }

    [TestMethod]
    public void HappyPathTest()
    {
      Solution.Execute(new int[] { 3, 6, 3, 3, }, new int[] { 4, 1, 2, 1, 1, 2, }).Should().BeEquivalentTo(new int[] { 1, 3, }, (c) => c.WithoutStrictOrdering());
    }

    [TestMethod]
    public void NoElementTest()
    {
      Solution.Execute(new int[] { 1, 2, 6, 8, 13, }, new int[] { -1, -45, 5, 8, }).Should().BeEquivalentTo(Array.Empty<int>());
    }

    [TestMethod]
    public void AlreadyValidTest()
    {
      Solution.Execute(new int[] { 1, 2, 6, 8, 13, }, new int[] { 13, 8, 6, 2, 1, }).Should().BeEquivalentTo(new int[] { 1, 1 }, (c) => c.WithoutStrictOrdering());
    }
  }
}
