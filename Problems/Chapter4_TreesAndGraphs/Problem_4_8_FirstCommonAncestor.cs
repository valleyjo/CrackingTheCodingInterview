namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs
{
  using System;
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_4_8_FirstCommonAncestor
  {
    public static ABinaryTreeNode Execute(int one, int two, ABinaryTreeNode tree)
    {
      if (tree == null || (tree.Left == null && tree.Right == null))
      {
        return tree;
      }

      if (!TreeContainsNode(tree, one) && !TreeContainsNode(tree, two))
      {
        return null;
      }

      return ExecuteSimple(one, two, tree);
    }

    private static ABinaryTreeNode ExecuteSimple(int one, int two, ABinaryTreeNode tree)
    {
      bool oneOnLeft = TreeContainsNode(tree.Left, one);
      bool twoOnLeft = TreeContainsNode(tree.Left, two);

      if (oneOnLeft != twoOnLeft)
      {
        return tree;
      }
      else
      {
        ABinaryTreeNode nextSide = oneOnLeft ? tree.Left : tree.Right;
        return ExecuteSimple(one, two, nextSide);
      }
    }

    private static bool TreeContainsNode(ABinaryTreeNode tree, int node)
    {
      if (tree == null)
      {
        return false;
      }

      if (tree.Value == node)
      {
        return true;
      }

      return TreeContainsNode(tree.Left, node) || TreeContainsNode(tree.Right, node);
    }

    private static ReturnValue ExecuteOptimal(ABinaryTreeNode root, int one, int two, int searchValue)
    {
      if (root == null)
      {
        return default;
      }

      if (root.Value == one && root.Value == two)
      {
        return new ReturnValue(root, true);
      }

      ReturnValue firstNode = ExecuteOptimal(root.Left, one, two, one);
      if (firstNode.IsAncestor)
      {
        return firstNode;
      }

      ReturnValue secondNode = ExecuteOptimal(root.Right, one, two, two);

      if (secondNode.IsAncestor)
      {
        return secondNode;
      }

      if (secondNode.Node != null && firstNode.Node != null)
      {
        return new ReturnValue(root, true);
      }
      else if (root.Value == one || root.Value == two)
      {
        bool isAncestor = firstNode.Node != null || secondNode.Node != null;
        return new ReturnValue(root, isAncestor);
      }
      else
      {
        return new ReturnValue(firstNode.Node ?? secondNode.Node, false);
      }
    }

    private struct ReturnValue
    {
      public ReturnValue(ABinaryTreeNode node, bool isAncestor)
      {
        this.IsAncestor = isAncestor;
        this.Node = node;
      }

      public bool IsAncestor { get; set; }

      public ABinaryTreeNode Node { get; set; }
    }
  }
}
