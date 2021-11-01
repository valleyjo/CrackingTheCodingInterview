namespace CrackingTheCodingInterview.Problems.Chapter17_Hard
{
  using System;
  using System.Collections.Generic;

  public static class Problem_17_12_BiNode
  {
    /*
    Solution options
    1) in place (recursive or with stack)
      + O(N) space (call stack)
      - Complex implementation
    2) in order traversal copy and re-link
      + Easier implementation
      - more space (2N but still O(N) space)
     */
    public static BiNode ExecuteWithCopy(BiNode root)
    {
      if (root == null || (root.One == null && root.Two == null))
      {
        return root;
      }

      return ConvertWithCopy(root);
    }

    public static BiNode Execute(BiNode root)
    {
      if (root == null || (root.One == null && root.Two == null))
      {
        return root;
      }

      return ExecuteRecursive(root);
    }

    private static BiNode ExecuteRecursive(BiNode root)
    {
      if (root == null)
      {
        return null;
      }
      else if (root.One == null && root.Two == null)
      {
        root.One = root;
        root.Two = root;
        return root;
      }

      BiNode leftHalf = ExecuteRecursive(root.One);
      BiNode rightHalf = ExecuteRecursive(root.Two);

      if (root.One == null && root.Two == null)
      {
        root.One = root;
        root.Two = root;
        return root;
      }

      if (leftHalf != null)
      {
        // connect the end of the left half to the root
        leftHalf.Two.One = root;
        root.One = leftHalf.Two;

        // break the infinite loop
        if (leftHalf.One != null)
        {
          leftHalf.One.Two = null;
        }
      }
      else
      {
        root.One = null;
      }

      if (rightHalf != null)
      {
        // connect the start of the right half to the root
        rightHalf.One.Two = root;
        root.Two = rightHalf.One;

        // break the infinite loop
        if (rightHalf.Two != null)
        {
          rightHalf.Two.One = null;
        }
      }
      else
      {
        root.Two = null;
      }

      return root;
    }

    private static BiNode ConvertWithCopy(BiNode root)
    {
      var inOrderTraversal = new List<BiNode>();
      ConvertWithCopy(root, inOrderTraversal);

      for (int i = 0; i < inOrderTraversal.Count - 1; i++)
      {
        BiNode prev = i >= 1 ? inOrderTraversal[i - 1] : null;
        BiNode cur = inOrderTraversal[i];
        BiNode next = i <= inOrderTraversal.Count - 1 ? inOrderTraversal[i + 1] : null;
        cur.One = prev;
        cur.Two = next;
      }

      return inOrderTraversal[0];
    }

    private static void ConvertWithCopy(BiNode root, List<BiNode> results)
    {
      if (root == null)
      {
        return;
      }

      ConvertWithCopy(root.One, results);
      results.Add(root);
      ConvertWithCopy(root.Two, results);
    }

    public class BiNode
    {
      public BiNode(int data, BiNode one = null, BiNode two = null)
      {
        this.Data = data;
        this.One = one;
        this.Two = two;
      }

      public int Data { get; set; }

      public BiNode One { get; set; }

      public BiNode Two { get; set; }

      public override string ToString()
      {
        string one = this.One == null ? "[null]" : this.One.Data.ToString();
        string two = this.Two == null ? "[null]" : this.Two.Data.ToString();
        return $"{one} <- {this.Data} -> {two}";
      }

      public string ToListString()
      {
        var results = new List<int>();
        BiNode cur = this;
        while (cur != null)
        {
          results.Add(cur.Data);
          cur = cur.Two;
        }

        return string.Join(" -> ", results);
      }
    }
  }
}
