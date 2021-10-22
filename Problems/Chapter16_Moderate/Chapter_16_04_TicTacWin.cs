namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public static class Chapter_16_04_TicTacWin
  {
    /// <summary>
    /// Determine which player won tic tac toe
    /// </summary>
    /// <param name="board">The game board, expected to be 3x3 and contain only 'x' or 'o' values</param>
    /// <returns>x if x won, y if y won, t if there is a tie</returns>
    public static char Execute(char[,] board)
    {
      // board must be square and 3x3
      if (board == null || board.GetLength(0) != 3 || board.GetLength(0) != board.GetLength(1))
      {
        return 't';
      }

      for (int col = 0; col < board.GetLength(0); col++)
      {
        if (CheckVerticalWin(board, col))
        {
          return board[0, col];
        }
      }

      for (int row = 0; row < board.GetLength(0); row++)
      {
        if (CheckHorizontalWin(board, row))
        {
          return board[row, 0];
        }
      }

      char target = board[0, 0];
      bool diagWinner = false;
      for (int row = 1, col = 1; row < board.GetLength(0) && !diagWinner; row++, col++)
      {
        diagWinner &= board[row, col] == target;
      }

      if (diagWinner)
      {
        return board[0, 0];
      }

      int lastRow = board.GetLength(0) - 1;
      target = board[lastRow, 0];
      for (int row = lastRow, col = 0; col <= lastRow && !diagWinner; row--, col++)
      {
        diagWinner &= board[row, col] == target;
      }

      if (diagWinner)
      {
        return board[lastRow, 0];
      }

      return 't';
    }

    private static bool CheckHorizontalWin(char[,] board, int row)
    {
      char target = board[row, 0];
      for (int col = 1; col < board.GetLength(0); col++)
      {
        if (board[row, col] != target)
        {
          return false;
        }
      }

      return true;
    }

    private static bool CheckVerticalWin(char[,] board, int col)
    {
      char target = board[0, col];
      for (int row = 1; row < board.GetLength(0); row++)
      {
        if (board[row, col] != target)
        {
          return false;
        }
      }

      return true;
    }
  }
}
