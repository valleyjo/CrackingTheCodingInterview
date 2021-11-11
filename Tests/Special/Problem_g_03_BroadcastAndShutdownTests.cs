namespace CrackingTheCodingInterview.Problems.Special.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Special.Problem_g_03_BroadcastAndShutdown;

  [TestClass]
  public class Problem_g_03_BroadcastAndShutdownTests
  {
    [TestMethod]
    public void CanReachTest()
    {
      List<Solution.Router> list = GetRouterList();
      Solution.Execute(list, list[0], list[2]).Should().BeTrue();
    }

    [TestMethod]
    public void CantReachTest()
    {
      List<Solution.Router> list = GetRouterList();
      Solution.Execute(list, list[0], list[3]).Should().BeFalse();
    }

    private static List<Solution.Router> GetRouterList()
    {
      var list = new List<Solution.Router>();
      list.Add(new Solution.Router("A", 0, 0));
      list.Add(new Solution.Router("B", 0, 8));
      list.Add(new Solution.Router("C", 0, 17));
      list.Add(new Solution.Router("D", 11, 0));
      return list;
    }
  }
}
