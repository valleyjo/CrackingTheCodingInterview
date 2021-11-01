namespace CrackingTheCodingInterview.Problems.Chapter17_Hard.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter17_Hard.Problem_17_12_BiNode;

  [TestClass]
  public class Problem_17_12_BiNodeTests
  {
    [TestMethod]
    public void NullTest()
    {
      Solution.Execute(null).Should().Be(null);
      Solution.ExecuteWithCopy(null).Should().Be(null);
    }

    [TestMethod]
    public void SingleNodeTest()
    {
      Solution.Execute(new Solution.BiNode(5)).ToListString().Should().Be("5");
      Solution.ExecuteWithCopy(new Solution.BiNode(5)).ToListString().Should().Be("5");
    }

    [TestMethod]
    public void RecursiveTest()
    {
      var root = new Solution.BiNode(
        50,
        //// right side
        new Solution.BiNode(
          25,
          new Solution.BiNode(
            12,
            two: new Solution.BiNode(20)),
          new Solution.BiNode(
            35,
            new Solution.BiNode(
              30,
              two: new Solution.BiNode(33)))),
        //// left side
        new Solution.BiNode(
          75,
          new Solution.BiNode(65),
          new Solution.BiNode(100)));

      Solution.Execute(root).ToListString().Should().Be("12 -> 20 -> 25 -> 30 -> 33 -> 35 -> 50 -> 65 -> 75 -> 100");
    }

    [TestMethod]
    public void WithCopyTest()
    {
      var root = new Solution.BiNode(
        50,
        //// right side
        new Solution.BiNode(
          25,
          new Solution.BiNode(
            12,
            two: new Solution.BiNode(20)),
          new Solution.BiNode(
            35,
            new Solution.BiNode(
              30,
              two: new Solution.BiNode(33)))),
        //// left side
        new Solution.BiNode(
          75,
          new Solution.BiNode(65),
          new Solution.BiNode(100)));

      Solution.ExecuteWithCopy(root).ToListString().Should().Be("12 -> 20 -> 25 -> 30 -> 33 -> 35 -> 50 -> 65 -> 75 -> 100");
    }
  }
}
