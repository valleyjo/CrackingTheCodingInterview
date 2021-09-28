namespace CrackingTheCodingInterview.Benchmarks
{
  using System;
  using System.Text;
  using BenchmarkDotNet.Attributes;
  using CrackingTheCodingInterview.Problems.Chapter01_ArraysAndStrings;

  public class Problem_01_2_CheckPermutationBenchmark
  {
    private readonly string dataOne;
    private readonly string dataTwo;

    public Problem_01_2_CheckPermutationBenchmark()
    {
      var sbOne = new StringBuilder();
      var sbTwo = new StringBuilder();
      var random = new Random();
      int size = random.Next(10000, 20000);
      for (int i = 0; i < size; i++)
      {
        char nextChar = (char)random.Next('A', 'z' + 1);
        sbOne.Append(nextChar);
        sbTwo.Append(nextChar);
      }

      this.dataOne = sbOne.ToString();
      this.dataTwo = sbTwo.ToString();
      Console.Write(this.dataOne);
      Console.Write(this.dataTwo);
    }

    [Benchmark]
    public bool CheckPermutation() => Problem_1_2_CheckPermutation.CheckPermutation(this.dataOne, this.dataTwo);

    [Benchmark]
    public bool CheckPermutation_LessAlloc() => Problem_1_2_CheckPermutation.CheckPermutation_LessAlloc(this.dataOne, this.dataTwo);
  }
}
