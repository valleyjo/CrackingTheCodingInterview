namespace CrackingTheCodingInterview.Problems.Chapter2_LinkedLists.Tests
{
  using System;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Problem = Problem_2_5_SumLists;

  [TestClass]
  public class Problem_2_5_SumListsTests
  {
    [TestMethod]
    public void OneNullTest()
    {
      Action act = () => Problem.SumReverse(null, new AListNode<int>(0));
      act.Should().Throw<ArgumentNullException>();
      act = () => Problem.SumForward(null, new AListNode<int>(0));
      act.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void TwoNullTest()
    {
      Action act = () => Problem.SumReverse(new AListNode<int>(0), null);
      act.Should().Throw<ArgumentNullException>();
      act = () => Problem.SumForward(new AListNode<int>(0), null);
      act.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void ZeroTest()
    {
      var one = new AListNode<int>(0);
      var two = new AListNode<int>(0);
      Problem.SumReverse(one, two).ToString().Should().Be("(0)");
      Problem.SumForward(one, two).ToString().Should().Be("(0)");
    }

    [TestMethod]
    public void SumSingleWithCarryTest()
    {
      var one = AListNode<int>.FromArray(new int[] { 9, });
      var two = AListNode<int>.FromArray(new int[] { 2, });
      Problem.SumReverse(one, two).ToString().Should().Be("(1) -> (1)");
      Problem.SumForward(one, two).ToString().Should().Be("(1) -> (1)");
    }

    [TestMethod]
    public void SumLongOne()
    {
      var one = AListNode<int>.FromArray(new int[] { 9, 1, 7, 2, });
      var two = AListNode<int>.FromArray(new int[] { 2, });
      Problem.SumReverse(one, two).ToString().Should().Be("(1) -> (2) -> (7) -> (2)");
    }

    [TestMethod]
    public void SumLongOne_Forward()
    {
      var one = AListNode<int>.FromArray(new int[] { 2, 7, 1, 9, });
      var two = AListNode<int>.FromArray(new int[] { 2, });
      Problem.SumForward(one, two).ToString().Should().Be("(2) -> (7) -> (2) -> (1)");
    }

    [TestMethod]
    public void SumLongTwo()
    {
      var one = AListNode<int>.FromArray(new int[] { 2, });
      var two = AListNode<int>.FromArray(new int[] { 9, 1, 7, 2, });
      Problem.SumReverse(one, two).ToString().Should().Be("(1) -> (2) -> (7) -> (2)");
    }

    [TestMethod]
    public void SumLongTwo_Forward()
    {
      var one = AListNode<int>.FromArray(new int[] { 2, });
      var two = AListNode<int>.FromArray(new int[] { 2, 7, 1, 9, });
      Problem.SumForward(one, two).ToString().Should().Be("(2) -> (7) -> (2) -> (1)");
    }
  }
}
