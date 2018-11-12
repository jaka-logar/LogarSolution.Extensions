using System;
using System.Collections.Generic;
using Xunit;

namespace LogarSolutions.Extensions.Tests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData(" ", false)]
        [InlineData("abc", false)]
        public void IsNullOrEmptyTest(string input, bool result)
        {
            Assert.True(input.IsNullOrEmpty() == result);
        }

        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData(" ", true)]
        [InlineData("abc", false)]
        public void IsNullOrWhiteSpaceTest(string input, bool result)
        {
            Assert.True(input.IsNullOrWhiteSpace() == result);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData("abc", false)]
        [InlineData("abc123", false)]
        [InlineData("ABC123", true)]
        [InlineData("ABC", true)]
        public void IsAllUpperTest(string input, bool result)
        {
            Assert.True(input.IsAllUpper() == result);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("abc", "Abc")]
        [InlineData("abc123", "Abc123")]
        [InlineData("ABC123", "ABC123")]
        public void FirstLetterToUpperTest(string input, string result)
        {
            Assert.True(input.FirstLetterToUpper() == result);
        }

        [Theory]
        [InlineData(null, "")]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("abc", "ABC")]
        [InlineData("abc123", "ABC123")]
        [InlineData("ABC123", "ABC123")]
        public void SafeToUpperTest(string input, string result)
        {
            Assert.True(input.SafeToUpper() == result);
        }

        [Theory]
        [InlineData(null, "")]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("ABC", "abc")]
        [InlineData("abc123", "abc123")]
        [InlineData("ABC123", "abc123")]
        public void SafeToLowerTest(string input, string result)
        {
            Assert.True(input.SafeToLower() == result);
        }

        [Theory]
        [InlineData(null, "")]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        public void ToSafeStringTest1(object input, string result)
        {
            Assert.True(input.ToSafeString() == result);
        }

        [Fact]
        public void ToSafeStringTest2()
        {
            TestClass testClass = new TestClass();

            Assert.True(testClass.ToSafeString() == "TestClass");
        }

        [Theory]
        [InlineData(null, "")]
        [InlineData("", "")]
        [InlineData(" ", "")]
        [InlineData(" ABC ", "ABC")]
        [InlineData("   abc  123    ", "abc  123")]
        public void SafeTrimTest(string input, string result)
        {
            Assert.True(input.SafeTrim() == result);
        }

        [Fact]
        public void ContainsTest()
        {
            string str = "abcDEFghi";

            Assert.True(str.Contains("a", StringComparison.Ordinal));
            Assert.True(str.Contains("b", StringComparison.CurrentCulture));
            Assert.True(str.Contains("D", StringComparison.InvariantCultureIgnoreCase));
        }

        [Theory]
        [InlineData(null, -1, "")]
        [InlineData("", 2, "")]
        [InlineData(" ", 0, " ")]
        [InlineData("ABC", 1, "BC")]
        [InlineData("abc123", 0, "abc123")]
        [InlineData("ABC123", 3, "123")]
        public void SafeSubstringTest1(string input, int startIndex, string result)
        {
            Assert.True(input.SafeSubstring(startIndex) == result);
        }

        [Theory]
        [InlineData(null, -1, 3, "")]
        [InlineData("", 2, 1, "")]
        [InlineData(" ", 0, 1, " ")]
        [InlineData("ABC", 1, 5, "BC")]
        [InlineData("abc123", 0, 3, "abc")]
        [InlineData("ABC123", 3, 1, "1")]
        public void SafeSubstringTest2(string input, int startIndex, int length, string result)
        {
            Assert.True(input.SafeSubstring(startIndex, length) == result);
        }

        [Fact]
        public void ConcatValuesTest()
        {
            IList<int> list = new List<int>
            {
                1,1,1,1,2,2,2,2,3,3,3,3
            };

            Assert.True(list.ConcatValues() == "1,1,1,1,2,2,2,2,3,3,3,3");
            Assert.True(list.ConcatValues(".") == "1.1.1.1.2.2.2.2.3.3.3.3");
        }

        [Theory]
        [InlineData(null, -1, -1)]
        [InlineData("", 0, 0)]
        [InlineData("321", 0, 321)]
        [InlineData("123", 1, 123)]
        public void ToSafeLongTest(string input, long defaultValue, long result)
        {
            Assert.True(input.ToSafeLong(defaultValue) == result);
        }

        [Theory]
        [InlineData(null, '1', "")]
        [InlineData("", 'a', "")]
        [InlineData("321", '2', "1")]
        [InlineData("123", '4', "123")]
        [InlineData("123", '1', "23")]
        public void AfterCharSubstringTest(string input, char charToFind, string result)
        {
            Assert.True(input.AfterCharSubstring(charToFind) == result);
        }

        #region Nested classes

        public class TestClass
        {
            public override string ToString()
            {
                return nameof(TestClass);
            }
        }

        #endregion
    }
}
