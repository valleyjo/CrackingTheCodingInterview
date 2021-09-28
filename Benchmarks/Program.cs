namespace CrackingTheCodingInterview.Benchmarks
{
  using BenchmarkDotNet.Running;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public class Program
  {
    public static void Main()
    {
      BenchmarkRunner.Run<Problem_10_02_GroupAnagramsBenchmark>();
      ////new Problem_4_3_ListOfDepths();
      ////BinaryTreePrinter();
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
