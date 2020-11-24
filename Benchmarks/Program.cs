using BenchmarkDotNet.Running;

namespace Benchmarks
{
    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<Problem_1_2_CheckPermutationBenchmark>();
        }
    }
}
