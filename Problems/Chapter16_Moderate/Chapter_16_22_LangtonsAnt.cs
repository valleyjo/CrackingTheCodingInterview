namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;
  using System.Text;

  public static class Chapter_16_22_LangtonsAnt
  {
    public static string Execute(int k)
    {
      var grid = new Grid(new Position());

      for (int i = 0; i < k; i++)
      {
        grid.ExecuteOne();
      }

      return grid.ToString();
    }

    private class Position
    {
      private Direction direction = Direction.Right;

      private enum Direction
      {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3,
      }

      public int Row { get; set; }

      public int Col { get; set; }

      public void Move()
      {
        switch (this.direction)
        {
          case Direction.Right:
            this.Col++;
            break;
          case Direction.Left:
            this.Col--;
            break;
          case Direction.Up:
            this.Row++;
            break;
          case Direction.Down:
            this.Row--;
            break;
        }
      }

      public void Rotate(int color)
      {
        if (color == 0)
        {
          color = -1;
        }

        int rotation = (int)(this.direction + color);
        if (rotation == -1)
        {
          // rotated from up to left, reset the position to left
          rotation = 3;
        }
        else if (rotation == 4)
        {
          // rotated from left to up, manually reset the position
          rotation = 0;
        }

        this.direction = (Direction)rotation;
      }

      public override string ToString() => $"[{this.Row}, {this.Col}]";
    }

    private class Grid
    {
      private readonly List<List<int>> grid;
      private readonly Position pos;
      private readonly Random rand;

      public Grid(Position pos)
      {
        this.rand = new Random();
        this.grid = new List<List<int>>() { new List<int>() { 0 } };
        this.pos = pos;
      }

      public void ExecuteOne()
      {
        this.pos.Move();
        this.AdjustForPosition();
        this.AfterMoveActions();
      }

      public override string ToString()
      {
        var sb = new StringBuilder();
        sb.Append(this.pos.ToString());
        sb.Append(Environment.NewLine);
        foreach (List<int> row in this.grid)
        {
          sb.Append(string.Join(", ", row));
          sb.Append(Environment.NewLine);
        }

        return sb.ToString();
      }

      private void AdjustForPosition()
      {
        int currentColCount = this.grid[0].Count;

        if (this.grid.Count == this.pos.Row)
        {
          this.grid.Insert(0, this.GetInitializedRow(currentColCount));
        }
        else if (this.pos.Row < 0)
        {
          // TODO: Fix tight coupling here
          this.pos.Row = 0;
          this.grid.Add(this.GetInitializedRow(currentColCount));
        }

        if (currentColCount == this.pos.Col)
        {
          foreach (List<int> row in this.grid)
          {
            row.Add(this.GetDefaultCellValue());
          }
        }
        else if (this.pos.Col < 0)
        {
          // TODO: Fix tight coupling here
          this.pos.Col = 0;
          foreach (List<int> row in this.grid)
          {
            row.Insert(0, this.GetDefaultCellValue());
          }
        }
      }

      private void AfterMoveActions()
      {
        this.pos.Rotate(this.grid[this.pos.Row][this.pos.Col]);
        this.grid[this.pos.Row][this.pos.Col] = this.grid[this.pos.Row][this.pos.Col] ^ 1; // flip the value
      }

      private int GetDefaultCellValue()
      {
        ////return 0;
        return this.rand.Next(0, 2);
      }

      private List<int> GetInitializedRow(int currentColCount)
      {
        var newRow = new List<int>(currentColCount);
        for (int i = 0; i < currentColCount; i++)
        {
          newRow.Add(this.GetDefaultCellValue());
        }

        return newRow;
      }
    }
  }
}
