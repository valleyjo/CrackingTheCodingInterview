namespace CrackingTheCodingInterview.Problems.Chapter01_ArraysAndStrings.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Problem = CrackingTheCodingInterview.Problems.Chapter01_ArraysAndStrings.Problem_1_8_ZeroMatrix;

  [TestClass]
  public class Problem_1_8_ZeroMatrixTests
  {
    [TestMethod]
    public void OneZeroTest()
    {
      int[,] matrix = new int[,]
      {
                { 1, 0, 1, 1, },
                { 1, 1, 1, 1, },
                { 1, 1, 1, 1, },
      };

      int[,] zeroedMatrix = new int[,]
      {
                { 0, 0, 0, 0, },
                { 1, 0, 1, 1, },
                { 1, 0, 1, 1, },
      };

      Problem.Execute(matrix);
      matrix.Should().BeEquivalentTo(zeroedMatrix);
    }

    [TestMethod]
    public void TwoZeroTest()
    {
      int[,] matrix = new int[,]
      {
                { 1, 0, 1, 1, },
                { 1, 1, 0, 1, },
                { 1, 1, 1, 1, },
      };

      int[,] zeroedMatrix = new int[,]
      {
                { 0, 0, 0, 0, },
                { 0, 0, 0, 0, },
                { 1, 0, 0, 1, },
      };

      Problem.Execute(matrix);
      matrix.Should().BeEquivalentTo(zeroedMatrix);
    }
  }
}
