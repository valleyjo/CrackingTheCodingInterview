namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching
{
  using System;
  using System.Collections.Generic;
  using System.IO;

  public class Problem_10_07_MissingInt
  {
    public static Action<string> Logger { get; set; }

    // TODO: Add smaller window two pass approach
    public static int Execute(Stream stream)
    {
      long maxInts = 1L << 30;
      bool[] vector = new bool[maxInts];

      int lastReadBytes = 0;
      byte[] data = new byte[4];
      do
      {
        lastReadBytes = stream.Read(data, 0, sizeof(int));
        int value = BitConverter.ToInt32(data, 0);
        if (lastReadBytes > 0)
        {
          vector[value] = true;
        }
      }
      while (lastReadBytes > 0);

      for (int i = 0; i < vector.Length; i++)
      {
        if (!vector[i])
        {
          return i;
        }
      }

      return -1;
    }
  }
}
