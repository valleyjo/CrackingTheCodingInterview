namespace CrackingTheCodingInterview.Problems.Chapter17_Hard.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter17_Hard.Problem_17_16_Masseuse;

  [TestClass]
  public class Problem_17_16_MasseuseTests
  {
    [TestMethod]
    public void NullTest()
    {
      Solution.Execute(null).Should().Be(-1);
    }

    [TestMethod]
    public void EmptyTest()
    {
      Solution.Execute(Array.Empty<int>()).Should().Be(-1);
    }

    [TestMethod]
    public void BiggestAtEndTest()
    {
      Solution.Execute(new int[] { 1, 2, 4, 2, 5, 60, }).Should().Be(65);
    }

    [TestMethod]
    public void EqualValuesTest()
    {
      Solution.Execute(new int[] { 30, 15, 60, 75, 45, 15, 15, 45 }).Should().Be(180);
    }

    [TestMethod]
    public void OneElementTest()
    {
      Solution.Execute(new int[] { 30, }).Should().Be(30);
    }

    [TestMethod]
    public void TwoElementTest()
    {
      Solution.Execute(new int[] { 30, 15, }).Should().Be(30);
    }
  }
}
