namespace CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming
{
  using System;
  using System.Collections.Generic;

  // use value type for easy copying
  [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "self contained class")]
  public struct Box
  {
    public Box(uint width, uint height, uint depth)
    {
      this.Height = height;
      this.Width = width;
      this.Depth = depth;
    }

    public uint Height { get; private set; }

    public uint Width { get; private set; }

    public uint Depth { get; private set; }

    // for easier debugging
    public override string ToString() => $"[{this.Height}, {this.Width}, {this.Depth}]";

    public bool IsSmallerThan(Box other) =>
      this.Height < other.Height && this.Width < other.Width && this.Depth < other.Depth;
  }

  public static class Problem_8_13_StackOfBoxes
  {
    public static uint Execute(List<Box> boxes)
    {
      if (boxes == null)
      {
        throw new ArgumentNullException(nameof(boxes));
      }

      // pass in an "infinitly large" box to start so that the first box passes the IsSmallerThan conditional
      return Execute(boxes, new HashSet<int>(boxes.Count), 0, new Box(uint.MaxValue, uint.MaxValue, uint.MaxValue));
    }

    private static uint Execute(List<Box> boxes, HashSet<int> usedBoxIndexes, uint currentHeight, Box lastBox)
    {
      uint tallestHeightSoFar = currentHeight;
      for (int i = 0; i < boxes.Count; i++)
      {
        if (!usedBoxIndexes.Contains(i) && boxes[i].IsSmallerThan(lastBox))
        {
          usedBoxIndexes.Add(i);
          uint heightForStackStartingWithThisBox = Execute(boxes, usedBoxIndexes, currentHeight + boxes[i].Height, boxes[i]);
          tallestHeightSoFar = Math.Max(tallestHeightSoFar, heightForStackStartingWithThisBox);
          usedBoxIndexes.Remove(i);
        }
      }

      return tallestHeightSoFar;
    }
  }
}
