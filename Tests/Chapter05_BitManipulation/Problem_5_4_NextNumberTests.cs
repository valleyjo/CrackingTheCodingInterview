namespace CrackingTheCodingInterview.Problems.Chapter5_BitManipulation.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter5_BitManipulation.Problem_5_4_NextNumbers;

  [TestClass]
  public class Problem_5_4_NextNumberTests
  {
    [TestMethod]
    public void ZeroTest()
    {
      uint input = 0b11011001111100;
      uint small = 0b11011001001111;
      uint biggg = 0b11011010001111;
      Solution.Execute(input, out uint smaller, out uint biggier);
      biggier.Should().Be(small);
      smaller.Should().Be(biggg);
    }
  }
}
