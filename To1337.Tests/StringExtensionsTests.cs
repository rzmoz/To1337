using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace To1337.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void To1337_Off_NothingChanged()
        {
            var text = "Hello World!";

            var output = text.To1337(L337ness.Off);

            output.Should().Be(text);
        }

        [Fact]
        public void To1337_N00b_Translated()
        {
            var text = "The beginner couldn't believe how cool this is. It rocks!";

            var output = text.To1337(L337ness.N00b);

            output.Should().NotBe(text);
        }

        [Fact]
        public void To1337_L337_Translated()
        {
            var text = "The beginner couldn't believe how cool this is. It rocks!";

            var output = text.To1337(L337ness.L337);

            output.Should().NotBe(text);
        }

        [Fact]
        public void To1337_H4rdC0r3H4xx0r_Translated()
        {
            var text = "The beginner couldn't believe how cool this is. It rocks!";

            var output = text.To1337(L337ness.H4rdC0r3H4xx0r);

            output.Should().NotBe(text);
        }
    }
}
