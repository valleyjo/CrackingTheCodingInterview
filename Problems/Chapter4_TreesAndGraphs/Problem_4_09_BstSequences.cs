namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs
{
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_4_09_BstSequences
  {
    public static List<List<int>> Execute(ABinaryTreeNode tree)
    {
      var result = new List<List<int>>();

      if (tree == null)
      {
        result.Add(new List<int>());
        return result;
      }

      var prefix = new List<int>() { tree.Value };
      List<List<int>> left = Execute(tree.Left);
      List<List<int>> right = Execute(tree.Right);

      foreach (List<int> leftList in left)
      {
        foreach (List<int> rightList in right)
        {
          var combinedResults = new List<List<int>>();
          CombineListsPreserveRelativeOrder(leftList, rightList, combinedResults, prefix);
          result.AddRange(combinedResults);
        }
      }

      return result;
    }

    private static void CombineListsPreserveRelativeOrder(
      List<int> left,
      List<int> right,
      List<List<int>> combinedResults,
      List<int> prefix)
    {
      if (left.Count == 0 || right.Count == 0)
      {
        var result = new List<int>(prefix);
        result.AddRange(left);
        result.AddRange(right);
        combinedResults.Add(result);
        return;
      }

      int leftHead = left[0];
      left.RemoveAt(0);
      prefix.Add(leftHead);
      CombineListsPreserveRelativeOrder(left, right, combinedResults, prefix);
      left.Insert(0, leftHead);

      int rightHead = right[0];
      left.RemoveAt(0);
      prefix.Add(rightHead);
      CombineListsPreserveRelativeOrder(left, right, combinedResults, prefix);
      left.Insert(0, rightHead);
    }
  }
}
