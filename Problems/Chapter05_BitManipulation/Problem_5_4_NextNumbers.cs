namespace CrackingTheCodingInterview.Problems.Chapter05_BitManipulation
{
  using System.Numerics;

  public static class Problem_5_4_NextNumbers
  {
    public static void Execute(uint value, out uint smaller, out uint bigger)
    {
      int target = BitOperations.PopCount(value);

      for (uint i = value - 1; ; i--)
      {
        if (BitOperations.PopCount(i) == target)
        {
          smaller = i;
          break;
        }
      }

      for (uint i = value + 1; ; i++)
      {
        if (BitOperations.PopCount(i) == target)
        {
          bigger = i;
          break;
        }
      }
    }
  }
}
