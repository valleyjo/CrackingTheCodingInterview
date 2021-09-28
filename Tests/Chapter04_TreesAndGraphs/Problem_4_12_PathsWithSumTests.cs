namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Tests
{
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Problem_4_12_PathsWithSum;

  [TestClass]
  public class Problem_4_12_PathsWithSumTests
  {
    [TestMethod]
    public void NullTest() => Solution.ExecuteBruteForce(null, 0).Should().Be(0);

    [TestMethod]
    public void OneNodeSumTest() => Solution.ExecuteBruteForce(new ABinaryTreeNode(5), 5).Should().Be(1);

    [TestMethod]
    public void OneNodeNoSumTest() => Solution.ExecuteBruteForce(new ABinaryTreeNode(5), 6).Should().Be(0);

    [TestMethod]
    public void TargetExistsTest()
    {
      var root = new ABinaryTreeNode(5);

      root.Left = new ABinaryTreeNode(2); // 7
      root.Left.Left = new ABinaryTreeNode(0); // 7
      root.Left.Left.Right = new ABinaryTreeNode(7); // 7
      root.Left.Right = new ABinaryTreeNode(12); // 19

      root.Right = new ABinaryTreeNode(-6); // -1
      root.Right.Left = new ABinaryTreeNode(8); // 7
      root.Right.Left.Left = new ABinaryTreeNode(-1); // 7
      root.Right.Left.Right = new ABinaryTreeNode(-1); // 7

      Solution.ExecuteBruteForce(root, 7).Should().Be(7);
    }

    [TestMethod]
    public void TargetNotExistsTest()
    {
      var root = new ABinaryTreeNode(5);

      root.Left = new ABinaryTreeNode(2); // 7
      root.Left.Left = new ABinaryTreeNode(0); // 7
      root.Left.Right = new ABinaryTreeNode(12); // 19

      root.Right = new ABinaryTreeNode(-6); // -1
      root.Right.Left = new ABinaryTreeNode(8); // 7

      Solution.ExecuteBruteForce(root, 40).Should().Be(0);
    }
  }
}
