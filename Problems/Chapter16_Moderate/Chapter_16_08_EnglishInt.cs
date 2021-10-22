namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  // TODO: Finish
  public static class Chapter_16_08_EnglishInt
  {
    private static readonly string[] Ones = new string[] { string.Empty, " one ", " two ", " three ", " four ", " five ", " six ", " seven ", " eight ", " nine ", };
    private static readonly string[] Teens = new string[] { string.Empty, " ten ", " eleven ", " twelve ", " thirteen ", " fourteen ", " fifteen ", " sixteen ", " seventeen ", " eightteen ", " nineteen " };
    private static readonly string[] Tens = new string[] { string.Empty, " twenty ", " thirty ", " fourty ", " fifty ", " sixty ", " seventy ", " eighty ", " ninty ", };
    private static readonly string[] BigNumbers = new string[] { string.Empty, " hundred ", " thousand ", " million ", " billion ", }; // 2^32 only goes to 4.2 Billion

    public static string Execute(int value)
    {
      if (value == 0)
      {
        return "zero";
      }

      var sb = new StringBuilder();

      int hundreds = (value % 1000) / 100;
      sb.Append(Ones[hundreds]);
      if (hundreds > 0)
      {
        sb.Append(" hundred ");
      }

      int tens = (value % 100) / 10;
      sb.Append(Tens[tens]);

      int ones = value % 10;
      sb.Append(Ones[ones]);

      for (int i = 1; i <= value; i *= 10)
      {
        int index = (value % (i * 10)) / i;
        sb.Append(BigNumbers[index]);
      }

      return sb.ToString();
    }
  }
}
