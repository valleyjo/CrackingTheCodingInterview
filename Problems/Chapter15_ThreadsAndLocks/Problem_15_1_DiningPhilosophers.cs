namespace CrackingTheCodingInterview.Problems.Chapter15_ThreadsAndLocks
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using Microsoft.Extensions.Logging;

  public class Problem_15_1_DiningPhilosophers
  {
    private readonly ILogger logger;

    public Problem_15_1_DiningPhilosophers(ILogger logger) => this.logger = logger;
  }
}
