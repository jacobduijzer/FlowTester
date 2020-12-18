using FlowTester.Core;
using FlowTester.Core.Flows;
using FlowTester.UnitTests.Utils;
using FluentAssertions;
using Xunit;

namespace FlowTester.UnitTests.Flows
{
    public class AdultMaleShould
    {
        [Theory]
        [InlineData(18)]
        [InlineData(48)]
        public void Match(int age)
        {
            // ARRANGE
            var sut = new AdultMale(new DebugLogger());

            // ACT
            var result = sut.Flow.Satisfies(FakePersonBuilder.Create(age, Sex.Male));

            // ASSERT
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(15, Sex.Female)]
        [InlineData(15, Sex.Male)]
        public void NotMatch(int age, Sex sex)
        {
            // ARRANGE
            var sut = new AdultMale(new DebugLogger());

            // ACT
            var result = sut.Flow.Satisfies(FakePersonBuilder.Create(age, sex));

            // ASSERT
            result.Should().BeFalse();
        }
    }
}