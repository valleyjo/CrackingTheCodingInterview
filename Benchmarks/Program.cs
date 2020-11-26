namespace CrackingTheCodingInterview.Benchmarks
{
    using BenchmarkDotNet.Running;

    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<Problem_1_2_CheckPermutationBenchmark>();
        }
    }
}
