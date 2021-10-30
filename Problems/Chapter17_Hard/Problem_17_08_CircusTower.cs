namespace CrackingTheCodingInterview.Problems.Chapter17_Hard
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public static class Problem_17_08_CircusTower
  {
    public static int Execute(Person[] people)
    {
      if (people == null || people.Length == 0)
      {
        return -1;
      }

      Array.Sort(people);

      int[] maxSize = new int[people.Length];
      maxSize[0] = 1;
      int overallMax = 1;
      for (int i = 1; i < people.Length; i++)
      {
        int currentMax = 1; // can always get a max of 1 by starting a tower with this person
        for (int j = i - 1; j >= 0; j--)
        {
          // must make this check to ensure the weight is OK
          if (people[i].IsBiggerThan(people[j]))
          {
            currentMax = Math.Max(currentMax, maxSize[j]);
          }
        }

        maxSize[i] = currentMax;
        overallMax = Math.Max(currentMax, overallMax);
      }

      return overallMax;
    }

    public struct Person : IComparable<Person>
    {
      public Person(int height, int weight)
      {
        this.Height = height;
        this.Weight = weight;
      }

      public int Weight { get; private set; }

      public int Height { get; private set; }

      public int CompareTo(Person other) => this.Height - other.Height;

      public bool IsBiggerThan(Person other) => this.Height >= other.Height && this.Weight >= other.Weight;
    }
  }
}
