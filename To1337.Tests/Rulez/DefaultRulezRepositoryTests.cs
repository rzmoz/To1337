using FluentAssertions;
using To1337.Rulez;
using Xunit;

namespace To1337.Tests.Rulez
{

    public class DefaultRulezRepositoryTests
    {
        [Fact]
        public void RetreiveAll_Retreival_HasRules()
        {
            var rulez = new RulezRepository();
            rulez.Count.Should().Be(42);
        }
    }
}
