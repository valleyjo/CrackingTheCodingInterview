namespace CrackingTheCodingInterview.Problems.Chapter05_BitManipulation.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter05_BitManipulation.Problem_5_7_PairwiseSwap;

  [TestClass]
  public class Problem_5_7_PairwiseSwapTests
  {
    [TestMethod]
    public void ZerosTest() => Solution.Execute(0).Should().Be(0);

    [TestMethod]
    public void OnesTest() => Solution.Execute(uint.MaxValue).Should().Be(uint.MaxValue);

    [TestMethod]
    public void NormalTest() => Solution.Execute(0b101101).Should().Be(0b011110);
  }
}
