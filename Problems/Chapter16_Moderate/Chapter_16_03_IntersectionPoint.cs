namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  // TODO: Add tests
  // TODO: finish problem
  public static class Chapter_16_03_IntersectionPoint
  {
    public static bool Execute(Point firstStart, Point firstEnd, Point secondStart, Point secondEnd)
    {
      // y = mx + b
      // assume b is the same or zero
      // calculate line formula for each line
      var firstLine = new Line(firstStart, firstEnd);
      var secondLine = new Line(secondStart, secondEnd);

      return false;
    }

    public struct Point
    {
      public Point(int x, int y)
      {
        this.X = x;
        this.Y = y;
      }

      public int X { get; }

      public int Y { get; }
    }

    public struct Line
    {
      public Line(Point start, Point end)
      {
        int deltaY = end.Y - start.Y;
        int deltaX = end.X - start.X;
        this.M = deltaY / deltaX;
        this.B = end.Y - (this.M * end.X);
      }

      public double M { get; }

      public double B { get; }
    }
  }
}
