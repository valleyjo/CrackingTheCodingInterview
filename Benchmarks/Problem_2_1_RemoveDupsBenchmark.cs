namespace CrackingTheCodingInterview.Benchmarks
{
    using System;
    using BenchmarkDotNet.Attributes;
    using CrackingTheCodingInterview.Problems.Chapter2_LinkedLists;
    using CrackingTheCodingInterview.Problems.DataStructures;

    [MemoryDiagnoser]
    public class Problem_2_1_RemoveDupsBenchmark
    {
        private readonly AListNode<int> dataOne;
        private readonly AListNode<int> dataTwo;

        public Problem_2_1_RemoveDupsBenchmark()
        {
            var data = new int[10000];

            var random = new Random();

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = random.Next(100);
            }

            this.dataOne = AListNode<int>.FromArray(data);
            this.dataTwo = AListNode<int>.FromArray(data);
        }

        [Benchmark]
        public void WithSpaceTest() => Problem_2_1_RemoveDups.ExecuteWithSpace(this.dataOne);

        [Benchmark]
        public void WithoutSpaceTest() => Problem_2_1_RemoveDups.ExecuteWithoutSpace(this.dataTwo);
    }
}
