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
      int mid = (start + end) / 2;
      while (start <= end)
      {
        for (int delta = 0; ; delta++)
        {
          if (mid + delta < strings.Count && !string.IsNullOrEmpty(strings[delta]))
          {
            mid += delta;
            break;
          }

          if (mid - delta >= 0 && !string.IsNullOrEmpty(strings[delta]))
          {
            mid -= delta;
            break;
          }

          // entire list is empty string
          if (mid + delta > end && mid - delta < start)
          {
            return -1;
          }
        }

        if (strings[mid] == target)
        {
          return mid;
        }

        if (strings[mid].CompareTo(target) < 0)
        {
          end = mid - 1;
        }
        else
        {
          start = mid + 1;
        }
      }

      return -1;
    }

    private static void Log(string msg) => Logger?.Invoke(msg);
  }
}
