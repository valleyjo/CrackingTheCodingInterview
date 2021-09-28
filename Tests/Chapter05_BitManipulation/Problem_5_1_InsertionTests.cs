namespace CrackingTheCodingInterview.Problems.Chapter5_BitManipulation.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter5_BitManipulation.Problem_5_1_Insertion;

  [TestClass]
  public class Problem_5_1_InsertionTests
  {
    [TestMethod]
    public void InsertionTest()
    {
      Solution.Execute(
        0b11011,
        0b1001111,
        1,
        5).Should().Be(0b1110111);
    }
  }
}
