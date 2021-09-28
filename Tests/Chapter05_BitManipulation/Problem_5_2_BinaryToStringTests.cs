namespace CrackingTheCodingInterview.Problems.Chapter05_BitManipulation.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter05_BitManipulation.Problem_5_2_BinaryToString;

  [TestClass]
  public class Problem_5_2_BinaryToStringTests
  {
    [TestMethod]
    public void TooBigTest() => Solution.Execute(1).Should().Be("ERROR");

    [TestMethod]
    public void TooSmallTest() => Solution.Execute(-1).Should().Be("ERROR");

    [TestMethod]
    public void JustRightTest() => Solution.Execute(.6875).Should().Be(".1011");

    [TestMethod]
    public void ZeroTest() => Solution.Execute(0).Should().Be(".0");
  }
}
