using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Chapter_1_ArraysAndStrings;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions

namespace Problems.Chapter_1_ArraysAndStrings.Tests
{
    [TestClass()]
    public class Problem_1_1Tests
    {
        [TestMethod()]
        public void IsUniqueNullTest() => Problem_1_1.IsUnique(null).Should().BeFalse();

        [TestMethod()]
        public void IsUniqueNullTest() => Problem_1_1.IsUnique(null);
    }
}
