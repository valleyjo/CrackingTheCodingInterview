namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Problem_4_11_RandomNode;

  [TestClass]
  public class Problem_4_11_RandomNodeTests
  {
    [TestMethod]
    public void RandomBinaryTreeNode_RightTest()
    {
      var tree = new Solution();
      tree.Insert(1);
      tree.Insert(2);
      tree.Insert(3);

      Solution.RandomBinaryTreeNode node = tree.Find(1);

      node.Right.Value.Should().Be(3);
      node.Right.Right.Should().BeNull();
    }

    [TestMethod]
    public void RandomBinaryTreeNode_RightNullTest()
    {
      var tree = new Solution();
      tree.Insert(1);
      tree.Insert(2);
      tree.Insert(3);

      Solution.RandomBinaryTreeNode node = tree.Find(1);

      node.Right.Right.Should().BeNull();
    }

    [TestMethod]
    public void RandomBinaryTreeNode_LeftTest()
    {
      var tree = new Solution();
      tree.Insert(1);
      tree.Insert(2);
      tree.Insert(3);

      Solution.RandomBinaryTreeNode node = tree.Find(1);

      node.Left.Value.Should().Be(2);
    }

    [TestMethod]
    public void RandomBinaryTreeNode_LeftNullTest()
    {
      var tree = new Solution();
      tree.Insert(1);
      tree.Insert(2);
      tree.Insert(3);

      Solution.RandomBinaryTreeNode node = tree.Find(1);

      node.Left.Left.Should().BeNull();
    }

    [TestMethod]
    public void RandomNode_FindNullTest()
    {
      var tree = new Solution();
      tree.Insert(1);
      tree.Insert(2);
      tree.Insert(3);

      Solution.RandomBinaryTreeNode node = tree.Find(10);

      node.Should().BeNull();
    }

    [TestMethod]
    public void RandomNode_DeleteNothingtest()
    {
      var tree = new Solution();
      tree.Insert(1);

      tree.Delete(10).Should().BeFalse();
    }

    [TestMethod]
    public void RandomNode_DeleteOnlyOneTest()
    {
      var tree = new Solution();
      tree.Insert(1);

      tree.Delete(1).Should().BeTrue();
      tree.Find(1).Should().BeNull();
    }

    [TestMethod]
    public void RandomNode_DeleteMiddleTest()
    {
      var tree = new Solution();
      tree.Insert(1);
      tree.Insert(2);
      tree.Insert(3);
      tree.Insert(4);
      tree.Insert(5);
      tree.Insert(6);

      Solution.RandomBinaryTreeNode node = tree.Find(1);
      node.Left.Value.Should().Be(2);

      tree.Delete(2).Should().BeTrue();
      tree.Find(2).Should().BeNull();

      node.Left.Value.Should().Be(6);
    }

    [TestMethod]
    public void RandomNode_GetRandomNodeTest()
    {
      var tree = new Solution();
      tree.Insert(1);
      tree.Insert(2);
      tree.Insert(3);
      tree.Insert(4);
      tree.Insert(5);
      tree.Insert(6);

      Solution.RandomBinaryTreeNode node = tree.GetRandomNode();
      node.Should().NotBeNull();
      node.Value.Should().BeGreaterOrEqualTo(1);
      node.Value.Should().BeLessOrEqualTo(6);
    }
  }
}
