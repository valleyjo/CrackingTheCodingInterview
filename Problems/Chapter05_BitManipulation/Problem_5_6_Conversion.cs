namespace CrackingTheCodingInterview.Problems.Chapter05_BitManipulation
{
  using System.Numerics;

  public static class Problem_5_6_Conversion
  {
    public static int Execute(int source, int dest) => BitOperations.PopCount((uint)(source ^ dest));
  }
}
