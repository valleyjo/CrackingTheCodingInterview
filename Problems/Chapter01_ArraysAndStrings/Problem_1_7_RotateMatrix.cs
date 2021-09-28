namespace CrackingTheCodingInterview.Problems.Chapter01_ArraysAndStrings
{
    public static class Problem_1_7_RotateMatrix
    {
        /*
        1, 2, 3,
        4, 5, 6,
        7, 8, 9,

        7, 4, 1,
        8, 5, 2,
        9, 6, 3,

        1, 2
        3, 4

        3, 1
        4, 2

        test cases:
        null / empty
        n = 1
        n = 2
        n = 3
        n = 5

        copy data to be overwritten
        overwrite data with flipped data

        how to go:
        vertical: row - i, col
        horizontal: row, col - i

        how to know indexes:
        row     | col
        0       | col - 1
        row - 1 | col - 1
        row - 1 | 0
        0       | col - 1

         */
        public static void Execute(int[][] image)
        {
            if (image == null || image.Length == 1 || image.Length != image[0].Length)
            {
                return;
            }

            int n = image.Length;

            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;

                for (int i = first; i < last; i++)
                {
                    int offset = i - first;
                    int top = image[first][i];

                    // left -> top
                    image[first][i] = image[last - offset][first];

                    // bottom -> left
                    image[last - offset][first] = image[last][last - offset];

                    // right -> bottom
                    image[last][last - offset] = image[i][last];

                    // top -> right
                    image[i][last] = top;
                }
            }
        }
    }
}
