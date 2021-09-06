namespace CrackingTheCodingInterview.Problems.Chapter5_BitManipulation
{
  public static class Problem_5_1_Insertion
  {
    public static int Execute(int source, int dest, int startPos, int endPos)
    {
      for (int i = startPos; i <= endPos; i++)
      {
        dest = ClearBit(dest, i);
      }

      return dest | (source << startPos);
    }

    private static int ClearBit(int val, int pos) => val & ~(1 << pos);
  }
}
