namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching
{
  using System;

  [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "Required for class")]
  public struct Listy
  {
    private readonly int[] data;

    public Listy(int[] data)
    {
      Array.Sort(data);
      this.data = data;
    }

    public int ElementAt(int index)
    {
      if (this.data != null && index < this.data.Length)
      {
        return this.data[index];
      }

      return -1;
    }
  }

  public class Problem_10_04_SortedSearchNoSize
  {
    public static Action<string> Logger { get; set; }

    // TODO: implement as "Search" method on Listy?
    public static int Execute(int target, Listy listy)
    {
      // negative values not supported by Listy
      // empty listy not supported in modified binary search
      if (target <= 0 || listy.ElementAt(0) == -1)
      {
        return -1;
      }

      // TODO: listy length larger than 2^32
      if (listy.ElementAt(0) == target)
      {
        return 0;
      }

      // TODO: for loop?
      int index = 1;
      while (listy.ElementAt(index) != -1 && listy.ElementAt(index) < target)
      {
        index <<= 1;
      }

      return BinarySearch(index >> 1, index, target, listy);
    }

    private static void Log(string msg) => Logger?.Invoke(msg);

    private static int BinarySearch(int start, int end, int target, Listy listy)
    {
      int mid = (start + end) / 2;
      Log($"start: '{start}' end: '{end}' mid: '{mid}'");
      if (listy.ElementAt(mid) == target)
      {
        return mid;
      }

      // End is -1, but target could be between mid and end so we must search that half
      if (listy.ElementAt(end) == -1)
      {
        // only need to search between mid and end if mid has a real value
        if (listy.ElementAt(mid) != -1)
        {
          int result = BinarySearch(mid + 1, end, target, listy);
          if (result != -1)
          {
            return result;
          }
        }

        // If target is not between mid and end, target must be between start and end
        return BinarySearch(start, mid - 1, target, listy);
      }
      else
      {
        // end has a value here so we can use regular binary search
        if (listy.ElementAt(mid) < target)
        {
          return BinarySearch(start, mid - 1, target, listy);
        }
        else
        {
          return BinarySearch(mid + 1, end, target, listy);
        }
      }
    }
  }
}
