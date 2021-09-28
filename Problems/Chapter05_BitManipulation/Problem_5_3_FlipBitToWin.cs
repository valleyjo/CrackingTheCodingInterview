namespace CrackingTheCodingInterview.Problems.Chapter5_BitManipulation
{
  using System;

  public static class Problem_5_3_FlipBitToWin
  {
    public static int Execute(int value)
    {
      int maxSequence = 0;
      int count = 0;
      int resetPosition = 0;
      bool haveSeenZero = false;

      // sizeof returns size in bytes
      for (int i = 0; i < sizeof(int) * 8; i++)
      {
        bool bit = GetBit(value, i);
        if (bit)
        {
          count++;
        }
        else if (haveSeenZero)
        {
          maxSequence = Math.Max(count, maxSequence);
          count = 0;
          haveSeenZero = false;
          i = resetPosition;
        }
        else
        {
          count++;
          haveSeenZero = true;
          resetPosition = i + 1; // ends in zero?
        }
      }

      // if sequence ends in a 1 count will still have a value
      return Math.Max(maxSequence, count);
    }

    public static int ExecuteFaster(int value)
    {
      int max = 1;
      int cur = 0;
      int prev = 0;

      for (int i = 0; i < sizeof(int) * 8; i++)
      {
        bool bit = GetBit(value, i);
        if (bit)
        {
          cur++;
        }
        else
        {
          max = Math.Max(max, cur + prev);

          // zero is stored in cur, so when moving to prev, take it out
          prev = cur - 1;
          cur = 1;
        }
      }

      return Math.Max(max, prev + cur);
    }

    private static bool GetBit(int value, int i) => (value & (1 << i)) != 0;
  }
}
