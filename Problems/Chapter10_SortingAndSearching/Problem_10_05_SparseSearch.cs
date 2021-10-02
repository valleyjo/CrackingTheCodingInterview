namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching
{
  using System;
  using System.Collections.Generic;

  public class Problem_10_05_SparseSearch
  {
    public static Action<string> Logger { get; set; }

    public static int Execute(List<string> strings, string target)
    {
      if (strings == null || strings.Count == 0)
      {
        return -1;
      }

      int start = 0;
      int end = strings.Count - 1;
      while (start <= end)
      {
        int mid = (start + end) / 2;

        for (int delta = 0; ; delta++)
        {
          int nextRightIndex = mid + delta;
          if (nextRightIndex < strings.Count && !string.IsNullOrEmpty(strings[nextRightIndex]))
          {
            mid = nextRightIndex;
            break;
          }

          int nextLeftIndex = mid - delta;
          if (mid - delta >= 0 && !string.IsNullOrEmpty(strings[nextLeftIndex]))
          {
            mid = nextLeftIndex;
            break;
          }

          // Search window is all empty string, therefore target does not exist in the list
          if (nextRightIndex > end && nextLeftIndex < start)
          {
            return -1;
          }
        }

        if (strings[mid] == target)
        {
          return mid;
        }

        if (string.Compare(strings[mid], target, StringComparison.Ordinal) < 0)
        {
          start = mid + 1;
        }
        else
        {
          end = mid - 1;
        }
      }

      return -1;
    }

    private static void Log(string msg) => Logger?.Invoke(msg);
  }
}
