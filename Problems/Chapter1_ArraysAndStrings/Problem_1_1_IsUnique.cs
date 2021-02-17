namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings
{
  using System.Collections.Generic;

  public static class Problem_1_1_IsUnique
  {
    public static bool IsUnique(string s)
    {
      if (s == null || s == string.Empty)
      {
        return false;
      }

      var chars = new HashSet<char>();
      foreach (char c in s)
      {
        if (chars.Contains(c))
        {
          return false;
        }
        else
        {
          chars.Add(c);
        }
      }

      return true;
    }

    public static bool IsUniqueNoAlloc(string s)
    {
      if (s == null || s == string.Empty)
      {
        return false;
      }

      for (int i = 0; i < s.Length; i++)
      {
        for (int j = 0; j < s.Length; j++)
        {
          // don't compare the char to itself
          if (j == i)
          {
            continue;
          }

          if (s[j] == s[i])
          {
            return false;
          }
        }
      }

      return true;
    }
  }
}
