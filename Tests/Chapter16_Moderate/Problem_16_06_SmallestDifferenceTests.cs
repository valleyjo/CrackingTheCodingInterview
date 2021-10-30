namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Problem_16_06_SmallestDifference;

  [TestClass]
  public class Problem_16_06_SmallestDifferenceTests
  {
    [TestMethod]
    public void OneTest()
    {
      Solution.Execute(new int[] { 5 }, new int[] { 9 }).Should().Be(4);
    }

    [TestMethod]
    public void FewNumbersTest()
    {
      Solution.Execute(new int[] { 1, 3, 15, 11, 2, }, new int[] { 23, 127, 235, 19, 8 }).Should().Be(3);
    }
  }
}
