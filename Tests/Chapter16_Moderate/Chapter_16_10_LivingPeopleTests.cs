namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Chapter_16_10_LivingPeople;

  [TestClass]
  public class Chapter_16_10_LivingPeopleTests
  {
    [TestMethod]
    public void NullTest()
    {
      Solution.Execute(null).Should().Be(-1);
    }

    [TestMethod]
    public void EmptyTest()
    {
      Solution.Execute(Array.Empty<Solution.Lifespan>()).Should().Be(-1);
    }

    [TestMethod]
    public void BasicTest()
    {
      var lifespans = new Solution.Lifespan[]
      {
        new Solution.Lifespan(0, 90),
        new Solution.Lifespan(5, 15),
        new Solution.Lifespan(7, 7),
      };

      Solution.Execute(lifespans).Should().Be(7);
    }
  }
}
