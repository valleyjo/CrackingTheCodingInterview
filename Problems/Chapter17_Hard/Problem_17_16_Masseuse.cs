namespace CrackingTheCodingInterview.Problems.Chapter17_Hard
{
  using System;
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_17_16_Masseuse
  {
    /*
    requirements:
    return number of minutes to maximize

    assumptions:
    valid input -> not empty not null
    input.Length >= 2

    signiture:
    int FindMaxMinutes(int[] minutes)

    Some test cases:
    equal amounts
    multiple paths to the same max amount

    Approaches:
    recursive + memoization 2^n
    bottom-up N time N space
    bottom-up two variables? N time 1 space

    Steps:
    start at back of array - 2
    init two max values to end and end -1
    take max of current + skip OR next
     */
    public static int Execute(int[] input)
    {
      if (input == null || input.Length == 0)
      {
        return -1;
      }

      if (input.Length == 1)
      {
        return input[0];
      }

      int current = Math.Max(input[^1], input[^2]);
      int skipOne = current;
      int next = current;

      for (int i = input.Length - 3; i >= 0; i--)
      {
        current = Math.Max(input[i] + skipOne, next);
        skipOne = next;
        next = current;
      }

      return current;
    }
  }
}
