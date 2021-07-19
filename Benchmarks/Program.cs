namespace CrackingTheCodingInterview.Benchmarks
{
  using System.Collections.Generic;
  using BenchmarkDotNet.Running;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public class Program
  {
    public static void Main()
    {
      ////BenchmarkRunner.Run<Problem_2_1_RemoveDupsBenchmark>();
      var nums = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, };
      ABinaryTreeNode root = Problems.Chapter4_TreesAndGraphs.Problem_4_2_MinimalTree.Execute(nums);
      ABinaryTreePrinter.Print(root);
    }
  }
}
