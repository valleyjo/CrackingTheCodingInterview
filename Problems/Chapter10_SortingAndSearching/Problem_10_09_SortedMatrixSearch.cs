namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching
{
  using System;

  public class Problem_10_09_SortedMatrixSearch
  {
    private static readonly Point InvalidPoint = new(-1, -1);

    public static Point Execute(int[,] input, int target)
    {
      if (input == null || input.Length == 0)
      {
        return InvalidPoint;
      }

      var start = new Point(0, 0);
      var end = new Point(input.GetLength(0) - 1, input.GetLength(1) - 1);

      return Execute(input, target, start, end);
    }

    public static Point Execute(int[,] input, int target, Point start, Point end)
    {
      if (start.Row >= input.GetLength(0) || start.Col >= input.GetLength(1))
      {
        return InvalidPoint;
      }

      if (end.Row >= input.GetLength(0) || end.Col >= input.GetLength(1))
      {
        return InvalidPoint;
      }

      if (input[start.Row, start.Col] == target)
      {
        return start;
      }
      else if (!start.IsLessThan(end))
      {
        return InvalidPoint;
      }

      var originalStart = new Point(start.Row, end.Row);
      int diagDistance = Math.Min(end.Row - start.Row, end.Col - start.Col);
      var newEnd = new Point(start.Row + diagDistance, start.Col + diagDistance);
      while (start.IsLessThan(newEnd))
      {
        Point midPoint = start.GetMidPointBetween(newEnd);
        if (input[midPoint.Row, midPoint.Col] > target)
        {
          newEnd.Row = midPoint.Row - 1;
          newEnd.Col = midPoint.Col - 1;
        }
        else
        {
          start.Row = midPoint.Row + 1;
          start.Col = midPoint.Col + 1;
        }
      }

      return Search(input, target, originalStart, start, end);
    }

    private static Point Search(int[,] input, int target, Point originalStart, Point start, Point end)
    {
      var lowerLeftStart = new Point(start.Row, originalStart.Col);
      var lowerLeftEnd = new Point(end.Row, start.Col - 1);
      var upperRightStart = new Point(originalStart.Row, start.Col);
      var upperRightEnd = new Point(start.Row - 1, end.Col);

      Point point = Execute(input, target, lowerLeftStart, lowerLeftEnd);
      return point.IsValid() ? point : Execute(input, target, upperRightStart, upperRightEnd);
    }

    public record Point
    {
      public Point(int row, int col)
      {
        this.Row = row;
        this.Col = col;
      }

      public int Row { get; set; }

      public int Col { get; set; }

      public bool IsValid() => this.Row >= 0 && this.Col >= 0;

      public bool IsLessThan(Point other) => this.Row <= other.Row && this.Col <= other.Col;

      public Point GetMidPointBetween(Point end) => new((this.Row + end.Row) / 2, (this.Col + end.Col) / 2);
    }
  }
}
