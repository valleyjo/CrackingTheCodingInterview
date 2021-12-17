namespace CrackingTheCodingInterview.Problems.Chapter15_ThreadsAndLocks
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using Microsoft.Extensions.Logging;

  public class Problem_15_4_DeadlockFreeClass
  {
    private readonly ILogger logger;

    public Problem_15_4_DeadlockFreeClass(ILogger logger) => this.logger = logger;

    public bool GetLock(string[] dependencies)
    {
      return false;
    }
  }
}
