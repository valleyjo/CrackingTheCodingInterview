namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Tests
{
  using System;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Problem_4_04_CheckBalanced;

  [TestClass]
  public class Problem_4_04_CheckBalancedTests
  {
    [TestMethod]
    public void Naive_NullTest() => Solution.ExecuteNaive(null).Should().BeTrue();

    [TestMethod]
    public void Naive_FullTreeTest() => FullTreeTest(Solution.ExecuteNaive);

    [TestMethod]
    public void Naive_WithinBoundsTest() => WithinBoundsTest(Solution.ExecuteNaive);

    [TestMethod]
    public void Naive_OutOfBoundsTest() => OutOfBoundsTest(Solution.ExecuteNaive);

    [TestMethod]
    public void Struct_NullTest() => Solution.ExecuteOptimizedStructReturn(null).Should().BeTrue();

    [TestMethod]
    public void StructFaster_FullTreeTest() => FullTreeTest(Solution.ExecuteOptimizedStructReturn);

    [TestMethod]
    public void StructFaster_WithinBoundsTest() => WithinBoundsTest(Solution.ExecuteOptimizedStructReturn);

    [TestMethod]
    public void StructFaster_OutOfBoundsTest() => OutOfBoundsTest(Solution.ExecuteOptimizedStructReturn);

    [TestMethod]
    public void Class_NullTest() => Solution.ExecuteOptimizedClassReturn(null).Should().BeTrue();

    [TestMethod]
    public void Class_FullTreeTest() => FullTreeTest(Solution.ExecuteOptimizedClassReturn);

    [TestMethod]
    public void Class_WithinBoundsTest() => WithinBoundsTest(Solution.ExecuteOptimizedClassReturn);

    [TestMethod]
    public void Class_OutOfBoundsTest() => OutOfBoundsTest(Solution.ExecuteOptimizedClassReturn);

    [TestMethod]
    public void Int_NullTest() => Solution.ExecuteOptimizedIntReturn(null).Should().BeTrue();

    [TestMethod]
    public void Int_FullTreeTest() => FullTreeTest(Solution.ExecuteOptimizedIntReturn);

    [TestMethod]
    public void Int_WithinBoundsTest() => WithinBoundsTest(Solution.ExecuteOptimizedIntReturn);

    [TestMethod]
    public void Int_OutOfBoundsTest() => OutOfBoundsTest(Solution.ExecuteOptimizedIntReturn);

    private static void FullTreeTest(Func<ABinaryTreeNode, bool> solution)
    {
      var tree = new ABinaryTreeNode(1);
      tree.Left = new ABinaryTreeNode(2);
      tree.Right = new ABinaryTreeNode(2);
      solution(tree).Should().BeTrue();
    }

    private static void WithinBoundsTest(Func<ABinaryTreeNode, bool> solution)
    {
      var tree = new ABinaryTreeNode(1);
      tree.Left = new ABinaryTreeNode(2);
      tree.Left.Right = new ABinaryTreeNode(3);
      tree.Right = new ABinaryTreeNode(2);
      solution(tree).Should().BeTrue();
    }

    private static void OutOfBoundsTest(Func<ABinaryTreeNode, bool> solution)
    {
      var tree = new ABinaryTreeNode(1);
      tree.Left = new ABinaryTreeNode(2);
      tree.Left.Right = new ABinaryTreeNode(3);
      tree.Left.Right.Left = new ABinaryTreeNode(4);
      tree.Right = new ABinaryTreeNode(2);
      solution(tree).Should().BeFalse();
    }
  }
}
