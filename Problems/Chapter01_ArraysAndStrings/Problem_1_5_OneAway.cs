namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings
{
  using System;

  public class Problem_1_5_OneAway
  {
    /*
    edits: insert, remove, change
    always:
        - abs(len1 - len2) > 1 -> return false
        - positions must be the same

    insert:
        - all the same letters, except one new one

    remove:
        - all the same letters except one new one

    change:
        - all the same letters except one is different

    1) validity check
    2) one iteration
    3) maintain bool for within correctness window
    4) when letter is different:
        a. if still ok, mark as not OK. Move index fwd for longer str. If == len do nothing
        b. if not OK, return false

    afreddy
          ^
    freddy
         ^
    */
    public static bool Execute(string one, string two)
    {
      if (string.IsNullOrEmpty(one) || string.IsNullOrEmpty(two))
      {
        return false;
      }

      // must always be one edit away
      // difference > 1 means it's more than one insert / remove away
      if (Math.Abs(one.Length - two.Length) > 1)
      {
        return false;
      }

      bool stillValid = true;
      for (int oneIndex = 0, twoIndex = 0; oneIndex < one.Length && twoIndex < two.Length; oneIndex++, twoIndex++)
      {
        char oneChar = one[oneIndex];
        char twoChar = two[twoIndex];

        if (oneChar != twoChar)
        {
          if (!stillValid)
          {
            return false;
          }

          stillValid = false;

          // normalize the indexes after a difference
          // removes and inserts are covered by moving the longer index forward an extra space
          // changes are covered automatically because the lengths should be the same and all next
          // chars must be equal
          if (one.Length > two.Length)
          {
            oneIndex++;
          }
          else if (two.Length > one.Length)
          {
            twoIndex++;
          }
        }
      }

      return true;
    }
  }
}
