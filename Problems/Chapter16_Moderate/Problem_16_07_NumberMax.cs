namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public static class Problem_16_07_NumberMax
  {
    public static int Execute(int one, int two)
    {
      const uint mask = 1 << 32;
      uint k1 = ((uint)(one - two) & mask) >> 31;
      uint k2 = ((uint)(two - one) & mask) >> 31;
      return (one * (int)k1) + (two * (int)k2);
    }
  }
}
