namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;

  // TODO: Add tests
  // TODO: Finish
  public static class Chapter_16_13_BisectSquares
  {
    public static Line Execute(Square one, Square two)
    {
      return new Line();
    }

    public class Square
    {
      public Point Start { get; }

      public Point End { get; }
    }

    public record Point
    {
      public string Name { get; }

      public string Value { get; }
    }

    public record Line
    {
      public double M { get; set; }

      public double B { get; set; }

      public double GetY(int x) => (this.M * x) + this.B;

      public double GetX(int y) => (this.M * y) + this.B;
    }
  }
}
