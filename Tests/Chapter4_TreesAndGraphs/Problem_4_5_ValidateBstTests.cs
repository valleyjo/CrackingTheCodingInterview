namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Tests
{
  using System;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Problem_4_5_ValidateBst;

  [TestClass]
  public class Problem_4_5_ValidateBstTests
  {
    [TestMethod]
    public void NullTest() => Solution.Execute(null).Should().BeTrue();

    [TestMethod]
    public void OneNodeTest() => Solution.Execute(new ABinaryTreeNode(1)).Should().BeTrue();

    [TestMethod]
    public void ValidDuplicatesTest()
    {
      var tree = new ABinaryTreeNode(0);
      tree.Left = new ABinaryTreeNode(0);
      tree.Left.Right = new ABinaryTreeNode(0);
      tree.Left.Left = new ABinaryTreeNode(0);
      tree.Right = new ABinaryTreeNode(10);
      Solution.Execute(tree).Should().BeTrue();
    }

    [TestMethod]
    public void ValidSmallTest()
    {
      var tree = new ABinaryTreeNode(0);
      tree.Left = new ABinaryTreeNode(-10);
      tree.Right = new ABinaryTreeNode(10);
      Solution.Execute(tree).Should().BeTrue();
    }

    [TestMethod]
    public void InvalidSmallTest()
    {
      var tree = new ABinaryTreeNode(0);
      tree.Left = new ABinaryTreeNode(10);
      tree.Right = new ABinaryTreeNode(-10);
      Solution.Execute(tree).Should().BeFalse();
    }

    [TestMethod]
    public void InvalidOnLeftTest()
    {
      var tree = new ABinaryTreeNode(0);
      tree.Left = new ABinaryTreeNode(-10);
      tree.Left.Right = new ABinaryTreeNode(-5);
      tree.Left.Right.Left = new ABinaryTreeNode(-15);
      tree.Right = new ABinaryTreeNode(10);
      Solution.Execute(tree).Should().BeFalse();
    }

    [TestMethod]
    public void InvalidOnRightTest()
    {
      var tree = new ABinaryTreeNode(0);
      tree.Left = new ABinaryTreeNode(-10);
      tree.Left.Right = new ABinaryTreeNode(-5);
      tree.Left.Right.Left = new ABinaryTreeNode(-15);
      tree.Right = new ABinaryTreeNode(10);
      tree.Right.Left = new ABinaryTreeNode(15);
      Solution.Execute(tree).Should().BeFalse();
    }

    [TestMethod]
    public void ValidTest()
    {
      var tree = new ABinaryTreeNode(0);
      tree.Left = new ABinaryTreeNode(-10);
      tree.Left.Right = new ABinaryTreeNode(-5);
      tree.Left.Right.Left = new ABinaryTreeNode(-7);
      tree.Right = new ABinaryTreeNode(10);
      Solution.Execute(tree).Should().BeTrue();
    }
  }
}
