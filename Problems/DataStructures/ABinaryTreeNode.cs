namespace CrackingTheCodingInterview.Problems.DataStructures
{
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
  }
}
