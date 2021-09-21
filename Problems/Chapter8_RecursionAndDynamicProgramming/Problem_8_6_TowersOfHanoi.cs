namespace CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming
{
  using System.Collections.Generic;

  public static class Problem_8_6_TowersOfHanoi
  {
    public static Stack<int> Execute(int size)
    {
      var first = new Stack<int>();
      var second = new Stack<int>();
      var third = new Stack<int>();

      for (int i = size; i > 0; i--)
      {
        first.Push(i);
      }

      MoveDisks(size, first, third, second);
      return third;
    }

    public static void MoveDisks(int n, Stack<int> source, Stack<int> dest, Stack<int> buffer)
    {
      if (n <= 0)
      {
        return;
      }

      MoveDisks(n - 1, source: source, dest: buffer, buffer: dest);
      MoveTop(source, dest);
      MoveDisks(n - 1, buffer, dest, source);
    }

    public static void MoveTop(Stack<int> source, Stack<int> dest) => dest.Push(source.Pop());
  }
}
