﻿namespace CrackingTheCodingInterview.Benchmarks
{
  using System;
  using BenchmarkDotNet.Attributes;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using Solution = CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Problem_4_3_ListOfDepths;

  [MemoryDiagnoser]
  public class Problem_4_3_ListOfDepths
  {
    private const int MaxDepth = 15; // tree will have 2^MaxDepth -1 nodes since it is perfect
    private readonly ABinaryTreeNode root;

    public Problem_4_3_ListOfDepths()
    {
      this.root = BuildTree(0, new Random());
    }

    [Benchmark]
    public Solution.DepthMap BuildDepthMap() => Solution.BuildDepthMap(this.root);

    [Benchmark]
    public Solution.DepthMap BuildDepthMapLessMemory() => Solution.BuildDepthMapLessMemory(this.root);

    private static ABinaryTreeNode BuildTree(int curDepth, Random rand)
    {
      if (curDepth > MaxDepth)
      {
        return null;
      }

      return new ABinaryTreeNode(rand.Next(0, MaxDepth), BuildTree(curDepth + 1, rand), BuildTree(curDepth + 1, rand));
    }
  }
}
