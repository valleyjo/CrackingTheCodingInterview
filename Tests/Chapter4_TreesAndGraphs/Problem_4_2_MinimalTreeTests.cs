namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Tests
{
  using System;
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Problem_4_2_MinimalTree;

  [TestClass]
  public class Problem_4_2_MinimalTreeTests
  {
    [TestMethod]
    public void NullTest()
    {
      Action act = () => Solution.Execute(null);
      act.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void EmptyTest()
    {
      Action act = () => Solution.Execute(new List<int>());
      act.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void OneElementTest()
    {
      var expected = new ABinaryTreeNode(1);
      var input = new List<int>() { 1, };
      Solution.Execute(input).Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void TwoElementsTest()
    {
      var expected = new ABinaryTreeNode(1);
      expected.Right = new ABinaryTreeNode(2);
      var input = new List<int>() { 1, 2, };
      Solution.Execute(input).Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void ThreeElementsTest()
    {
      var expected = new ABinaryTreeNode(2);
      expected.Right = new ABinaryTreeNode(3);
      expected.Left = new ABinaryTreeNode(1);
      var input = new List<int>() { 1, 2, 3, };
      Solution.Execute(input).Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void ManyElementsTest()
    {
      /*
        _3_
       /   \
      1     5
       \   / \
        2 4   6
      */
      var expected = new ABinaryTreeNode(3);

      // Left side
      expected.Left = new ABinaryTreeNode(1);
      expected.Left.Right = new ABinaryTreeNode(2);

      // Right side
      expected.Right = new ABinaryTreeNode(5);
      expected.Right.Left = new ABinaryTreeNode(4);
      expected.Right.Right = new ABinaryTreeNode(6);

      var input = new List<int>() { 1, 2, 3, 4, 5, 6, };
      Solution.Execute(input).Should().BeEquivalentTo(expected);
    }
  }
}
