namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching
{
  /*
    use a linked list to store then two heaps to partition ->
      insert: 1, rank: nlog(n), memory: 2n
    use arraylist to store, insert in order. Binary search to find item and use list count to determine rank (TODO: duplicates)
    insert: N, rank: logn, memory: n
    Use linked list to store, iterate through to get rank ->
      insert: 1, rank: N, memory: N
    int array, increment each index lower than the number ->
      insert: O(N), rank: O(1), memory: O(M) m = number of possible numbers, would be quite large although do-able on a server.
    Binary search tree, maintain child counts in the parent
      insert: best: log(n) worst: N, rank: best: log(n), worst: N memory: n
   */
  public class Problem_10_10_RankFromStream
  {
    private Node root;

    /// <summary>
    /// Returns count of numbers less than or equal to <paramref name="x"/>. <see cref="Track(int)"/> must
    /// have been called for <paramref name="x"/> to return a valid count. Otherwise, -1 is returned.
    /// </summary>
    /// <param name="x">The number to find less than or equal to</param>
    /// <returns>
    /// -1 if <see cref="Track(int)"/> was never called for <paramref name="x"/>.
    /// Otherwise returns the count of numbers less than or equal to <paramref name="x"/>
    /// </returns>
    public int GetRank(int x)
    {
      Node cur = this.root;
      int totalCount = 0;
      while (cur != null)
      {
        // assume x must have been "tracked"
        if (x == cur.Data)
        {
          return totalCount + cur.LeftChildCount;
        }

        if (x < cur.Data)
        {
          // when we go left, no nodes are bigger than it on the right
          // so no need to increase the counter
          cur = cur.Left;
        }
        else
        {
          // When we go right, this means X is bigger than everything on the left
          // also including this node itself. We need to add in the left node
          // child count if it exists and the current node.
          totalCount += cur.LeftChildCount + 1;
          cur = cur.Right;
        }
      }

      return -1;
    }

    public void Track(int x)
    {
      if (this.root == null)
      {
        this.root = new Node() { Data = x };
        return;
      }

      Node cur = this.root;
      while (true)
      {
        // duplicates go on the left side
        if (x <= cur.Data)
        {
          cur.LeftChildCount++;
          if (cur.Left == null)
          {
            cur.Left = new Node() { Data = x };
            return;
          }

          cur = cur.Left;
        }
        else
        {
          if (cur.Right == null)
          {
            cur.Right = new Node() { Data = x };
            return;
          }

          cur = cur.Right;
        }
      }
    }

    private class Node
    {
      public int Data { get; set; }

      public int LeftChildCount { get; set; }

      public Node Left { get; set; }

      public Node Right { get; set; }
    }
  }
}
