namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using LruCache = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Problem_16_25_LruCache;

  [TestClass]
  public class Problem_16_25_LruCacheTests
  {
    [TestMethod]
    public void AddOneTest()
    {
      var cache = new LruCache(5);
      cache.Add(5, 10);
      cache.Get(5).Should().Be(10);
    }

    [TestMethod]
    public void AddLimitTest()
    {
      var cache = new LruCache(5);

      // value = key * 3
      cache.Add(1, 6);
      cache.Add(2, 12);
      cache.Add(3, 18);
      cache.Add(4, 25);
      cache.Add(5, 30);
      cache.Get(5).Should().Be(30);
      cache.Get(1).Should().Be(6);
    }

    [TestMethod]
    public void TriggerEvictionTest()
    {
      var cache = new LruCache(5);
      cache.Add(1, 6);
      cache.Add(2, 12);
      cache.Add(3, 18);
      cache.Add(4, 24);
      cache.Add(5, 30);

      // 4, 24 -> 5, 30 -> 3, 18 -> 2, 12 -> 1, 6
      cache.Get(4).Should().Be(24);

      // 2, 12 -> 4, 24 -> 5, 30 -> 3, 18 -> 1, 6
      cache.Get(2).Should().Be(12);

      // 6, 36 -> 2, 12 -> 4, 24 -> 5, 30 -> 3, 18
      cache.Add(6, 36);

      Action act = () => cache.Get(1);
      act.Should().Throw<KeyNotFoundException>();

      // 7, 42 -> 6, 36 -> 2, 12 -> 4, 24 -> 5, 30
      cache.Add(7, 42);
      act = () => cache.Get(3);
      act.Should().Throw<KeyNotFoundException>();
    }
  }
}
