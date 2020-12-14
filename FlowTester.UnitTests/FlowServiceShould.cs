using System.Collections.Generic;
using FlowTester.Core;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace FlowTester.UnitTests
{
    public class FlowServiceShould
    {
        private LoggerFactory _loggerFactory;

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
                new Person("Jan", "Jansen", 17, "M", 4),
                new Person("Piet", "Jansen", 29, "M", 3),
                new Person("Gerry", "Jansen", 17, "F", 5),
                new Person("Gerry", "Jansen", 17, "F", 7),
                new Person("Mientje", "Jansen", 41, "F", 3)
            };
            
            // ACT
            sut.Validation(people);

            // ASSERT
        }
    }
}