namespace CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming.Problem_8_10_PaintFill;

  [TestClass]
  public class Problem_8_10_PaintFillTests
  {
    [TestMethod]
    public void NullTest() => Solution.Execute(new uint[0, 0], 0, 0, 5).Should().BeEquivalentTo(new uint[0, 0]);

    [TestMethod]
    public void EmptyTest() => Solution.Execute(null, 0, 0, 5).Should().BeEquivalentTo(null);

    [TestMethod]
    public void InvalidRowTest()
    {
      uint[,] grid = new uint[5, 5];
      Action a = () => Solution.Execute(grid, 5, 4, 2);
      a.Should().Throw<IndexOutOfRangeException>();
    }

    [TestMethod]
    public void InvalidColTest()
    {
      uint[,] grid = new uint[5, 5];
      Action a = () => Solution.Execute(grid, 4, 5, 2);
      a.Should().Throw<IndexOutOfRangeException>();
    }

    [TestMethod]
    public void ReplaceOneTest()
    {
      uint[,] input = new uint[,]
      {
        { 1, 1, 1, 1, },
        { 1, 1, 5, 1, },
        { 1, 1, 1, 1, },
      };

      uint[,] expected = new uint[,]
      {
        { 1, 1, 1, 1, },
        { 1, 1, 8, 1, },
        { 1, 1, 1, 1, },
      };

      uint[,] actual = Solution.Execute(input, 1, 2, 8);
      actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void ReplaceUntilEdgeTest()
    {
      uint[,] input = new uint[,]
      {
        { 1, 1, 1, 1, },
        { 1, 1, 5, 1, },
        { 1, 1, 5, 5, },
      };

      uint[,] expected = new uint[,]
      {
        { 1, 1, 1, 1, },
        { 1, 1, 8, 1, },
        { 1, 1, 8, 8, },
      };

      uint[,] actual = Solution.Execute(input, 1, 2, 8);
      actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void ReplaceEntireGridTest()
    {
      uint[,] input = new uint[,]
      {
        { 1, 1, 1, 1, },
        { 1, 1, 1, 1, },
        { 1, 1, 1, 1, },
      };

      uint[,] expected = new uint[,]
      {
        { 8, 8, 8, 8, },
        { 8, 8, 8, 8, },
        { 8, 8, 8, 8, },
      };

      uint[,] actual = Solution.Execute(input, 0, 0, 8);
      actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void ReplaceMiddleTest()
    {
      uint[,] input = new uint[,]
      {
        { 1, 1, 1, 1, },
        { 1, 5, 5, 1, },
        { 1, 5, 5, 1, },
        { 1, 1, 1, 1, },
      };

      uint[,] expected = new uint[,]
      {
        { 1, 1, 1, 1, },
        { 1, 8, 8, 1, },
        { 1, 8, 8, 1, },
        { 1, 1, 1, 1, },
      };

      uint[,] actual = Solution.Execute(input, 1, 1, 8);
      actual.Should().BeEquivalentTo(expected);
    }
  }
}
