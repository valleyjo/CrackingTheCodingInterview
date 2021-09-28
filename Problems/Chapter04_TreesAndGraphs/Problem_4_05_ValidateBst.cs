namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs
{
  using System;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_4_05_ValidateBst
  {
    public static bool Execute(ABinaryTreeNode root) => ExecuteInternal(root, int.MinValue, int.MaxValue);

    private static bool ExecuteInternal(ABinaryTreeNode root, int min, int max)
    {
      if (root == null)
      {
        return true;
      }

      if (root.Value > max || root.Value < min)
      {
        return false;
      }

      return ExecuteInternal(root.Left, min, root.Value) && ExecuteInternal(root.Right, root.Value, max);
    }
  }
}
