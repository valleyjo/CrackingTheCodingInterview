namespace CrackingTheCodingInterview.Problems.Special
{
  using System;
  using System.Collections.Generic;

  public static class Problem_g_03_BroadcastAndShutdown
  {
    // assume routers contains start and dest
    // assume non-null input
    public static bool Execute(List<Router> routers, Router start, Router dest)
    {
      if (start.Equals(dest))
      {
        return true;
      }

      foreach (Router nextRouter in routers)
      {
        // skip disabled routers
        if (!nextRouter.Enabled)
        {
          continue;
        }

        // ASSUME: manhattan distance.
        // alt 1: diagonal distance, pythagran therorem.
        if (start.CanTransmitTo(nextRouter))
        {
          // disable the router and recurse
          nextRouter.Enabled = false;
          if (Execute(routers, nextRouter, dest))
          {
            return true;
          }

          // re-enable the router as we travel down another path
          nextRouter.Enabled = true;
        }
      }

      return false;
    }

    // Enabled field is used.
    // TRADEOFF: O(r) iteration at each branch level. ALT: Copy into new structure each time, copys reduced over time but expensive
    // r = number of routers
    public class Router
    {
      public Router(string name, int col, int row, int transmissionRadius = 10)
      {
        this.Name = name;
        this.Col = col;
        this.Row = row;
        this.Enabled = true;
        this.TransmissionRadius = transmissionRadius;
      }

      public string Name { get; set; }

      public int Col { get; set; }

      public int Row { get; set; }

      public int TransmissionRadius { get; set; }

      public bool Enabled { get; set; }

      public bool CanTransmitTo(Router end)
      {
        double distance = GetManhattanDistance(this, end);
        return distance <= this.TransmissionRadius;
      }

      private static int GetManhattanDistance(Router start, Router end)
      {
        int rowDistance = Math.Abs(start.Row - end.Row);
        int colDistance = Math.Abs(start.Col - end.Col);
        return rowDistance + colDistance;
      }

      private static int GetHorizontalDistance(Router start, Router end)
      {
        int rowDistance = Math.Abs(start.Row - end.Row);
        int colDistance = Math.Abs(start.Col - end.Col);
        double diag = Math.Sqrt(Math.Pow(rowDistance, 2) + Math.Pow(colDistance, 2));
        return (int)Math.Floor(diag);
      }
    }
  }
}
