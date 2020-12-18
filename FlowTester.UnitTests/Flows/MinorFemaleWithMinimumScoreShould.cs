using FlowTester.Core;
using FlowTester.Core.Flows;
using FlowTester.UnitTests.Utils;
using FluentAssertions;
using Xunit;

namespace FlowTester.UnitTests.Flows
{
    public class MinorFemaleWithMinimumScoreShould
    {
        [Theory]
        [InlineData(6)]
        [InlineData(10)]
        public void Match(int score)
        {
            // ARRANGE
            var sut = new MinorFemaleWithMinimumScore(6, new DebugLogger());

            // ACT
            var result = sut.Flow.Satisfies(FakePersonBuilder.Create(15, Sex.Female, score));

            // ASSERT
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(5)]
        [InlineData(1)]
        public void NotMatch(int score)
        {
            // ARRANGE
            var sut = new MinorFemaleWithMinimumScore(6, new DebugLogger());

            // ACT
            var result = sut.Flow.Satisfies(FakePersonBuilder.Create(15, Sex.Female, score));

            // ASSERT
            result.Should().BeFalse();
        }
    }
}