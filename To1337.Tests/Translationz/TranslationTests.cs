using FluentAssertions;
using To1337.Translationz;
using Xunit;

namespace To1337.Tests.Translationz
{
    public class TranslationTests
    {
        [Theory]
        [InlineData(("testa"))]
        public void Ctor_Create_HasValue(string value)
        {
            var translation = new Translation(value);

            translation.Value.Should().Be(value);
            translation.IsEmpty.Should().BeFalse();
        }

        [Theory]
        [InlineData("testa", L337ness.N00b, 100)]
        public void Ctor_Create_HasValues(string value, L337ness l337ness, int weight)
        {
            var translation = new Translation(value, l337ness, weight);

            translation.Value.Should().Be(value);
            translation.L337ness.Should().Be(l337ness);
            translation.Weight.Should().Be(weight);
            translation.IsEmpty.Should().BeFalse();
        }

        [Fact]
        public void Ctor_Create_IsEmpty()
        {
            var translation = new Translation();
            translation.Value.Should().BeNull();
            translation.IsEmpty.Should().BeTrue();
        }

        [Fact]
        public void Equals_Equality_AreEqual()
        {
            const string value = "value";
            const L337ness l337ness = L337ness.N00b;
            const int weight = 10;

            var translation1 = new Translation(value, l337ness, weight);
            var translation2 = new Translation(value, l337ness, weight);
            translation1.Should().Be(translation2);
        }

        [Fact]
        public void Translate_Translation_InputIsTranslated()
        {
            const string input = "Hello World!";
            const string trigger = "World";
            const string translationValue = "Moon";

            var translation = new Translation(translationValue);

            translation.Translate(input, trigger).Should().Be("Hello Moon!");
        }
    }
}