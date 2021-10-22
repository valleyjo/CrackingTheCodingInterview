namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Chapter_16_01_NumberSwapper;

  [TestClass]
  public class Chapter_16_01_NumberSwapperTests
  {
    [TestMethod]
    public void SwapTest()
    {
      int one = 5;
      int two = 3;
      Solution.Execute(ref one, ref two);
      one.Should().Be(3);
      two.Should().Be(5);
    }
  }
}
