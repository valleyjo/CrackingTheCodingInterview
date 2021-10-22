namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Chapter_16_04_TicTacWin;

  [TestClass]
  public class Chapter_16_04_TicTacWinTests
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
