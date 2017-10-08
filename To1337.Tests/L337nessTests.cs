using FluentAssertions;
using Xunit;

namespace To1337.Tests
{
    public class L337nessTests
    {
        [Fact]
        public void ComparisonOperators_CompareValues_N00bIsLessThanL337()
        {
            (L337ness.N00b < L337ness.L337).Should().BeTrue();
        }
        [Fact]
        public void ComparisonOperators_CompareValues_H4rdC0r3H4xx0rIsGreaterThanN00b()
        {
            (L337ness.H4rdC0r3H4xx0r > L337ness.N00b).Should().BeTrue();
        }
        [Fact]
        public void ComparisonOperators_CompareValues_L337EqualsL337()
        {
            (L337ness.L337 == L337ness.L337).Should().BeTrue();
        }
    }
}
