namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Tests
{
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Problem_4_8_FirstCommonAncestor;

  [TestClass]
  public class Problem_4_8_LeastCommonAncestorTests
  {
    [TestMethod]
    public void NullTest()
    {
      Solution.Execute(1, 2, null).Should().BeNull();
    }

    [TestMethod]
    public void OneNodeFoundTest()
    {
      Solution.Execute(5, 5, new ABinaryTreeNode(5)).Should().Be(new ABinaryTreeNode(5));
    }

    [TestMethod]
    public void OneNodeNotFoundTest()
    {
      Solution.Execute(5, 1, new ABinaryTreeNode(5)).Should().BeNull();
      Solution.Execute(1, 5, new ABinaryTreeNode(5)).Should().BeNull();
    }

    [TestMethod]
    public void BigTreeTest()
    {
      var tree = new ABinaryTreeNode(10);
      tree.Left = new ABinaryTreeNode(1);
      tree.Right = new ABinaryTreeNode(20);
      tree.Right.Left = new ABinaryTreeNode(30);
      tree.Right.Right = new ABinaryTreeNode(40);
      tree.Right.Right.Right = new ABinaryTreeNode(50);
      Solution.Execute(50, 30, tree).Should().BeEquivalentTo(new ABinaryTreeNode(20));
    }

    [TestMethod]
    public void Optimal_NullTest()
    {
      Solution.ExecuteOptimal(1, 2, null).Should().BeNull();
    }

    [TestMethod]
    public void Optimal_OneNodeFoundTest()
    {
      Solution.ExecuteOptimal(5, 5, new ABinaryTreeNode(5)).Should().Be(new ABinaryTreeNode(5));
    }

    [TestMethod]
    public void Optimal_OneNodeNotFoundTest()
    {
      Solution.ExecuteOptimal(5, 1, new ABinaryTreeNode(5)).Should().BeNull();
      Solution.ExecuteOptimal(1, 5, new ABinaryTreeNode(5)).Should().BeNull();
    }

    [TestMethod]
    public void Optimal_BigTreeTest()
    {
      var tree = new ABinaryTreeNode(10);
      tree.Left = new ABinaryTreeNode(1);
      tree.Right = new ABinaryTreeNode(20);
      tree.Right.Left = new ABinaryTreeNode(30);
      tree.Right.Right = new ABinaryTreeNode(40);
      tree.Right.Right.Right = new ABinaryTreeNode(50);
      Solution.ExecuteOptimal(50, 30, tree).Should().BeEquivalentTo(new ABinaryTreeNode(20));
    }
  }
}
