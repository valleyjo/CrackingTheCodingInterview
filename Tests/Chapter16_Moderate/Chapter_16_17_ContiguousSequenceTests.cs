namespace CrackingTheCodingInterview.Problems.Tests.Chapter16_Moderate
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Chapter_16_17_ContiguousSequence;

  [TestClass]
  public class Chapter_16_17_ContiguousSequenceTests
  {
    [TestMethod]
    public void EmptyTest()
    {
      Solution.Execute(Array.Empty<int>()).Should().Be(0);
    }

    [TestMethod]
    public void NullTest()
    {
      Solution.Execute(null).Should().Be(0);
    }

    [TestMethod]
    public void IncreasingTest()
    {
      Solution.Execute(new int[] { 6, 1, 2, 3, 4, 5, }).Should().Be(21);
    }

    [TestMethod]
    public void DecreasingTest()
    {
      Solution.Execute(new int[] { -5, -4, -3, -2, -1, }).Should().Be(-1);
    }

    [TestMethod]
    public void MixedTest()
    {
      Solution.Execute(new int[] { 2, -8, 3, -2, 4, -10, }).Should().Be(5);
    }

    [TestMethod]
    public void SizeOneTest()
    {
      Solution.Execute(new int[] { 2, }).Should().Be(2);
    }

    [TestMethod]
    public void SizeTwoTest()
    {
      Solution.Execute(new int[] { 2, -5, }).Should().Be(2);
    }
  }
}
