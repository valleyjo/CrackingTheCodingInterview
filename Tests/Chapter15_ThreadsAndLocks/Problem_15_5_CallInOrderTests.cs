namespace CrackingTheCodingInterview.Problems.Chapter15_ThreadsAndLocks.Tests
{
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using FluentAssertions;
  using Microsoft.Extensions.Logging;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter15_ThreadsAndLocks.Problem_15_5_CallInOrder;

  [TestClass]
  public class Problem_15_5_CallInOrderTests
  {
    [TestMethod]
    public void CallInOrderTest()
    {
      var logLines = new List<string>();
      ILogger log = MemoryLog.Create(logLines);
      var obj = new Solution(log);
      var tasks = new List<Task>(2);
      obj.First();
      tasks.Add(obj.SecondAsync());
      tasks.Add(obj.ThirdAsync());

      Task.WhenAll(tasks).Wait();

      logLines.Should().ContainInOrder(
        "[Information]First exiting",
        "[Information]SecondAsync exiting",
        "[Information]ThirdAsync exiting");
    }

    [TestMethod]
    public void CallBackwardsTest()
    {
      var logLines = new List<string>();
      ILogger log = MemoryLog.Create(logLines);
      var obj = new Solution(log);
      var tasks = new List<Task>(2);
      tasks.Add(obj.ThirdAsync());
      tasks.Add(obj.SecondAsync());
      obj.First();

      Task.WhenAll(tasks).Wait();

      logLines.Should().ContainInOrder(
        "[Information]First exiting",
        "[Information]SecondAsync exiting",
        "[Information]ThirdAsync exiting");
    }

    [TestMethod]
    public void CallSecondThirdFirstTest()
    {
      var logLines = new List<string>();
      ILogger log = MemoryLog.Create(logLines);
      var obj = new Solution(log);
      var tasks = new List<Task>(2);
      tasks.Add(obj.SecondAsync());
      tasks.Add(obj.ThirdAsync());
      obj.First();

      Task.WhenAll(tasks).Wait();

      logLines.Should().ContainInOrder(
        "[Information]First exiting",
        "[Information]SecondAsync exiting",
        "[Information]ThirdAsync exiting");
    }

    [TestMethod]
    public void CallSecondFirstThirdTest()
    {
      var logLines = new List<string>();
      ILogger log = MemoryLog.Create(logLines);
      var obj = new Solution(log);
      var tasks = new List<Task>(2);
      tasks.Add(obj.SecondAsync());
      obj.First();
      tasks.Add(obj.ThirdAsync());

      Task.WhenAll(tasks).Wait();

      logLines.Should().ContainInOrder(
        "[Information]First exiting",
        "[Information]SecondAsync exiting",
        "[Information]ThirdAsync exiting");
    }
  }
}
