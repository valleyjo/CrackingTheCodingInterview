namespace CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming
{
  using System;

  public static class Problem_8_14_BooleanExpression
  {
    public static int Execute(string input, bool targetResult)
    {
      if (string.IsNullOrEmpty(input))
      {
        throw new ArgumentException("input cannot be null or empty", nameof(input));
      }

      if (input.Length == 1)
      {
        bool result = input == "1";
        return result == targetResult ? 1 : 0;
      }

      int totalWaysMatchingTargetCount = 0;
      for (int i = 1; i < input.Length; i += 2)
      {
        string left = input.Substring(0, i);
        string right = input.Substring(i + 1);
        char operation = input[i];

        int leftTrueCount = Execute(left, true);
        int leftFalseCount = Execute(left, false);
        int rightTrueCount = Execute(right, true);
        int rightFalseCount = Execute(right, false);
        int totalWaysCount = (leftTrueCount + leftFalseCount) * (rightTrueCount + rightFalseCount);

        int totalTrue = 0;
        if (operation == '^')
        {
          totalTrue = (leftTrueCount * rightFalseCount) + (leftFalseCount * rightTrueCount);
        }
        else if (operation == '&')
        {
          totalTrue = leftTrueCount * rightTrueCount;
        }
        else if (operation == '|')
        {
          totalTrue = (leftTrueCount * rightTrueCount) + (leftFalseCount * rightTrueCount) + (leftTrueCount * rightFalseCount);
        }

        totalWaysMatchingTargetCount += targetResult ? totalTrue : totalWaysCount - totalTrue;
      }

      return totalWaysMatchingTargetCount;
    }
  }
}
