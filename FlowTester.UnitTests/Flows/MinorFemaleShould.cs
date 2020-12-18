using FlowTester.Core;
using FlowTester.Core.Flows;
using FlowTester.UnitTests.Utils;
using FluentAssertions;
using Xunit;

namespace FlowTester.UnitTests.Flows
{
    public class MinorFemaleShould
    {
        [Theory]
        [InlineData(17)]
        [InlineData(8)]
        public void Match(int age)
        {
            // ARRANGE
            var sut = new MinorFemale(new DebugLogger());

            // ACT
            var result = sut.Flow.Satisfies(FakePersonBuilder.Create(age, Sex.Female));

            // ASSERT
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(19, Sex.Female)]
        [InlineData(15, Sex.Male)]
        public void NotMatch(int age, Sex sex)
        {
            // ARRANGE
            var sut = new MinorFemale(new DebugLogger());

            // ACT
            var result = sut.Flow.Satisfies(FakePersonBuilder.Create(age, sex));

            // ASSERT
            result.Should().BeFalse();
        }
    }
}