namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs
{
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Problem_4_10_CheckSubtree;

  [TestClass]
  public class Problem_4_10_CheckSubtreeTests
  {
    [TestMethod]
    public void NullTreeTest() => Solution.Execute(null, new ABinaryTreeNode(1)).Should().BeFalse();

    [TestMethod]
    public void NullSubTreeTest() => Solution.Execute(new ABinaryTreeNode(1), null).Should().BeFalse();

    [TestMethod]
    public void BothNullTest() => Solution.Execute(null, null).Should().BeFalse();

    [TestMethod]
    public void SingleNodeTest() => Solution.Execute(new ABinaryTreeNode(1), new ABinaryTreeNode(1)).Should().BeTrue();

    [TestMethod]
    public void Small_MatchesOnLeft()
    {
      var tree = new ABinaryTreeNode(1);
      tree.Left = new ABinaryTreeNode(2);
      var subtree = new ABinaryTreeNode(2);

      Solution.Execute(tree, subtree).Should().BeTrue();
    }

    [TestMethod]
    public void Small_MatchesOnRight()
    {
      var tree = new ABinaryTreeNode(1);
      tree.Right = new ABinaryTreeNode(2);
      var subtree = new ABinaryTreeNode(2);

      Solution.Execute(tree, subtree).Should().BeTrue();
    }

    [TestMethod]
    public void TwoPartialMatchesTest()
    {
      var tree = new ABinaryTreeNode(1);

      tree.Right = new ABinaryTreeNode(
        value: 2,
        new ABinaryTreeNode(20),
        new ABinaryTreeNode(7));

      tree.Left = new ABinaryTreeNode(
        value: 2,
        right: new ABinaryTreeNode(7));

      var subtree = new ABinaryTreeNode(
        value: 2,
        new ABinaryTreeNode(20),
        new ABinaryTreeNode(7));

      Solution.Execute(tree, subtree).Should().BeTrue();
    }
  }
}
