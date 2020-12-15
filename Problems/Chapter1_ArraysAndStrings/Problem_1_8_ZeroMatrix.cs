namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings
{
    using System;
    using System.Collections.Generic;

    public class Problem_1_8_ZeroMatrix
    {
        // in C# use the multidimensional array when you are representing an MxN matrix
        // use a jagged array int[][] when you need variable length arrays
        /*
        iterate through the matrix.
        if m[n,p] == 0 => set the rows and columns to zero
        */
        public static void Execute(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix.GetLength(0) == 0)
            {
                return;
            }

            var zeroRows = new HashSet<int>();
            var zeroCols = new HashSet<int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0 && !zeroRows.Contains(row) && !zeroCols.Contains(col))
                    {
                        ZeroCol(matrix, col);
                        ZeroRow(matrix, row);

                        zeroRows.Add(row);
                        zeroCols.Add(col);
                    }
                }
            }
        }

        private static void ZeroRow(int[,] matrix, int row)
        {
            for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
            {
                matrix[row, colIndex] = 0;
            }
        }

        private static void ZeroCol(int[,] matrix, int col)
        {
            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                matrix[rowIndex, col] = 0;
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine("[");
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    Console.Write(matrix[row, col]);
                    Console.Write(", ");
                }

                Console.Write("]");
            }
        }
    }
}
