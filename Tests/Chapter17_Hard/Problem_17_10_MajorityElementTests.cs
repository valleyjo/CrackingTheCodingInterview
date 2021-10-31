namespace CrackingTheCodingInterview.Problems.Chapter17_Hard.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter17_Hard.Problem_17_10_MajorityElement;

  [TestClass]
  public class Problem_17_10_MajorityElementTests
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
    public void OneElementTest()
    {
      Solution.Execute(new int[] { 0 }).Should().Be(0);
    }

    [TestMethod]
    public void NoMajorityElementTest()
    {
      Solution.Execute(new int[] { 0, 1, 2, 3, 4, 5, }).Should().Be(-1);
    }

    [TestMethod]
    public void RepeatedElementTest()
    {
      Solution.Execute(new int[] { 0, 0, 0, 0, 0, 0, }).Should().Be(0);
    }

    [TestMethod]
    public void MajorityElementTest()
    {
      Solution.Execute(new int[] { 1, 2, 5, 9, 5, 9, 5, 5, 5, }).Should().Be(5);
    }

    [TestMethod]
    public void OneUnderMajorityElementTest()
    {
      Solution.Execute(new int[] { 1, 2, 5, 9, 5, 9, 5, 5, 9, }).Should().Be(-1);
    }
  }
}
