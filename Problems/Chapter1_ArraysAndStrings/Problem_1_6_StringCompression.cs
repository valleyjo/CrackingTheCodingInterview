using System.Text;

namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings
{
    public static class Problem_1_6_StringCompression
    {
        /*
        implement basic string compression
        aabbbbbcddd => a2b5c1d3

        one iteration
        maintain lastChar and count
        if current char != last char
            add char and count to string builder
        else
            count++

        !!! be sure to add last char at the end of the loop!!!

        return smaller length string

        any edge cases?
        null / empty
        compressed str longer than regular one (all different chars)
        normal case
        all one char
        two char string
        one char string
        */
        public static string Execute(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            var builder = new StringBuilder();
            char lastChar = input[0];
            int count = 1;
            for (int i = 1; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (lastChar != currentChar)
                {
                    builder.Append($"{lastChar}{count}");
                    count = 1;
                }
                else
                {
                    count++;
                }
                lastChar = currentChar;
            }

            builder.Append($"{lastChar}{count}");

            return builder.Length < input.Length ? builder.ToString() : input;
        }
    }
}
