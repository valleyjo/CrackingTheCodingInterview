namespace CrackingTheCodingInterview.Problems.Chapter5_BitManipulation
{
  using System.Text;

  public static class Problem_5_2_BinaryToString
  {
    public static string Execute(double value)
    {
      if (value < 0 || value >= 1)
      {
        return "ERROR";
      }

      var result = new StringBuilder();
      result.Append('.');

      do
      {
        value *= 2;
        if (value >= 1)
        {
          result.Append('1');
          value -= 1;
        }
        else
        {
          result.Append('0');
        }
      }
      while (value > 0);

      return result.ToString();
    }
  }
}
