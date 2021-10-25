namespace CrackingTheCodingInterview.Problems.Chapter17_Hard
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public static class Chapter_17_02_Shuffle
  {
    public static void ExecuteInPlace(int[] input)
    {
      var rand = new Random();
      for (int i = 0; i < input.Length; i++)
      {
        int randIndex = rand.Next(0, i + 1);
        int tmp = input[randIndex];
        input[randIndex] = input[i];
        input[i] = tmp;
      }
    }

    public static int[] Execute(int[] input)
    {
      var list = new List<int>(input);
      var result = new List<int>(input.Length);
      var rand = new Random();
      while (list.Count > 0)
      {
        int randIndex = rand.Next(0, list.Count);
        result.Add(list[randIndex]);
        list.RemoveAt(randIndex);
      }

      return result.ToArray();
    }
  }
}
