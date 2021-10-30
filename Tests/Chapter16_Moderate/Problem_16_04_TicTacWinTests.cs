namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Problem_16_04_TicTacWin;

  [TestClass]
  public class Problem_16_04_TicTacWinTests
  {
    [TestMethod]
    public void TicTacWinTest()
    {
      char[,] board = new char[,]
      {
        { 'x', 'o', 'x' },
        { 'x', 'o', 'x' },
        { 'o', 'x', 'o' },
      };

      Solution.Execute(board).Should().Be('t');
    }
  }
}
