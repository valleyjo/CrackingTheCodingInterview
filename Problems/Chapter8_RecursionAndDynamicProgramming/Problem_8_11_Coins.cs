namespace CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming
{
  public static class Problem_8_11_Coins
  {
    public static int Execute(int amount)
    {
      if (amount <= 0)
      {
        return 0;
      }

      int[] cache = new int[amount + 1];
      for (int i = 0; i <= amount; i++)
      {
        cache[i] = -1;
      }

      return Count(amount, cache);
    }

    private static int Count(int amount)
    {
      if (amount < 0)
      {
        return 0;
      }

      if (amount == 0)
      {
        return 1;
      }

      return Count(amount - 25) + Count(amount - 10) + Count(amount - 5) + Count(amount - 1);
    }

    private static int Count(int amount, int[] cache)
    {
      if (amount < 0)
      {
        return 0;
      }

      if (amount == 0)
      {
        return 1;
      }

      if (cache[amount] != -1)
      {
        return cache[amount];
      }

      cache[amount] = Count(amount - 25, cache) + Count(amount - 10, cache) + Count(amount - 5, cache) + Count(amount - 1, cache);
      return cache[amount];
    }
  }
}
