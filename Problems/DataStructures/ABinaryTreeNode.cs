namespace CrackingTheCodingInterview.Problems.DataStructures
{
  using System;

  public class ABinaryTreeNode
  {
    public ABinaryTreeNode(int value) => this.Value = value;

    public ABinaryTreeNode(int value, ABinaryTreeNode left = null, ABinaryTreeNode right = null)
    {
      this.Value = value;
      this.Left = left;
      this.Right = right;
    }

    public ABinaryTreeNode Left { get; set; }

    public ABinaryTreeNode Right { get; set; }

    public int Value { get; set; }

    public int GetHeight()
    {
      return GetHeight(this, 1);
    }

    /// <summary>
    /// Checks for euality by comparing the value of the node. Used for unit
    /// testing via FluentAssertions
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
      var other = obj as ABinaryTreeNode;
      return other != null && other.Value == this.Value;
    }

    public override int GetHashCode() => base.GetHashCode();

    private static int GetHeight(ABinaryTreeNode next, int level)
    {
      if (next == null)
      {
        return level - 1;
      }

      return Math.Max(GetHeight(next.Left, level + 1), GetHeight(next.Right, level + 1));
    }
  }
}
