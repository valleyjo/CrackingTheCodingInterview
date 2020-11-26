namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings
{
    public class Problem_1_3_Urlify
    {

        /*
        "Mr John Smith      "
                    ^
        "                  h"
                          ^

        Copy from true length to end of array
        if current char is whitespace, write %20 at the end of the array
        move indexes towards begining of array
        */ 
        public static string Execute(char[] url, int trueLength)
        {
            if (url == null || url.Length == 0 || trueLength < 0 || trueLength > url.Length)
            {
                return string.Empty;
            }


            // Assume that there is enough space in the list to do in place
            for (int index = url.Length - 1, trueLengthIndex = trueLength - 1; index >= 0; index--, trueLengthIndex--)
            {
                // read current char and copy to the back
                char currentChar = url[trueLengthIndex];
                url[index] = currentChar;

                if (char.IsWhiteSpace(currentChar))
                {
                    // when whitespace is detected, insert '%20'
                    url[index] = '0';
                    url[index - 1] = '2';
                    url[index - 2] = '%';
                    // move index an additional two spaces forward
                    // regular decrement in for loop moves it up an additional space
                    index -= 2;
                }
            }

            // return a string for easier testing
            return new string(url);
        }

        /// <summary>
        /// Convert a string to a char array with enough whitespace
        /// Used for testing this problem rather than manually generating
        /// the input for testing
        /// </summary>
        /// <param name="s"></param>
        /// <returns>char array with original characters but with padding at the end</returns>
        public static char[] ConvertAndAddCapacity(string s)
        {
            int whiteSpaceCount = 0;
            foreach (char c in s)
            {
                if (char.IsWhiteSpace(c))
                {
                    whiteSpaceCount++;
                }
            }

            int expandedLength = s.Length + (2 * whiteSpaceCount);
            char[] expandedString = new char[expandedLength];
            for (int i = 0; i < s.Length; i++)
            {
                expandedString[i] = s[i];
            }

            return expandedString;
        }
    }
}
