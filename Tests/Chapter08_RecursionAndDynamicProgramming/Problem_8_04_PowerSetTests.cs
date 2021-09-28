namespace CrackingTheCodingInterview.Problems.Chapter08_RecursionAndDynamicProgramming.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter08_RecursionAndDynamicProgramming.Problem_8_04_PowerSet;

  [TestClass]
  public class Problem_8_04_PowerSetTests
  {
    [TestMethod]
    public void NullTest() => Solution.Execute(null).Should().BeNull();

    [TestMethod]
    public void EmptyTest() => Solution.Execute(Array.Empty<int>()).Should().BeNull();

    [TestMethod]
    public void OneTest()
    {
      var result = new List<List<int>>();
      result.Add(new List<int>() { 1 });

      Solution.Execute(new int[] { 1 }).Should().BeEquivalentTo(result);
    }

    [TestMethod]
    public void TwoTest()
    {
      var result = new List<List<int>>();
      result.Add(new List<int>() { 1 });
      result.Add(new List<int>() { 1, 2, });
      result.Add(new List<int>() { 2, });

      Solution.Execute(new int[] { 1, 2, }).Should().BeEquivalentTo(result);
    }

    [TestMethod]
    public void ThreeTest()
    {
      var result = new List<List<int>>();
      result.Add(new List<int>() { 1 });
      result.Add(new List<int>() { 1, 2, });
      result.Add(new List<int>() { 2, });
      result.Add(new List<int>() { 1, 3, });
      result.Add(new List<int>() { 2, 3 });
      result.Add(new List<int>() { 1, 2, 3, });
      result.Add(new List<int>() { 3, });

      Solution.Execute(new int[] { 1, 2, 3, }).Should().BeEquivalentTo(result);
    }

    [TestMethod]
    public void FourTest()
    {
      var result = new List<List<int>>();
      result.Add(new List<int>() { 1 });
      result.Add(new List<int>() { 1, 2, });
      result.Add(new List<int>() { 2, });
      result.Add(new List<int>() { 1, 3, });
      result.Add(new List<int>() { 2, 3 });
      result.Add(new List<int>() { 1, 2, 3, });
      result.Add(new List<int>() { 3, });
      result.Add(new List<int>() { 1, 4 });
      result.Add(new List<int>() { 1, 2, 4, });
      result.Add(new List<int>() { 2, 4, });
      result.Add(new List<int>() { 1, 3, 4, });
      result.Add(new List<int>() { 2, 3, 4, });
      result.Add(new List<int>() { 1, 2, 3, 4, });
      result.Add(new List<int>() { 3, 4, });
      result.Add(new List<int>() { 4, });

      Solution.Execute(new int[] { 1, 2, 3, 4, }).Should().BeEquivalentTo(result);
    }
  }
}
