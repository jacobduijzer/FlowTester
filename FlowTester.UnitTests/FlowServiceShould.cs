using System.Collections.Generic;
using Bogus;
using FlowTester.Core;
using FlowTester.Core.Flows;
using FlowTester.UnitTests.Utils;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;
using Person = FlowTester.Core.Person;

namespace FlowTester.UnitTests
{
    public class FlowServiceShould
    {
        private LoggerFactory _loggerFactory;
        private Faker<Person> _testUser;

        public FlowServiceShould(ITestOutputHelper testOutputHelper)
        {
            _loggerFactory = new LoggerFactory();
            _loggerFactory.AddProvider(new XunitLoggerProvider(testOutputHelper));
        }

        [Fact]
        public void Test()
        {
            // ARRANGE
            var sut = new FlowService(5, new DebugLogger(), _loggerFactory.CreateLogger<FlowService>());
            var people = new List<Person>
            {
                FakePersonBuilder.Create(17, Sex.Male, 4),
                FakePersonBuilder.Create(29, Sex.Male, 4),
                FakePersonBuilder.Create(17, Sex.Female, 3),
                FakePersonBuilder.Create(17, Sex.Female, 7),
                FakePersonBuilder.Create(41, Sex.Female, 3)
            };

            // ACT
            sut.Validation(people);

            // ASSERT
        }

        [Theory]
        [InlineData(17, Sex.Male, 0, nameof(MinorMale))]
        [InlineData(17, Sex.Female, 0, nameof(MinorFemale))]
        [InlineData(19, Sex.Male, 0, nameof(AdultMale))]
        [InlineData(19, Sex.Female, 0, nameof(AdultFemale))]
        [InlineData(17, Sex.Female, 7, nameof(MinorFemaleWithMinimumScore))]
        public void MatchPerson(int age, Sex sex, int score, string expectedResult)
        {
            // ARRANGE
            var sut = new FlowService(6, new DebugLogger(), _loggerFactory.CreateLogger<FlowService>());
            var person = FakePersonBuilder.Create(age, sex, score);

            // ACT
            var resultFlow = sut.MatchPerson(person);

            // ASSERT
            resultFlow.Flow.Result.Should().Be(expectedResult);
        }
    }
}