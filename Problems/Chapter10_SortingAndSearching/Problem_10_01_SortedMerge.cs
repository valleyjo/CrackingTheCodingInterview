namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching
{
  using System;

  public class Problem_10_01_SortedMerge
  {
    public static int[] Execute(int[] a, int[] b)
    {
      if (a == null || b == null)
      {
        throw new ArgumentNullException();
      }

      int aSize = a.Length - b.Length - 1;
      if (aSize < 0)
      {
        throw new ArgumentException(nameof(a));
      }

      int aIndex = aSize;
      int bIndex = b.Length - 1;
      for (int index = a.Length - 1; index >= 0 && bIndex >= 0;  index--)
      {
        if (aIndex >= 0 && a[aIndex] >= b[bIndex])
        {
          a[index] = a[aIndex];
          aIndex--;
        }
        else
        {
          a[index] = b[bIndex];
          bIndex--;
        }
      }

      return a;
    }
  }
}
