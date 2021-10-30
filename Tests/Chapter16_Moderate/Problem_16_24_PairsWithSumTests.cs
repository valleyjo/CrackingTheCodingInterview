namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Problem_16_24_PairsWithSum;

  // TODO: Add more tests
  [TestClass]
  public class Problem_16_24_PairsWithSumTests
  {
    [TestMethod]
    public void IAmGettingLazyTest()
    {
      Solution.Execute(new int[] { 1, 2, 3, 5, 1, 4, 3, 5, 3 }, 6).Should().BeEquivalentTo(
        new List<Solution.Result>()
        {
          new Solution.Result()
          {
            One = 1,
            Two = 5,
          },
          new Solution.Result()
          {
            One = 2,
            Two = 4,
          },
          new Solution.Result()
          {
            One = 3,
            Two = 3,
          },
          new Solution.Result()
          {
            One = 1,
            Two = 5,
          },
        });
    }
  }
}
