namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FluentAssertions;
    using Problem = CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings.Problem_1_9_StringRotation;

    [TestClass()]
    public class Problem_1_9_StringRotationTests
    {
        [TestMethod()]
        public void IsRotationTest() => Problem.IsRotation("keyboard", "ardkeybo").Should().BeTrue();

        [TestMethod()]
        public void IsNotRotationTest() => Problem.IsRotation("keyboard", "keyboards").Should().BeFalse();
    }
}
