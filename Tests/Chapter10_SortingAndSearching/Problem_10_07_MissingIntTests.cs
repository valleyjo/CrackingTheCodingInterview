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
    public void GenerateMissingIntTest()
    {
      var stream = new MemoryStream();
      stream.Write(BitConverter.GetBytes(0), 0, sizeof(int));
      stream.Write(BitConverter.GetBytes(1), 0, sizeof(int));
      stream.Write(BitConverter.GetBytes(2), 0, sizeof(int));
      stream.Write(BitConverter.GetBytes(3), 0, sizeof(int));
      stream.Seek(0, SeekOrigin.Begin);
      Solution.Execute(stream).Should().Be(4);
    }
  }
}
