namespace CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming
{
  using System;
  using System.Collections.Generic;

  public static class Problem_8_2_RobotInAGrid
  {
    private record Point
    {
      public Point(int row, int col)
      {
        this.Row = row;
        this.Col = col;
      }

      public int Row { get; }

      public int Col { get; }

      public override string ToString() => $"[{this.Row},{this.Col}]";
    }

    public static bool Execute(bool[,] grid)
    {
      if (grid.Rank != 2)
      {
        throw new ArgumentException("Only rank 2 grids accepted");
      }

      // variables:
      // current row
      // current col
      // grid
      bool[][] visited = new bool[grid.GetLength(0)][];
      for (int i = 0; i < visited.Length; i++)
      {
        visited[i] = new bool[grid.GetLength(1)];
      }

      return Execute(grid, 0, 0, visited, new HashSet<Point>());
    }

    private static bool Execute(bool[,] grid, int row, int col, bool[][] visited, HashSet<Point> visitedSet)
    {
      // Found a blocked path, or the row or column value exceeded the dimensions of the grid
      if (row == grid.GetLength(0) || col == grid.GetLength(1) || !grid[row, col])
      {
        return false;
      }

      var current = new Point(row, col);

      if (visited[row][col])
      {
        return false;
      }

      visited[row][col] = true;
      visitedSet.Add(current);

      // reached the end
      if (row == grid.GetLength(0) - 1 && col == grid.GetLength(1) - 1)
      {
        return true;
      }

      // check if a path exists by going to the right and down
      return Execute(grid, row + 1, col, visited, visitedSet) || Execute(grid, row, col + 1, visited, visitedSet);
    }
  }
}
