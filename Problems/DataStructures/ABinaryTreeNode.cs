namespace CrackingTheCodingInterview.Problems.DataStructures
{
  using System;

  public class ABinaryTreeNode
  {
    private ABinaryTreeNode right;

    private ABinaryTreeNode left;

    public ABinaryTreeNode(int value) => this.Value = value;

    public ABinaryTreeNode(
      int value,
      ABinaryTreeNode left = null,
      ABinaryTreeNode right = null,
      ABinaryTreeNode parent = null)
    {
      this.Value = value;
      this.Left = left;
      this.Right = right;
      this.Parent = parent;
    }

    public ABinaryTreeNode Left
    {
      get => this.left;
      set
      {
        if (value != null)
        {
          value.Parent = this;
        }

        this.left = value;
      }
    }

    public ABinaryTreeNode Right
    {
      get => this.right;
      set
      {
        if (value != null)
        {
          value.Parent = this;
        }

        this.right = value;
      }
    }

    public ABinaryTreeNode Parent { get; internal set; }

    public int Value { get; set; }

    public int GetHeight()
    {
      return GetHeight(this, 1);
    }

    /// <summary>
    /// Checks for euality by comparing the value of the node. Does not validate children / parents
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
