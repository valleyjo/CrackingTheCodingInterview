namespace CrackingTheCodingInterview.Benchmarks
{
  using System;
  using BenchmarkDotNet.Attributes;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using Solution = CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Problem_4_04_CheckBalanced;

  public class Problem_4_4_CheckBalanced
  {
    private const int MaxDepth = 10;
    private readonly ABinaryTreeNode root;

    public Problem_4_4_CheckBalanced()
    {
      this.root = BuildTree(0, new Random());
    }

    [Benchmark]
    public bool Naive() => Solution.ExecuteNaive(this.root);

    [Benchmark]
    public bool OptimizedStruct() => Solution.ExecuteOptimizedStructReturn(this.root);

    [Benchmark]
    public bool OptimizedClass() => Solution.ExecuteOptimizedStructReturn(this.root);

    [Benchmark]
    public bool OptimizedInt() => Solution.ExecuteOptimizedIntReturn(this.root);

    private static ABinaryTreeNode BuildTree(int curDepth, Random rand)
    {
      // as the tree gets bigger the probability that a new node is added is smaller until it reaches zero
      if (curDepth > 0 && (rand.Next(0, MaxDepth - curDepth) == 0))
      {
        return null;
      }

      return new ABinaryTreeNode(rand.Next(0, MaxDepth), BuildTree(curDepth + 1, rand), BuildTree(curDepth + 1, rand));
    }
  }
}
