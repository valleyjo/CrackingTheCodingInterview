namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;
  using System.Text;

  public static class Problem_16_19_PondSizes
  {
    public static List<int> Execute(int[,] grid)
    {
      var results = new List<int>();
      if (grid == null || grid.Length == 0)
      {
        return results;
      }

      /*
      iterate through the grid, if value is zero and not already accounted for, calculate the size of the pond
      recursivly.
      Mark each pond square as accounted for in the storage grid so it's not double counted
      Check the storage grid while going recursivly too? Or only at start.
       */

      int[,] visited = new int[grid.GetLength(0), grid.GetLength(1)];
      for (int row = 0; row < grid.GetLength(0); row++)
      {
        for (int col = 0; col < grid.GetLength(1); col++)
        {
          if (grid[row, col] == 0 && visited[row, col] == 0)
          {
            int pondSize = GetPondSize(grid, row, col, visited);
            results.Add(pondSize);
          }
        }
      }

      return results;
    }

    // TODO: convert to iterative with a stack
    private static int GetPondSize(int[,] grid, int row, int col, int[,] visited)
    {
      // Check we are in bounds and the value is zero indicating water and we have not visited here before
      if (row < 0 || row >= grid.GetLength(0) ||
        col < 0 || col >= grid.GetLength(1) ||
        grid[row, col] != 0 ||
        visited[row, col] == 1)
      {
        return 0;
      }

      int size = 1;
      visited[row, col] = 1;
      size += GetPondSize(grid, row + 1, col, visited);
      size += GetPondSize(grid, row, col + 1, visited);
      size += GetPondSize(grid, row - 1, col, visited);
      size += GetPondSize(grid, row, col - 1, visited);
      size += GetPondSize(grid, row + 1, col - 1, visited);
      size += GetPondSize(grid, row - 1, col + 1, visited);
      size += GetPondSize(grid, row - 1, col - 1, visited);
      size += GetPondSize(grid, row + 1, col + 1, visited);

      return size;
    }
  }
}
