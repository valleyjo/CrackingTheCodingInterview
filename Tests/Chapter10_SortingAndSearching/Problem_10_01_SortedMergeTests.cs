namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Problem_10_01_SortedMerge;

  [TestClass]
  public class Problem_10_01_SortedMergeTests
  {
    [TestMethod]
    public void NullATest()
    {
      Action a = () => Solution.Execute(null, Array.Empty<int>());
      a.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void NullBTest()
    {
      Action a = () => Solution.Execute(new int[1], null);
      a.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void NotEnoughSpaceInATest()
    {
      int[] a = new int[5];
      int[] b = new int[6];
      Action act = () => Solution.Execute(a, b);
      act.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void OneTest()
    {
      int[] a = new int[2];
      a[0] = 2;
      int[] b = new int[] { 1 };
      Solution.Execute(a, b).Should().BeEquivalentTo(new int[] { 1, 2, });
    }

    [TestMethod]
    public void AreEqualTest()
    {
      int[] a = new int[2];
      a[0] = 1;
      int[] b = new int[] { 1 };
      Solution.Execute(a, b).Should().BeEquivalentTo(new int[] { 1, 1, });
    }

    [TestMethod]
    public void BiggerTest()
    {
      int[] a = new int[10];
      a[0] = 1;
      a[1] = 3;
      a[2] = 4;
      a[3] = 6;
      a[4] = 9;
      int[] b = new int[] { 2, 5, 7, 8, 10 };
      Solution.Execute(a, b).Should().BeEquivalentTo(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
    }
  }
}
