namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs
{
  using System;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_4_4_CheckBalanced
  {
    private const int MinDifferenceAllowed = 1;

    /// <summary>
    /// Initial solution I came up with using the "GetHeight" function of the ABinaryTree class
    /// </summary>
    public static bool ExecuteNaive(ABinaryTreeNode root)
    {
      if (root == null)
      {
        return true;
      }

      return Math.Abs(GetHeight(root.Left, 0) - GetHeight(root.Right, 0)) <= MinDifferenceAllowed && ExecuteNaive(root.Left) && ExecuteNaive(root.Right);
    }

    public static bool ExecuteOptimizedStructReturn(ABinaryTreeNode root) => ExecuteOptimizedStructReturn(root, 0).Balanced;

    public static bool ExecuteOptimizedClassReturn(ABinaryTreeNode root) => ExecuteOptimizedClassReturn(root, 0).Balanced;

    public static bool ExecuteOptimizedIntReturn(ABinaryTreeNode root) => ExecuteOptimizedIntReturnInternal(root) != int.MinValue;

    /// <summary>
    /// Solution given in the book
    /// </summary>
    /// <returns>int.MinValue if tree is not balanced, height of tree otherwise</returns>
    private static int ExecuteOptimizedIntReturnInternal(ABinaryTreeNode root)
    {
      if (root == null)
      {
        return 0;
      }

      int leftHeight = ExecuteOptimizedIntReturnInternal(root.Left);
      if (leftHeight == int.MinValue)
      {
        return int.MinValue;
      }

      int rightHeigth = ExecuteOptimizedIntReturnInternal(root.Right);
      if (rightHeigth == int.MinValue)
      {
        return int.MinValue;
      }

      if (Math.Abs(rightHeigth - leftHeight) > MinDifferenceAllowed)
      {
        return int.MinValue;
      }

      return Math.Max(rightHeigth, leftHeight) + 1;
    }

    /// <summary>
    /// solution I came up with without hints or checking the book
    /// </summary>
    /// <param name="root"></param>
    /// <param name="curDepth"></param>
    /// <returns></returns>
    private static ReturnValueStruct ExecuteOptimizedStructReturn(ABinaryTreeNode root, int curDepth)
    {
      if (root == null)
      {
        return new ReturnValueStruct(curDepth - 1, true);
      }

      ReturnValueStruct left = ExecuteOptimizedStructReturn(root.Left, curDepth + 1);

      if (!left.Balanced)
      {
        return new ReturnValueStruct(left.Height, false);
      }

      ReturnValueStruct right = ExecuteOptimizedStructReturn(root.Right, curDepth + 1);
      if (!right.Balanced)
      {
        return new ReturnValueStruct(right.Height, false);
      }

      bool balanced = Math.Abs(left.Height - right.Height) <= MinDifferenceAllowed;
      int height = Math.Max(left.Height, right.Height);

      return new ReturnValueStruct(height, balanced && left.Balanced && right.Balanced);
    }

    /// <summary>
    /// solution I came up with without hints or checking the book
    /// </summary>
    /// <param name="root"></param>
    /// <param name="curDepth"></param>
    /// <returns></returns>
    private static ReturnValueClass ExecuteOptimizedClassReturn(ABinaryTreeNode root, int curDepth)
    {
      if (root == null)
      {
        return new ReturnValueClass(curDepth - 1, true);
      }

      ReturnValueClass left = ExecuteOptimizedClassReturn(root.Left, curDepth + 1);

      if (!left.Balanced)
      {
        return new ReturnValueClass(left.Height, false);
      }

      ReturnValueClass right = ExecuteOptimizedClassReturn(root.Right, curDepth + 1);
      if (!right.Balanced)
      {
        return new ReturnValueClass(right.Height, false);
      }

      bool balanced = Math.Abs(left.Height - right.Height) <= MinDifferenceAllowed;
      int height = Math.Max(left.Height, right.Height);

      return new ReturnValueClass(height, balanced && left.Balanced && right.Balanced);
    }

    private static int GetHeight(ABinaryTreeNode root, int curDepth)
    {
      if (root == null)
      {
        return curDepth - 1;
      }

      return Math.Max(GetHeight(root.Left, curDepth + 1), GetHeight(root.Right, curDepth + 1));
    }

    private struct ReturnValueStruct
    {
      public ReturnValueStruct(int height, bool balanced)
      {
        this.Height = height;
        this.Balanced = balanced;
      }

      public int Height { get; }

      public bool Balanced { get; }
    }

    private class ReturnValueClass
    {
      public ReturnValueClass(int height, bool balanced)
      {
        this.Height = height;
        this.Balanced = balanced;
      }

      public int Height { get; }

      public bool Balanced { get;  }
    }
  }
}
