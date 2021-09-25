namespace CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming.Problem_8_11_Coins;

  [TestClass]
  public class Problem_8_11_CoinsTests
  {
    [TestMethod]
    public void ZeroTest() => Solution.Execute(0).Should().Be(0);

    [TestMethod]
    public void OneTest() => Solution.Execute(1).Should().Be(1);

    [TestMethod]
    public void TwoTest() => Solution.Execute(2).Should().Be(1);

    [TestMethod]
    public void FourTest() => Solution.Execute(4).Should().Be(1);

    [TestMethod]
    public void FiveTest() => Solution.Execute(5).Should().Be(2);

    [TestMethod]
    public void TwentyFiveTest() => Solution.Execute(5).Should().Be(2);
  }
  }
}
