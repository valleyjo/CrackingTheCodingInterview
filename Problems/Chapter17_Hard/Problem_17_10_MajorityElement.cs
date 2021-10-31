namespace CrackingTheCodingInterview.Problems.Chapter17_Hard
{
  public static class Problem_17_10_MajorityElement
  {
    public static int Execute(int[] input)
    {
      if (input == null || input.Length == 0)
      {
        return -1;
      }

      int value = input[0];
      int count = 1;
      for (int i = 1; i < input.Length; i++)
      {
        if (input[i] == value)
        {
          count++;
        }
        else
        {
          count--;
        }

        if (count == 0)
        {
          value = input[i];
          count = 1;
        }
      }

      count = 0;
      foreach (int v in input)
      {
        if (v == value)
        {
          count++;
        }
      }

      if (count > (input.Length / 2))
      {
        return value;
      }

      return -1;
    }
  }
}
