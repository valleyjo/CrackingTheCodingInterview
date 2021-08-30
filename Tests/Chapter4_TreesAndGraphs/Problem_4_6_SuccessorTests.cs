namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Tests
{
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Problem_4_6_Successor;

  [TestClass]
  public class Problem_4_6_SuccessorTests
  {
    [TestMethod]
    public void NullTest() => Solution.Execute(null).Should().BeNull();

    [TestMethod]
    public void OneNodeTest() => Solution.Execute(new ABinaryTreeNode(1)).Should().BeNull();

    [TestMethod]
    public void InRightSideTest()
    {
      var tree = new ABinaryTreeNode(0);
      tree.Right = new ABinaryTreeNode(10);
      tree.Right.Right = new ABinaryTreeNode(15);
      tree.Right.Left = new ABinaryTreeNode(7);
      Solution.Execute(tree).Should().BeSameAs(tree.Right.Left);
    }

    [TestMethod]
    public void InLeftSideTest()
    {
      var tree = new ABinaryTreeNode(0);
      tree.Left = new ABinaryTreeNode(-10);
      tree.Left.Right = new ABinaryTreeNode(-10);
      tree.Left.Left = new ABinaryTreeNode(-15);
      Solution.Execute(tree).Should().BeNull();
    }

    [TestMethod]
    public void AllNodesVisitedTest()
    {
      var tree = new ABinaryTreeNode(0);
      tree.Right = new ABinaryTreeNode(10);
      tree.Right.Right = new ABinaryTreeNode(20);
      Solution.Execute(tree.Right.Right).Should().BeNull();
    }
  }
}
