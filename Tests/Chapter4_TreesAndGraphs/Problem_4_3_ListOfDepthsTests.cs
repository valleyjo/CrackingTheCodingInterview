namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Tests
{
  using System;
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Problem_4_3_ListOfDepths;

  [TestClass]
  public class Problem_4_3_ListOfDepthsTests
  {
    [TestMethod]
    public void BuildDepthDictionary_EmptyTest() => Solution.BuildDepthDictionary(null).Should().BeEquivalentTo(new Dictionary<int, List<int>>());

    [TestMethod]
    public void BuildDepthDictionary_OneNodeTest()
    {
      var tree = new ABinaryTreeNode(1);
      var expected = new Dictionary<int, List<ABinaryTreeNode>>()
      {
        { 0, new List<ABinaryTreeNode>() { new ABinaryTreeNode(1), } },
      };

      Solution.BuildDepthDictionary(tree).Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void BuildDepthDictionary_ManyNodesTest()
    {
      var tree = new ABinaryTreeNode(3);
      tree.Left = new ABinaryTreeNode(1);
      tree.Left.Right = new ABinaryTreeNode(2);
      tree.Right = new ABinaryTreeNode(5);
      tree.Right.Left = new ABinaryTreeNode(4);
      tree.Right.Right = new ABinaryTreeNode(6);

      var expected = new Dictionary<int, List<ABinaryTreeNode>>()
      {
        { 0, new List<ABinaryTreeNode>() { new ABinaryTreeNode(3), } },
        { 1, new List<ABinaryTreeNode>() { new ABinaryTreeNode(1), new ABinaryTreeNode(5) } },
        { 2, new List<ABinaryTreeNode>() { new ABinaryTreeNode(2), new ABinaryTreeNode(4), new ABinaryTreeNode(6), } },
      };

      Solution.BuildDepthDictionary(tree).Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void BuildDepthMap_EmptyTest() => Solution.BuildDepthMap(null).Should().BeEquivalentTo(new Solution.DepthMap());

    [TestMethod]
    public void BuildDepthMap_OneNodeTest()
    {
      var tree = new ABinaryTreeNode(1);
      var expected = new Solution.DepthMap();
      expected.AddOrUpdate(0, new ABinaryTreeNode(1));
      Solution.BuildDepthMap(tree).Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void BuildDepthMap_ManyNodesTest()
    {
      var tree = new ABinaryTreeNode(3);
      tree.Left = new ABinaryTreeNode(1);
      tree.Left.Right = new ABinaryTreeNode(2);
      tree.Right = new ABinaryTreeNode(5);
      tree.Right.Left = new ABinaryTreeNode(4);
      tree.Right.Right = new ABinaryTreeNode(6);

      var expected = new Solution.DepthMap();
      expected.AddOrUpdate(0, new ABinaryTreeNode(3));
      expected.AddOrUpdate(1, new ABinaryTreeNode(1));
      expected.AddOrUpdate(1, new ABinaryTreeNode(5));
      expected.AddOrUpdate(2, new ABinaryTreeNode(2));
      expected.AddOrUpdate(2, new ABinaryTreeNode(4));
      expected.AddOrUpdate(2, new ABinaryTreeNode(6));

      Solution.BuildDepthDictionary(tree).Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void BuildDepthMapLessMemory_EmptyTest() => Solution.BuildDepthMapLessMemory(null).Should().BeEquivalentTo(new Solution.DepthMap());

    [TestMethod]
    public void BuildDepthMapLessMemory_OneNodeTest()
    {
      var tree = new ABinaryTreeNode(1);
      var expected = new Solution.DepthMap();
      expected.AddOrUpdate(0, new ABinaryTreeNode(1));
      Solution.BuildDepthMapLessMemory(tree).Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void BuildDepthMapLessMemory_ManyNodesTest()
    {
      var tree = new ABinaryTreeNode(3);
      tree.Left = new ABinaryTreeNode(1);
      tree.Left.Right = new ABinaryTreeNode(2);
      tree.Right = new ABinaryTreeNode(5);
      tree.Right.Left = new ABinaryTreeNode(4);
      tree.Right.Right = new ABinaryTreeNode(6);

      var expected = new Solution.DepthMap();
      expected.AddOrUpdate(0, new ABinaryTreeNode(3));
      expected.AddOrUpdate(1, new ABinaryTreeNode(1));
      expected.AddOrUpdate(1, new ABinaryTreeNode(5));
      expected.AddOrUpdate(2, new ABinaryTreeNode(2));
      expected.AddOrUpdate(2, new ABinaryTreeNode(4));
      expected.AddOrUpdate(2, new ABinaryTreeNode(6));

      Solution.BuildDepthMapLessMemory(tree).Should().BeEquivalentTo(expected);
    }
  }
}
