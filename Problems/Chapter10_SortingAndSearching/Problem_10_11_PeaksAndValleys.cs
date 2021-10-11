namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching
{
  using System;

  public static class Problem_10_11_PeaksAndValleys
  {
    public static int[] SortFaster(int[] input)
    {
      if (input == null || input.Length < 3)
      {
        return input;
      }

      for (int i = 0; i < input.Length; i += 3)
      {
        int maxOfThree = Math.Max(input[i], Math.Max(input[i + 1], input[i + 2]));

        if (input[i + 2] == maxOfThree)
        {
          Swap(input, i + 2, i);
        }
        else
        {
          Swap(input, i, i + 1);
        }
      }

      return input;
    }

    public static int[] Sort(int[] input)
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
  }
}
