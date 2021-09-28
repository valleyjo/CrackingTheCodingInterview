namespace CrackingTheCodingInterview.Problems.Chapter08_RecursionAndDynamicProgramming
{
  public static class Problem_8_01_TripleStep
  {
    public static int Execute(int n)
    {
      // if we "jumped over" the top step, don't count that as a way to reach
      // the top
      if (n == 1 || n == 0)
      {
        return 1;
      }
      else if (n < 0)
      {
        return 0;
      }

      return Execute(n - 1) + Execute(n - 2) + Execute(n - 3);
    }

    public static int ExecuteMemo(int n)
    {
      int[] numWays = new int[n + 1];
      for (int i = 0; i < numWays.Length; i++)
      {
        numWays[i] = -1;
      }

      return Execute(n, numWays);
    }

    private static int Execute(int n, int[] numWays)
    {
      if (n == 1 || n == 0)
      {
        return 1;
      }
      else if (n < 0)
      {
        return 0;
      }

      if (numWays[n] == -1)
      {
        numWays[n] = Execute(n - 1, numWays) + Execute(n - 2, numWays) + Execute(n - 3, numWays);
      }

      return numWays[n];
    }
  }
}
