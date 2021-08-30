namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs
{
  using System;
  using System.Collections.Generic;

  /// <summary>
  /// The order of duplicates is undefined.
  /// </summary>
  public class Problem_4_11_RandomNode
  {
    private readonly List<int> data = new ();
    private readonly Random rand = new ();

    public RandomBinaryTreeNode Find(int val)
    {
      for (int i = 0; i < this.data.Count; i++)
      {
        if (this.data[i] == val)
        {
          return new RandomBinaryTreeNode(this.data, i);
        }
      }

      return null;
    }

    // The book mentions that this approach is not sufficient because it does
    // not preserve the delete time operation performance of a regular tree.
    // I don't think that is correct because by replacing the deleted value
    // with the last value (a leaf node) that is O(1) and the array does
    // not have to be shifted.
    //
    // Delete is not implemented in any of the provided solutions.
    //
    // This approach does not work for a Binary Search Tree, but the problem
    // does not specify that the tree must be a Binary Search Tree although
    // the provided solution does implement a BST.
    public bool Delete(int val)
    {
      for (int i = 0; i < this.data.Count; i++)
      {
        if (this.data[i] == val)
        {
          // TODO: verify for only one value in list
          this.data[i] = this.data[^1];
          this.data.RemoveAt(this.data.Count - 1);
          return true;
        }
      }

      return false;
    }

    public void Insert(int val) => this.data.Add(val);

    public RandomBinaryTreeNode GetRandomNode() => new (this.data, this.rand.Next(0, this.data.Count));

    public class RandomBinaryTreeNode
    {
      private readonly int index;
      private readonly List<int> data;

      internal RandomBinaryTreeNode(List<int> data, int index)
      {
        if (index >= data.Count)
        {
          throw new ArgumentOutOfRangeException(nameof(index), $"{nameof(data)} count is '{data.Count}' but index is '{index}'");
        }

        this.data = data;
        this.index = index;
      }

      public int Value
      {
        get { return this.data[this.index];  }
      }

      public RandomBinaryTreeNode Left => this.GetNode((this.index * 2) + 1);

      public RandomBinaryTreeNode Right => this.GetNode((this.index * 2) + 2);

      private RandomBinaryTreeNode GetNode(int newIndex)
      {
        if (newIndex < this.data.Count)
        {
          return new RandomBinaryTreeNode(this.data, newIndex);
        }

        // invalid index means node does not have the requested child (right or left)
        return null;
      }
    }
  }
}
