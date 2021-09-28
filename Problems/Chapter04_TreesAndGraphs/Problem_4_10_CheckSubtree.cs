namespace CrackingTheCodingInterview.Problems.Chapter04_TreesAndGraphsTests
{
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_4_10_CheckSubtree
  {
    public static bool Execute(ABinaryTreeNode tree, ABinaryTreeNode subtree)
    {
      // TODO: input validation
      if (tree == null)
      {
        return false;
      }

      if (tree.Equals(subtree))
      {
        if (TreeDeepEquals(tree, subtree))
        {
          return true;
        }
      }

      return Execute(tree.Left, subtree) || Execute(tree.Right, subtree);
    }

    private static bool TreeDeepEquals(ABinaryTreeNode tree, ABinaryTreeNode subtree)
    {
      if (tree == null && subtree == null)
      {
        return true;
      }

      if (tree != null && tree.Equals(subtree))
      {
        return TreeDeepEquals(tree.Left, subtree.Left) && TreeDeepEquals(tree.Right, subtree.Right);
      }

      return false;
    }
  }
}
