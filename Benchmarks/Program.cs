namespace CrackingTheCodingInterview.Benchmarks
{
  using System;
  using System.Collections.Concurrent;
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using BenchmarkDotNet.Running;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public class Program
  {
    public static void Main()
    {
      Console.WriteLine(Problems.Chapter16_Moderate.Chapter_16_22_LangtonsAnt.Execute(40));

      const int taskCount = 10;
      var finalResults = new ConcurrentDictionary<int, int>(InitializeHistogram());
      var tasks = new List<Task>();
      for (int i = 0; i < taskCount; i++)
      {
        tasks.Add(ComputeCountsAsync(finalResults, 10_000_000));
      }

      Task.WhenAll(tasks).Wait();

      int totalCount = 0;
      foreach (KeyValuePair<int, int> kvp in finalResults)
      {
        totalCount += kvp.Value;
      }

      foreach (KeyValuePair<int, int> kvp in finalResults)
      {
        double percentage = ((double)kvp.Value / totalCount) * 100;
        Console.WriteLine($"{kvp.Key} : {kvp.Value} : {Math.Round(percentage, 1)}%");
      }
    }

    private static Dictionary<int, int> InitializeHistogram()
    {
      var histogram = new Dictionary<int, int>();
      for (int i = 0; i < 7; i++)
      {
        histogram.Add(i, 0);
      }

      return histogram;
    }

    private static async Task ComputeCountsAsync(ConcurrentDictionary<int, int> finalResults, int end)
    {
      await Task.Yield();

      Dictionary<int, int> histogram = InitializeHistogram();
      for (int i = 0; i < end; i++)
      {
        int num = Problems.Chapter16_Moderate.Chapter_16_23_Rand7FromRand5.Execute();
        histogram[num]++;
      }

      foreach (KeyValuePair<int, int> kvp in histogram)
      {
        finalResults[kvp.Key] += kvp.Value;
      }
    }

    private static void BinaryTreePrinter()
    {
      var expected = new ABinaryTreeNode(3);

      // Left side
      expected.Left = new ABinaryTreeNode(1);
      expected.Left.Right = new ABinaryTreeNode(2);

      // Right side
      expected.Right = new ABinaryTreeNode(5);
      expected.Right.Left = new ABinaryTreeNode(4);
      expected.Right.Right = new ABinaryTreeNode(6);

      expected.Print();
    }
  }
}
