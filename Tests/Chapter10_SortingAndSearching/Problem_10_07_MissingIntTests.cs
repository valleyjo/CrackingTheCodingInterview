namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Tests
{
  using System;
  using System.IO;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Problem_10_07_MissingInt;

  [TestClass]
  public class Problem_10_07_MissingIntTests
  {
    [TestMethod]
    public void DuplicateTest()
    {
      var stream = new MemoryStream();
      stream.Write(BitConverter.GetBytes(1), 0 * sizeof(int), sizeof(int));
      stream.Write(BitConverter.GetBytes(2), 1 * sizeof(int), sizeof(int));
      stream.Write(BitConverter.GetBytes(3), 2 * sizeof(int), sizeof(int));
      stream.Write(BitConverter.GetBytes(1), 3 * sizeof(int), sizeof(int));
      Solution.Execute(stream).Should().Be(1);
    }
  }
}
