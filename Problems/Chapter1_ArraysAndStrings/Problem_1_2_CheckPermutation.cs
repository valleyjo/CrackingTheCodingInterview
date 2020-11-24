using System.Reflection.Metadata;

namespace Problems.Chapter1_ArraysAndStrings
{
    public static class Problem_1_2_CheckPermutation
    {
        private const int AlphabetSize = 'z' - 'A' + 1;

        /*
        what is a permutation?
        when two strings have the same characters in a different sequence.
        how can I make one sequence from another sequence? if they have the same chars.
        */

        public static bool Execute(string one, string two)
        {
            if (one == null ||
                one == string.Empty ||
                two == null ||
                two == string.Empty ||
                one.Length != two.Length)
            {
                return false;
            }

            return CheckPermutation_LessAlloc(one, two);
        }

        public static bool CheckPermutation(string one, string two)
        {
            var oneCharCounts = new int[AlphabetSize];
            var twoCharCounts = new int[AlphabetSize];
            for (int i = 0; i < one.Length; i++)
            {
                oneCharCounts[CharToIndex(one[i])]++;
                twoCharCounts[CharToIndex(two[i])]++;
            }

            if (oneCharCounts.Length != twoCharCounts.Length)
            {
                return false;
            }

            for (int i = 0; i < oneCharCounts.Length; i++)
            {
                if (oneCharCounts[i] != twoCharCounts[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CheckPermutation_LessAlloc(string one, string two)
        {    
            var oneCharCounts = new int[AlphabetSize];
            for (int i = 0; i < one.Length; i++)
            {
                oneCharCounts[CharToIndex(one[i])]++;
            }

            for (int i = 0; i < one.Length; i++)
            {
                int twoCharIndex = CharToIndex(two[i]);
                oneCharCounts[twoCharIndex]--;
                if (oneCharCounts[twoCharIndex] < 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static int CharToIndex(char c) => c - 'A';
    }
}
