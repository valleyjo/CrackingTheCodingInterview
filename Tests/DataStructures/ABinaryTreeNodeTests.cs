namespace CrackingTheCodingInterview.Tests.DataStructures
{
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  [TestClass]
  public class ABinaryTreeNodeTests
  {
    [TestMethod]
    public void GetHeightOneTest()
    {
      var node = new ABinaryTreeNode(0);
      node.GetHeight().Should().Be(1);
    }

    [TestMethod]
    public void GetHeightLeftTallerTest()
    {
      /*
          1
         / \
        2   2
       /     \
      3       3
       \
        4
       */
      var node = new ABinaryTreeNode(1);
      node.Left = new ABinaryTreeNode(2);
      node.Right = new ABinaryTreeNode(2);
      node.Right.Right = new ABinaryTreeNode(3);
      node.Left.Left = new ABinaryTreeNode(3);
      node.Left.Left.Right = new ABinaryTreeNode(4);

      node.GetHeight().Should().Be(4);
    }

    [TestMethod]
    public void GetHeightRightTallerTest()
    {
      /*
          1
         / \
        2   2
       /     \
      3       3
             /
            4
       */
      var node = new ABinaryTreeNode(1);
      node.Left = new ABinaryTreeNode(2);
      node.Right = new ABinaryTreeNode(2);
      node.Right.Right = new ABinaryTreeNode(3);
      node.Left.Left = new ABinaryTreeNode(3);
      node.Right.Right.Left = new ABinaryTreeNode(4);

      node.GetHeight().Should().Be(4);
    }

    [TestMethod]
    public void GetHeightBothSidesEqualTest()
    {
      /*
          1
         / \
        2   2
       /   / \
      3   3   3
       */
      var node = new ABinaryTreeNode(1);
      node.Left = new ABinaryTreeNode(2);
      node.Right = new ABinaryTreeNode(2);
      node.Right.Right = new ABinaryTreeNode(3);
      node.Right.Left = new ABinaryTreeNode(3);
      node.Left.Left = new ABinaryTreeNode(3);
      node.Right.Right = new ABinaryTreeNode(3);

      node.GetHeight().Should().Be(3);
    }

    [TestMethod]
    public void EqualsWrongObjTypeTest()
    {
      var node = new ABinaryTreeNode(1);
      node.Equals(new AGraph()).Should().BeFalse();
    }

    [TestMethod]
    public void EqualsRightTypeWrongValueTest()
    {
      var node = new ABinaryTreeNode(1);
      node.Equals(new ABinaryTreeNode(5)).Should().BeFalse();
    }

    [TestMethod]
    public void EqualsShouldMatchTest()
    {
      var node = new ABinaryTreeNode(1);
      node.Equals(new ABinaryTreeNode(1)).Should().BeTrue();
    }
  }
}
