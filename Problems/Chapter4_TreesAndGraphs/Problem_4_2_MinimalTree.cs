namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs
{
  using System;
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_4_2_MinimalTree
  {
    public static ABinaryTreeNode Execute(List<int> input)
    {
      if (input == null || input.Count == 0)
      {
        throw new ArgumentException("Input list is null or empty");
      }

      int index = (input.Count - 1) / 2;
      Log($"Execute; index: '{index}'");
      var root = new ABinaryTreeNode(input[index]);
      AddLeft(input, root, 0, index - 1);
      AddRight(input, root, index + 1, input.Count - 1);
      return root;
    }

    public static void AddRight(List<int> input, ABinaryTreeNode root, int start, int end)
    {
      int index = (start + end) / 2;
      Log($"{nameof(AddRight)}; Adding '{input[index]}'; start: '{start}' end: '{end}' index: '{index}'");
      root.Right = new ABinaryTreeNode(input[index]);
      if (start < end)
      {
        return;
      }

      AddLeft(input, root.Right, start, index - 1);
      AddRight(input, root.Right, index + 1, end);
    }

    public static void AddLeft(List<int> input, ABinaryTreeNode root, int start, int end)
    {
      int index = (start + end) / 2;
      Log($"{nameof(AddLeft)}; Adding '{input[index]}'; start: '{start}' end: '{end}' index: '{index}'");
      root.Left = new ABinaryTreeNode(input[index]);
      if (start < end)
      {
        return;
      }

      AddLeft(input, root.Left, start, index - 1);
      AddRight(input, root.Left, index + 1, end);
    }

    private static void Log(string s)
    {
      bool enableDebugging = true;
      if (enableDebugging)
      {
        Console.WriteLine(s);
      }
    }
  }
}
