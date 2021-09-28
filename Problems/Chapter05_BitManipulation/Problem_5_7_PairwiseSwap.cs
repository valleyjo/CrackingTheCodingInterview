namespace CrackingTheCodingInterview.Problems.Chapter5_BitManipulation
{
  public static class Problem_5_7_PairwiseSwap
  {
    public static uint Execute(uint source)
    {
      const uint oddMask = 0xAAAAAAAA;
      const uint evenMask = 0x55555555;
      ulong evens = (oddMask & source) >> 1;
      ulong odds = (evenMask & source) << 1;
      return (uint)(evens | odds);
    }
  }
}
