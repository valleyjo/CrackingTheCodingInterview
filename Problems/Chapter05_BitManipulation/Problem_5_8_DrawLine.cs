namespace CrackingTheCodingInterview.Problems.Chapter5_BitManipulation
{
  public static class Problem_5_8_DrawLine
  {
    public static void Execute(byte[] screen, int width, int x1, int x2, int y)
    {
      // TODO: input validation
      int height = screen.Length / width;

      for (int curX = x1; curX <= x2; curX++)
      {
        GetIndexAndBit(width, y, curX, out int index, out byte bit);
        screen[index] |= (byte)(1 << bit);
      }
    }

    private static void GetIndexAndBit(int w, int y, int x, out int index, out byte bit)
    {
      int baseIndex = y * w;
      int indexIncrement = x / sizeof(byte);
      index = baseIndex + indexIncrement;
      bit = (byte)(x % sizeof(byte));
    }
  }
}
