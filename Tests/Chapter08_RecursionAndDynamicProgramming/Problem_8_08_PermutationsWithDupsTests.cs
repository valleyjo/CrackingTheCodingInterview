﻿namespace CrackingTheCodingInterview.Problems.Chapter08_RecursionAndDynamicProgramming.Tests
{
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter08_RecursionAndDynamicProgramming.Problem_8_08_PermutationsWithDups;

  [TestClass]
  public class Problem_8_08_PermutationsWithDupsTests
  {
    [TestMethod]
    public void EmptyTest() => Solution.Execute(string.Empty).Should().BeEquivalentTo(new List<string>() { string.Empty });

    [TestMethod]
    public void OneLetterTest() => Solution.Execute("A").Should().BeEquivalentTo(new List<string>() { "A" });

    [TestMethod]
    public void TwoLettersTest() => Solution.Execute("AL").Should().BeEquivalentTo(new List<string>() { "AL", "LA" });

    [TestMethod]
    public void ThreeLettersTest() => Solution.Execute("ALE").Should().BeEquivalentTo(new List<string>() { "ALE", "AEL", "EAL", "ELA", "LEA", "LAE", });

    [TestMethod]
    public void DuplicatesTest() => Solution.Execute("AAA").Should().BeEquivalentTo(new List<string>() { "AAA" });
  }
}
