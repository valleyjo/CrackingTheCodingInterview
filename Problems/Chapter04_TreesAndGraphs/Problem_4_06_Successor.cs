namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs
{
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_4_06_Successor
  {
    public static ABinaryTreeNode Execute(ABinaryTreeNode root)
    {
      if (root == null)
      {
        return null;
      }

      if (root.Right == null)
      {
        ABinaryTreeNode cur = root;
        while (cur.Parent != null && ReferenceEquals(cur, cur.Parent.Right))
        {
          cur = cur.Parent;
        }

        return cur.Parent;
      }
      else
      {
        ABinaryTreeNode cur = root.Right;
        while (cur.Left != null)
        {
          cur = cur.Left;
        }

        return cur;
      }
    }
  }
}
