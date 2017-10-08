using System.Linq;
using FluentAssertions;
using To1337.Rulez;
using To1337.Translationz;
using Xunit;

namespace To1337.Tests
{
    public class RuleTests
    {
        private const string _ruleTrigger = "Hopsa";

        private readonly Translation _translation;
        private const string _translationValue = "testa";
        private const L337ness _l337ness = L337ness.N00b;
        private const int _weight = 10;

        public RuleTests()
        {
            _translation = new Translation(_translationValue, _l337ness, _weight);
        }

        [Fact]
        public void CompareTo_Sortorder_Rule1IsFirst()
        {
            var rule1 = new Rule("abc", _translation);
            var rule2 = new Rule("de", _translation);
            rule1.CompareTo(rule2).Should().Be(1);
        }

        [Fact]
        public void CompareTo_Sortorder_RulesAreTheSame()
        {
            var rule1 = new Rule("abc", _translation);
            var rule2 = new Rule("cde", _translation);
            rule1.CompareTo(rule2).Should().Be(0);
        }

        [Fact]
        public void CompareTo_Sortorder_Rule1IsLast()
        {
            var rule1 = new Rule("ab", _translation);
            var rule2 = new Rule("cde", _translation);
            rule1.CompareTo(rule2).Should().Be(-1);
        }

        [Fact]
        public void Ctor_Create_HasTranslation()
        {
            var rule = new Rule(_ruleTrigger, _translation);
            rule.Translationz.Any().Should().BeTrue();
        }

        [Fact]
        public void Equals_Equality_AreEqual()
        {
            var rule1 = new Rule(_ruleTrigger, _translation);
            var rule2 = new Rule(_ruleTrigger, _translation);
            rule1.Equals(rule2).Should().BeTrue();
        }
    }
}