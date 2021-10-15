namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Problem_10_11_PeaksAndValleys;

  [TestClass]
  public class Problem_10_11_PeaksAndValleysTests
  {
    [TestMethod]
    public void EmptyTest()
    {
      Solution.Execute(Array.Empty<int>()).Should().BeEquivalentTo(Array.Empty<int>());
      Solution.ExecuteFaster(Array.Empty<int>()).Should().BeEquivalentTo(Array.Empty<int>());
    }

    [TestMethod]
    public void SizeOneTest()
    {
      Solution.Execute(new int[] { 0 }).Should().BeEquivalentTo(new int[] { 0 });
      Solution.ExecuteFaster(new int[] { 0 }).Should().BeEquivalentTo(new int[] { 0 });
    }

    [TestMethod]
    public void SizeTwoTest()
    {
      Solution.Execute(new int[] { 0, 1, }).Should().BeEquivalentTo(new int[] { 0, 1 });
      Solution.ExecuteFaster(new int[] { 0, 1, }).Should().BeEquivalentTo(new int[] { 0, 1 });
    }

    [TestMethod]
    public void SizeThreeTest()
    {
      Solution.Execute(new int[] { 0, 1, 3, }).Should().BeEquivalentTo(new int[] { 0, 3, 1, });
      Solution.ExecuteFaster(new int[] { 0, 1, 3, }).Should().BeEquivalentTo(new int[] { 0, 3, 1, });
    }

    [TestMethod]
    public void SizeSevenTest()
    {
      Solution.Execute(new int[] { 5, 3, 2, -1, 6, 8, 4 }).Should().BeEquivalentTo(new int[] { 3, 5, 2, 6, -1, 8, 4 });
      Solution.ExecuteFaster(new int[] { 5, 3, 2, -1, 6, 8, 4, }).Should().BeEquivalentTo(new int[] { 3, 5, 2, 6, -1, 8, 4 });
    }
  }
}
