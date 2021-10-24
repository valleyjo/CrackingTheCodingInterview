namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;
  using System.Threading;

  public static class Chapter_16_26_Calculator
  {
    public static double Execute(string input)
    {
      if (string.IsNullOrEmpty(input) || input.Length < 3)
      {
        throw new ArgumentException(nameof(input));
      }

      var num = new Stack<double>();
      var op = new Stack<char>();
      num.Push(ExtractNum(input, 0, out int endIndex));
      op.Push(input[endIndex]);

      for (int i = endIndex + 1; i < input.Length;)
      {
        // read the next number and operator
        // endIndex is the index of the operator
        double nextNum = ExtractNum(input, i, out endIndex);
        num.Push(nextNum);

        // if we are at the end of the string, give a "fake" operator which
        // returns infinite priority
        char nextOp = endIndex < input.Length ? input[endIndex] : '$';
        i = endIndex + 1;

        while (op.Count > 0 && Priority(op.Peek()) < Priority(nextOp))
        {
          num.Push(Eval(num, op));
        }

        if (nextOp != '$')
        {
          op.Push(nextOp);
        }
      }

      while (op.Count > 0 && num.Count > 0)
      {
        num.Push(Eval(num, op));
      }

      return num.Peek();
    }

    private static double ExtractNum(string input, int startIndex, out int endIndex)
    {
      endIndex = int.MaxValue;
      char[] ops = new char[] { '*', '/', '+', '-' };
      foreach (char op in ops)
      {
        int nextOpIndex = input.IndexOf(op, startIndex);
        if (nextOpIndex != -1)
        {
          endIndex = Math.Min(nextOpIndex, endIndex);
        }
      }

      // if we don't have another operator the rest of the string must be a number
      endIndex = endIndex == int.MaxValue ? input.Length : endIndex;

      int length = endIndex - startIndex;
      return double.Parse(input.Substring(startIndex, length));
    }

    private static double Eval(Stack<double> num, Stack<char> ops)
    {
      double result;
      double rightNum = num.Pop();
      double leftNum = num.Pop();
      char op = ops.Pop();
      if (op == '*')
      {
        result = leftNum * rightNum;
      }
      else if (op == '/')
      {
        result = leftNum / rightNum;
      }
      else if (op == '+')
      {
        result = leftNum + rightNum;
      }
      else
      {
        // TODO: input validation for operator
        result = leftNum - rightNum;
      }

      return result;
    }

    private static int Priority(char op) => op switch
    {
      '*' => 0,
      '/' => 1,
      '+' => 2,
      '-' => 3,
      _ => int.MaxValue,
    };
  }
}
