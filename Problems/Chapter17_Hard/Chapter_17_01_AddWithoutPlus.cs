namespace CrackingTheCodingInterview.Problems.Chapter17_Hard
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public static class Chapter_17_01_AddWithoutPlus
  {
    public static int Execute(int one, int two)
    {
      int carry = 0;
      int result = 0;
      for (int i = 0; i < 32; i++)
      {
        int oneBit = GetBit(one, i);
        int twoBit = GetBit(two, i);
        int nextBit = 0;

        if ((carry & 1) != 0)
        {
          if ((oneBit & twoBit) != 0)
          {
            nextBit = 1;
            carry = 1;
          }
          else if ((oneBit | twoBit) != 0)
          {
            nextBit = 0;
            carry = 1;
          }
          else
          {
            nextBit = 1;
            carry = 0;
          }
        }
        else
        {
          // no carry bit
          if ((oneBit & twoBit) != 0)
          {
            nextBit = 0;
            carry = 1;
          }
          else if ((oneBit | twoBit) != 0)
          {
            nextBit = 1;
            carry = 0;
          }
          else
          {
            nextBit = 0;
            carry = 0;
          }
        }

        result = SetBit(result, nextBit, i);
      }

      return result;
    }

    private static int GetBit(int one, int i) => one & (1 << i);

    private static int SetBit(int result, int nextBit, int i) => result | (nextBit << i);
  }
}
