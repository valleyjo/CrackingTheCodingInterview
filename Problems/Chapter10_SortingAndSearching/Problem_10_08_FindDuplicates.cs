namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching
{
  using System;
  using System.Collections.Generic;

  public class Problem_10_08_FindDuplicates
  {
    public static Action<string> Logger { get; set; }

    // since this question specifies memory limits, bufffer the results in memory
    // so the caller can do what they need to one at a time rather than storing
    // all results in a collection
    public static IEnumerable<int> Execute(int[] input)
    {
      if (input == null || input.Length == 0)
      {
        yield break;
      }

      var vector = new BitVector(32000);
      foreach (int value in input)
      {
        if (vector.Contains(value))
        {
          yield return value;
        }
        else
        {
          vector.Add(value);
        }
      }
    }

    private static void Log(string msg) => Logger?.Invoke(msg);

    // This is how the book does it too, but I don't see the need to use ints or longs to hold
    // the bits. It seems like the simplest approach is to use a bool array.
    // Verified with a benchmark that a bool array and a long array allocate the same memory
    private class BitVector
    {
      private readonly ulong[] buckets;

      public BitVector(ulong bitCount)
      {
        ulong bucketCount = (bitCount / sizeof(ulong)) + 1;
        this.buckets = new ulong[bucketCount];
      }

      public bool Contains(int value) => this.Contains((ulong)value);

      public bool Contains(ulong value)
      {
        ulong bucket = this.GetBucketContainingValue(value);
        ulong mask = GetMask(value);
        return (bucket & mask) != 0;
      }

      public void Add(int value) => this.Add((ulong)value);

      public void Add(ulong value)
      {
        ulong mask = GetMask(value);
        this.buckets[GetBucketIndexForValue(value)] |= mask;
      }

      private static ulong GetBucketIndexForValue(ulong index) => index / sizeof(ulong);

      private static ulong GetMask(ulong value) => 1UL << (int)(value % sizeof(ulong));

      private ulong GetBucketContainingValue(ulong value) => this.buckets[GetBucketIndexForValue(value)];
    }
  }
}
