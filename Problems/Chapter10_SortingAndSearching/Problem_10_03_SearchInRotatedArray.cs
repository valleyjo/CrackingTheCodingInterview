namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching
{
  using System;

  public class Problem_10_03_SearchInRotatedArray
  {
    public static int Execute(int[] input, int target)
    {
      if (input == null || input.Length == 0)
      {
        return -1;
      }

      int start = 0;
      int end = input.Length - 1;
      return Execute(input, start, end, target);
    }

    private static int Execute(int[] input, int start, int end, int target)
    {
      if (start > end)
      {
        return -1;
      }

      int mid = (end + start) / 2;
      if (input[mid] == target)
      {
        return mid;
      }

      // Right half is ordered
      if (input[mid] <= input[end])
      {
        if (target > input[mid] && target <= input[end])
        {
          // target is in the ordered right half
          return Execute(input, mid + 1, end, target);
        }
        else
        {
          // target is not in the ordered right half, so it must be in the left half
          return Execute(input, start, mid - 1, target);
        }
      }
      else if (input[start] <= input[mid])
      {
        if (target >= input[start] && target < input[mid])
        {
          // left half is ordered and target is in the left half
          return Execute(input, start, mid - 1, target);
        }
        else
        {
          // target is not in ordered left half, so it must be in right half
          return Execute(input, mid + 1, end, target);
        }
      }

      return -1;
    }
  }
}
