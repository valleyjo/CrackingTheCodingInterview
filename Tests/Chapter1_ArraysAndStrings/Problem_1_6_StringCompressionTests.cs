namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;
    using Problem = Problem_1_6_StringCompression;

    [TestClass()]
    public class Problem_1_6_StringCompressionTests
    {
        [TestMethod()]
        public void NullOrEmptyTest() => Problem.Execute(null).Should().Be(string.Empty);

        [TestMethod()]
        public void OneCharTest() => Problem.Execute("a").Should().Be("a");

        [TestMethod()]
        public void TwoCharTest() => Problem.Execute("aa").Should().Be("aa");

        [TestMethod()]
        public void CompressesLongerThanOriginalTest() => Problem.Execute("abcdef").Should().Be("abcdef");

        [TestMethod()]
        public void CompressedShorterTest() => Problem.Execute("aabbbbbcddd").Should().Be("a2b5c1d3");

        [TestMethod()]
        public void SameCharTest() => Problem.Execute("aaaaaaaa").Should().Be("a8");
    }
}
