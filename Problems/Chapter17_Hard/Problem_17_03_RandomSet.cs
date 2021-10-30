namespace CrackingTheCodingInterview.Problems.Chapter17_Hard
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public static class Problem_17_03_RandomSet
  {
    public static int[] Execute(int[] input, int m)
    {
      int[] result = new int[m];
      if (input == null | input.Length == 0)
      {
        return result;
      }

      var rand = new Random();
      for (int i = 0; i < m; i++)
      {
        result[i] = input[i];
      }

      for (int i = m; i < input.Length; i++)
      {
        int randIndex = rand.Next(0, input.Length);
        if (randIndex < m)
        {
          result[randIndex] = input[i];
        }
      }

      return result;
    }
  }
}
