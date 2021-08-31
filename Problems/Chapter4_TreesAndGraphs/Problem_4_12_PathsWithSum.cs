namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs
{
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_4_12_PathsWithSum
  {
    /*
     * Test cases
     * 1) null
     * 2) single node tree
     * 3) no valid sums to target
     * 4) multiple path sums to target (Include negatives and zero)
     */
    public static int ExecuteBruteForce(ABinaryTreeNode root, int target)
    {
      if (root == null)
      {
        return 0;
      }

      int pathsFromRoot = ExecuteBruteForce(root, target, 0);
      int pathsFromLeft = ExecuteBruteForce(root.Left, target); // restart on the left
      int pathsFromRight = ExecuteBruteForce(root.Right, target); // restart on the right

      return pathsFromRight + pathsFromLeft + pathsFromRoot;
    }

    private static int ExecuteBruteForce(ABinaryTreeNode tree, int target, int sum)
    {
      if (tree == null)
      {
        return 0;
      }

      int paths = 0;
      sum += tree.Value;
      if (sum == target)
      {
        paths++;
      }

      return paths + ExecuteBruteForce(tree.Left, target, sum) + ExecuteBruteForce(tree.Right, target, sum);
    }
  }
}
