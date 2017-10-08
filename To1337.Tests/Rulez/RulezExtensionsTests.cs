using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace To1337.Tests
{
    public class RulezExtensionsTests
    {
        private static IEnumerable<int> GetIEnumerableIntegers1()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
        }
        private static IEnumerable<int> GetIEnumerableIntegers2()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
        }
        
        [Fact]
        public void SequentialEquals_Equality_AreEqual()
        {
            var integers1 = GetIEnumerableIntegers1();
            var integers2 = GetIEnumerableIntegers2();

            integers1.SequenceEqual(integers2).Should().BeTrue();
        }
    }
}
