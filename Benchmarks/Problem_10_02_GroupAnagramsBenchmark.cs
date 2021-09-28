namespace CrackingTheCodingInterview.Benchmarks
{
  using System;
  using BenchmarkDotNet.Attributes;
  using Solution = CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Problem_10_02_GroupAnagrams;

  [MemoryDiagnoser]
  public class Problem_10_02_GroupAnagramsBenchmark
  {
    private const int WordSize = 4;
    private const int WordCount = 10000;
    private readonly string[][] anagrams;

    public Problem_10_02_GroupAnagramsBenchmark()
    {
      var rand = new Random();
      this.anagrams = new string[3][];
      string[] source = new string[WordCount];

      for (int i = 0; i < WordCount; i++)
      {
        string word = string.Empty;
        for (int j = 0; j < WordSize; j++)
        {
          word += rand.Next('A', 'Z' + 1);
        }

        source[i] = word;
      }

      for (int i = 0; i < 3; i++)
      {
        string[] copy = new string[WordCount];
        for (int j = 0; j < WordCount; j++)
        {
          copy[j] = new string(source[j].ToCharArray());
        }

        this.anagrams[i] = copy;
      }
    }

    [Benchmark]
    public string[] Execute() => Solution.Execute(this.anagrams[0]);

    [Benchmark]
    public string[] ExecuteWithSorting() => Solution.ExecuteWithSorting(this.anagrams[1]);

    [Benchmark]
    public string[] ExecuteMapWithSorting() => Solution.ExecuteMapWithSorting(this.anagrams[2]);
  }
}
