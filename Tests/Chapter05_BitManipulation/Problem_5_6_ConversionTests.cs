namespace CrackingTheCodingInterview.Problems.Chapter05_BitManipulation.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter05_BitManipulation.Problem_5_6_Conversion;

  [TestClass]
  public class Problem_5_6_ConversionTests
  {
    [TestMethod]
    public void ZeroFlipsTest() => Solution.Execute(0, 0).Should().Be(0);

    [TestMethod]
    public void MaxFlipsTest() => Solution.Execute(-1, 0).Should().Be(sizeof(int) * 8);

    [TestMethod]
    public void SameNumberTest() => Solution.Execute(2021, 2021).Should().Be(0);

    [TestMethod]
    public void FlipsTest() => Solution.Execute(0b11010, 0b01110).Should().Be(2);
  }
}
