namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public static class Chapter_16_06_SmallestDifference
  {
    public static int Execute(int[] one, int[] two)
    {
      // works until n >= 25
      if (one == null || two == null || one.Length == 0 || two.Length == 0)
      {
        return -1;
      }

      Array.Sort(one);
      Array.Sort(two);
      int minDiff = int.MaxValue;

      for (int i1 = 0, i2 = 0; i1 < one.Length && i2 < two.Length;)
      {
        minDiff = Math.Min(Math.Abs(one[i1] - two[i2]), minDiff);
        if (one[i1] < two[i2])
        {
          i1++;
        }
        else
        {
          i2++;
        }
      }

      return minDiff;
    }
  }
}
