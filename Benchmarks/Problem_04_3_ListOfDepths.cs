namespace CrackingTheCodingInterview.Benchmarks
{
  using System;
  using BenchmarkDotNet.Attributes;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using Solution = CrackingTheCodingInterview.Problems.Chapter04_TreesAndGraphsTests.Problem_4_03_ListOfDepths;

  [MemoryDiagnoser]
  public class Problem_04_3_ListOfDepths
  {
    private const int MaxDepth = 6;
    private readonly ABinaryTreeNode root;

    public Problem_04_3_ListOfDepths()
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
