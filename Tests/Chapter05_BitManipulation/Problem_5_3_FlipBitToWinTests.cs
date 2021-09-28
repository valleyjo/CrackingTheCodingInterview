namespace CrackingTheCodingInterview.Problems.Chapter05_BitManipulation.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter05_BitManipulation.Problem_5_3_FlipBitToWin;

  [TestClass]
  public class Problem_5_3_FlipBitToWinTests
  {
    [TestMethod]
    public void ZeroTest() => Solution.Execute(0).Should().Be(1);

    [TestMethod]
    public void MaxValueTest() => Solution.Execute(int.MaxValue).Should().Be(32);

    [TestMethod]
    public void MinValueTest() => Solution.Execute(int.MinValue).Should().Be(2);

    [TestMethod]
    public void NormalTest() => Solution.Execute(1775).Should().Be(8);

    [TestMethod]
    public void EndsInOneForLongestSequenceTest() => Solution.Execute(0b1101110111).Should().Be(7);

    [TestMethod]
    public void EndsInZeroTest() => Solution.Execute(10).Should().Be(2);

    [TestMethod]
    public void ExecuteFaster_ZeroTest() => Solution.ExecuteFaster(0).Should().Be(1);

    [TestMethod]
    public void ExecuteFaster_MaxValueTest() => Solution.ExecuteFaster(int.MaxValue).Should().Be(32);

    [TestMethod]
    public void ExecuteFaster_MinValueTest() => Solution.ExecuteFaster(int.MinValue).Should().Be(1);

    [TestMethod]
    public void ExecuteFaster_NormalTest() => Solution.ExecuteFaster(1775).Should().Be(8);

    [TestMethod]
    public void ExecuteFaster_EndsInOneForLongestSequenceTest() => Solution.ExecuteFaster(0b1101110111).Should().Be(7);

    [TestMethod]
    public void ExecuteFaster_EndsInZeroTest() => Solution.ExecuteFaster(10).Should().Be(2);
  }
}
