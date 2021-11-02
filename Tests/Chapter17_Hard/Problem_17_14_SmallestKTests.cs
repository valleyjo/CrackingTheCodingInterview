namespace CrackingTheCodingInterview.Problems.Chapter17_Hard.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter17_Hard.Problem_17_14_SmallestK;

  [TestClass]
  public class Problem_17_14_SmallestKTests
  {
    [TestMethod]
    public void NullTest()
    {
      Solution.Execute(null, 1).Should().BeEquivalentTo(new List<int>());
    }

    [TestMethod]
    public void EmptyTest()
    {
      Solution.Execute(Array.Empty<int>(), 1).Should().BeEquivalentTo(new List<int>());
    }

    [TestMethod]
    public void BadKTest()
    {
      Solution.Execute(new int[] { 1, 2, 3, 4, }, -5).Should().BeEquivalentTo(new List<int>());
    }

    [TestMethod]
    public void SortedAscendingTest()
    {
      Solution.Execute(new int[] { 1, 2, 3, 4, }, 2).Should().BeEquivalentTo(new List<int>() { 1, 2, });
    }

    [TestMethod]
    public void SortedDescendingTest()
    {
      Solution.Execute(new int[] { 5, 4, 3, 2, }, 3).Should().BeEquivalentTo(new List<int>() { 2, 3, 4, });
    }

    [TestMethod]
    public void NotSortedTest()
    {
      Solution.Execute(new int[] { 50, 12, 3, 9, 15, -40, 17 }, 4).Should().BeEquivalentTo(new List<int>() { -40, 3, 9, 12, });
    }

    [TestMethod]
    public void KSmallerThanLength()
    {
      Solution.Execute(new int[] { 50, 12, 3, 9, 15, -40, 17 }, 8).Should().BeEquivalentTo(new List<int>() { 50, 12, 3, 9, 15, -40, 17 });
    }
  }
}
