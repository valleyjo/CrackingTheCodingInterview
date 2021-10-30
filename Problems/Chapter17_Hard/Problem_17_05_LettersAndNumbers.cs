namespace CrackingTheCodingInterview.Problems.Chapter17_Hard
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public static class Problem_17_05_LettersAndNumbers
  {
    public static int Execute(char[] input)
    {
      if (input == null | input.Length == 0)
      {
        return -1;
      }

      int[] deltas = new int[input.Length];
      int letterCount = 0;
      int digitCount = 0;
      for (int i = 0; i < input.Length; i++)
      {
        char c = input[i];
        if (char.IsDigit(c))
        {
          digitCount++;
        }
        else
        {
          letterCount++;
        }

        deltas[i] = letterCount - digitCount;
      }

      var map = new Dictionary<int, int>();
      int[] max = new int[2];
      map.Add(0, -1);
      for (int i = 0; i < deltas.Length; i++)
      {
        int delta = deltas[i];
        if (map.ContainsKey(delta))
        {
          int matchingDelta = map[delta];
          int newDistance = i - matchingDelta;
          int currentLongestDistance = max[1] - max[0];
          if (newDistance > currentLongestDistance)
          {
            max[1] = i;
            max[0] = matchingDelta;
          }
        }
        else
        {
          // save a mapping of the first time we saw that delta to that index
          map[delta] = i;
        }
      }

      return max[1] - max[0];
    }
  }
}
