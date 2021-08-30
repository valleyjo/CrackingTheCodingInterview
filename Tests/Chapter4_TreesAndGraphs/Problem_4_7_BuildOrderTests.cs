namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs.Problem_4_7_BuildOrder;

  [TestClass]
  public class Problem_4_7_BuildOrderTests
  {
    [TestMethod]
    public void NullTest()
    {
      Action act = () => Solution.Execute(null, null);
      act.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void EmptyTest()
    {
      Action act = () => Solution.Execute(new List<int>(), new List<Solution.Dependency>());
      act.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void OneNodeTest()
    {
      var dependencies = new List<Solution.Dependency>()
      {
        new Solution.Dependency(1, 2),
      };

      var projects = new List<int>() { 1, 2, };

      Solution.Execute(projects, dependencies).Should().BeEquivalentTo(new List<short> { 2, 1, });
    }

    [TestMethod]
    public void CircularDependencyTest()
    {
      var dependencies = new List<Solution.Dependency>()
      {
        new Solution.Dependency(2, 1),
        new Solution.Dependency(1, 2),
      };

      var projects = new List<int>() { 1, 2, };

      Action act = () => Solution.Execute(projects, dependencies);
      act.Should().Throw<ArgumentException>().WithMessage("Circular dependency detected");
    }

    [TestMethod]
    public void BigGraphTest()
    {
      var dependencies = new List<Solution.Dependency>()
      {
        new Solution.Dependency(4, 1),
        new Solution.Dependency(2, 6),
        new Solution.Dependency(4, 2),
        new Solution.Dependency(1, 6),
        new Solution.Dependency(3, 4),
      };

      var projects = new List<int>() { 1, 2, 3, 4, 5, 6, };

      Solution.Execute(projects, dependencies).Should().BeEquivalentTo(new List<int>() { 6, 5, 1, 2, 4, 3, });
    }
  }
}
