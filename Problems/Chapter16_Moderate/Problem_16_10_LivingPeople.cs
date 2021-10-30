namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;

  public static class Problem_16_10_LivingPeople
  {
    public static int Execute(Lifespan[] lifespans)
    {
      if (lifespans == null || lifespans.Length == 0)
      {
        return -1;
      }

      int[] aliveCounts = new int[100 + 1];
      foreach (Lifespan lifespan in lifespans)
      {
        aliveCounts[lifespan.BirthYear]++;

        // if alive at all for any given year they are "alive" for this purpose
        aliveCounts[lifespan.DeathYear + 1]--;
      }

      int maxAlive = -1;
      int currentAlive = 0;
      int maxYear = -1;
      for (int year = 0; year < aliveCounts.Length; year++)
      {
        currentAlive += aliveCounts[year];
        if (currentAlive > maxAlive)
        {
          maxAlive = currentAlive;
          maxYear = year;
        }
      }

      return maxYear;
    }

    public struct Lifespan
    {
      private readonly int birthYear;
      private readonly int deathYear;

      public Lifespan(int birthYear, int deathYear)
      {
        this.birthYear = birthYear;
        this.deathYear = deathYear;
      }

      public int BirthYear { get => this.birthYear % 100; }

      public int DeathYear { get => this.deathYear % 100; }
    }
  }
}
