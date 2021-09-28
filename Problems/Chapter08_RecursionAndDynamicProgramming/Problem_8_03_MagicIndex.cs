namespace CrackingTheCodingInterview.Problems.Chapter08_RecursionAndDynamicProgramming
{
  using System;

  public static class Problem_8_03_MagicIndex
  {
    public static int Execute(int[] a)
    {
      if (a == null || a.Length == 0)
      {
        return -1;
      }

      return Execute(0, a.Length - 1, a);
    }

    public static int ExecuteDuplicates(int[] a)
    {
      // TODO: Error handling
      return ExecuteDuplicates(a, 0, a.Length - 1);
    }

    private static int ExecuteDuplicates(int[] a, int start, int end)
    {
      if (start == end)
      {
        return -1;
      }

      int index = (start + end) / 2;
      if (a[index] == index)
      {
        return index;
      }

      int leftIndex = Math.Min(a[index], index - 1);
      int left = ExecuteDuplicates(a, start, leftIndex);
      if (left != -1)
      {
        // found it on left
        return left;
      }

      int rightIndex = Math.Max(a[index], index + 1);
      return ExecuteDuplicates(a, rightIndex, end);
    }

    private static int Execute(int left, int right, int[] a)
    {
      int index = (left + right) / 2;
      if (a[index] == index)
      {
        return index;
      }

      // reached the end and did not find magic index
      if (right == left)
      {
        return -1;
      }

      if (a[index] > index)
      {
        return Execute(left, index - 1, a);
      }
      else
      {
        return Execute(index + 1, right, a);
      }
    }
  }
}
