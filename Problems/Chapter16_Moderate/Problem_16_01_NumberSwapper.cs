namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  public static class Problem_16_01_NumberSwapper
  {
    public static void Execute(ref int one, ref int two)
    {
      one ^= two;
      two ^= one;
      one ^= two;
    }
  }
}
