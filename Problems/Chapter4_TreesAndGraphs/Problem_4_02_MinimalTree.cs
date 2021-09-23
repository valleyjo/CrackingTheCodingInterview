namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs
{
  using System;
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_4_02_MinimalTree
  {
    public static ABinaryTreeNode Execute(List<int> input)
    {
      if (input == null || input.Count == 0)
      {
        throw new ArgumentException("Input list is null or empty");
      }

      ////int index = (input.Count - 1) / 2;
      ////var root = new ABinaryTreeNode(input[index]);
      ////AddLeft(input, root, 0, index - 1);
      ////AddRight(input, root, index + 1, input.Count - 1);
      ////return root;

      return CreateMinimalBST(input, 0, input.Count - 1);
    }

    public static ABinaryTreeNode CreateMinimalBST(List<int> input, int start, int end)
    {
      if (end < start)
      {
        return null;
      }

      int index = (start + end) / 2;
      return new ABinaryTreeNode(
        input[index],
        CreateMinimalBST(input, start, index - 1),
        CreateMinimalBST(input, index + 1, end));
    }

    /*
    public static void AddRight(List<int> input, ABinaryTreeNode root, int start, int end)
    {
      int index = (start + end) / 2;
      root.Right = new ABinaryTreeNode(input[index]);

      if (start < index)
      {
        AddLeft(input, root.Right, start, index - 1);
      }

      if (index < end)
      {
        AddRight(input, root.Right, index + 1, end);
      }
    }

    public static void AddLeft(List<int> input, ABinaryTreeNode root, int start, int end)
    {
      int index = (start + end) / 2;
      root.Left = new ABinaryTreeNode(input[index]);

      if (start < index)
      {
        AddLeft(input, root.Left, start, index - 1);
      }

      if (index < end)
      {
        AddRight(input, root.Left, index + 1, end);
      }
    }

    private static void Log(string s)
    {
      bool enableDebugging = true;
      if (enableDebugging)
      {
        Console.WriteLine(s);
      }
    }
    */
  }
}
