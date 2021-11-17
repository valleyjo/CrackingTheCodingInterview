namespace CrackingTheCodingInterview.Problems.Chapter08_RecursionAndDynamicProgramming
{
  public static class Problem_8_10_PaintFill
  {
    public static uint[,] Execute(uint[,] input, uint row, uint col, uint newColor)
    {
      if (input == null || input.Length == 0)
      {
        return input;
      }

      // let this throw index out of range exception to inform the caller the row and or col values are invalid
      uint selectedColor = input[row, col];
      Execute(input, row, col, newColor, selectedColor);

      return input;
    }

    private static void Execute(uint[,] input, uint row, uint col, uint newColor, uint selectedColor)
    {
      // row out of range
      // col out of range
      // pixel is already the final color
      // pixel is not the droid we are looking for
      if (
        input.GetLength(0) - 1 < row ||
        row < 0 ||
        input.GetLength(1) - 1 < col ||
        col < 0 ||
        input[row, col] == newColor ||
        input[row, col] != selectedColor)
      {
        return;
      }

      // replace the pixel color and attempt to replace the neighbors
      input[row, col] = newColor;
      Execute(input, row + 1, col, newColor, selectedColor);
      Execute(input, row - 1, col, newColor, selectedColor);
      Execute(input, row, col + 1, newColor, selectedColor);
      Execute(input, row, col - 1, newColor, selectedColor);
    }
  }
}
