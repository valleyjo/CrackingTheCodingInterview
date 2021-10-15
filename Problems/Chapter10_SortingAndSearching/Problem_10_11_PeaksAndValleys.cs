namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching
{
  using System;

  public static class Problem_10_11_PeaksAndValleys
  {
    public static int[] ExecuteFaster(int[] input)
    {
      if (input == null || input.Length < 3)
      {
        return input;
      }

      for (int i = 1; i < input.Length; i += 2)
      {
        Swap(input, i, GetMaxIndexOfThree(input, i));
      }

      return input;
    }

    public static int[] Execute(int[] input)
    {
      if (input == null || input.Length <= 1)
      {
        return input;
      }

      Array.Sort(input);

      for (int i = 1; i + 1 < input.Length; i += 2)
      {
        Swap(input, i, i + 1);
      }

      return input;
    }

    private static void Swap(int[] input, int start, int end)
    {
      int tmp = input[start];
      input[start] = input[end];
      input[end] = tmp;
    }

    private static int GetMaxIndexOfThree(int[] input, int i)
    {
      int maxOfThree = Math.Max(input[i], Math.Max(input[i - 1], input[i + 1]));
      if (input[i] == maxOfThree)
      {
        return i;
      }
      else if (input[i - 1] == maxOfThree)
      {
        return i - 1;
      }
      else
      {
        return i + 1;
      }
    }
  }
}
