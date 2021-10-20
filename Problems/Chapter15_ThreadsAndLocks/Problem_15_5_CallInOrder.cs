namespace CrackingTheCodingInterview.Problems.Chapter15_ThreadsAndLocks
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using Microsoft.Extensions.Logging;

  public class Problem_15_5_CallInOrder
  {
    private readonly SemaphoreSlim firstSemaphore = new(0, 1);
    private readonly SemaphoreSlim secondSemaphore = new(0, 1);
    private readonly ILogger logger;

    public Problem_15_5_CallInOrder(ILogger logger) => this.logger = logger;

    public void First()
    {
      this.logger.LogInformation(nameof(this.First) + " entering");
      this.firstSemaphore.Release();
      this.logger.LogInformation(nameof(this.First) + " exiting");
    }

    public async Task SecondAsync()
    {
      this.logger.LogInformation(nameof(this.SecondAsync) + " entering");
      await this.firstSemaphore.WaitAsync();
      this.secondSemaphore.Release();
      this.logger.LogInformation(nameof(this.SecondAsync) + " exiting");
    }

    public async Task ThirdAsync()
    {
      this.logger.LogInformation(nameof(this.ThirdAsync) + " entering");
      await this.secondSemaphore.WaitAsync();
      this.logger.LogInformation(nameof(this.ThirdAsync) + " exiting");
    }
  }
}
