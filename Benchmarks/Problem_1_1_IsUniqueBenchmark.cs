namespace Benchmarks
{
    using System;
    using System.Text;
    using BenchmarkDotNet.Attributes;
    using Problems.Chapter1_ArraysAndStrings;

    public class Problem_1_1_IsUniqueBenchmark
    {
        private readonly string data;

        public Problem_1_1_IsUniqueBenchmark()
        {
            var sb = new StringBuilder();
            var random = new Random();
            int size = random.Next(10000, 20000);
            for (int i = 0; i < size; i++)
            {
                char nextChar = (char)random.Next('A', 'z' + 1);
                sb.Append(nextChar);
            }
            this.data = sb.ToString();
        }

        [Benchmark]
        public bool IsUniqueFast() => Problem_1_1_IsUnique.IsUnique(this.data);

        [Benchmark]
        public bool IsUniqueSlow() => Problem_1_1_IsUnique.IsUniqueNoAlloc(this.data);
    }
}
