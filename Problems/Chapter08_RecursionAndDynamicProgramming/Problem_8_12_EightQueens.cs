namespace CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming
{
  using System;
  using System.Collections.Generic;

  // use value type for easy copying
  [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "self contained class")]
  public struct Coordinate
  {
    public Coordinate(int row, int col)
    {
      this.Row = row;
      this.Col = col;
    }

    public int Row { get; private set; }

    public int Col { get; private set; }

    // for easier debugging
    public override string ToString() => $"[{this.Row}, {this.Col}]";

    public bool CanPlace(int row, int col) =>
      this.Row != row && this.Col != col && Math.Abs(row - this.Row) != Math.Abs(col - this.Col);
  }

  public static class Problem_8_12_EightQueens
  {
    public static List<List<Coordinate>> Execute(int size)
    {
      var finalResults = new List<List<Coordinate>>();
      int[,] grid = new int[size, size];
      Execute(grid, 0, new List<Coordinate>(), finalResults);
      return finalResults;
    }

    private static void Execute(int[,] grid, int row, List<Coordinate> placements, List<List<Coordinate>> results)
    {
      if (row == grid.GetLength(0))
      {
        return;
      }

      for (int nextCol = 0; nextCol < grid.GetLength(1); nextCol++)
      {
        bool canPlace = true;
        foreach (Coordinate coordinate in placements)
        {
          canPlace &= coordinate.CanPlace(row, nextCol);
        }

        if (canPlace)
        {
          var placementCopy = new List<Coordinate>(placements);
          placementCopy.Add(new Coordinate(row, nextCol));
          if (placementCopy.Count == grid.GetLength(0))
          {
            // found a valid placement. add it to the final results.
            results.Add(placementCopy);
          }
          else
          {
            // still need to find more queen positions. Start looking on the next row.
            Execute(grid, row + 1, placementCopy, results);
          }
        }
      }
    }
  }
}
