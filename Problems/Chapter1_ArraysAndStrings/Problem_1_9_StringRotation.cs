namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings
{
    public static class Problem_1_9_StringRotation
    {
        public static bool IsRotation(string original, string rotation)
        {
            if (string.IsNullOrEmpty(original) ||
                string.IsNullOrEmpty(rotation) ||
                original.Length != rotation.Length)
            {
                return false;
            }

            return (rotation + rotation).Contains(original);
        }
    }
}
