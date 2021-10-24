namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Threading;

  public static class Chapter_16_23_Rand7FromRand5
  {
    private static readonly AsyncLocal<Random> Rand = new();

    public static int Execute()
    {
      if (Rand.Value == null)
      {
        Rand.Value = new Random();
      }

      static int Rand5() => Rand.Value.Next(0, 5);

      while (true)
      {
        int value = (5 * Rand5()) + Rand5();
        if (value < 21)
        {
          return value % 7;
        }
      }
    }
  }
}
