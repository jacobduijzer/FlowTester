using System.Collections.Generic;
using System.Linq;
using FlowTester.Core.Flows;
using Microsoft.Extensions.Logging;

namespace FlowTester.Core
{
    public class FlowService
    {
        private readonly DebugLogger _debugLogger;
        private readonly ILogger<FlowService> _logger;

        private readonly IList<IFlow<Person, bool>> _flows;

        public FlowService(
            int minimumScore,
            DebugLogger debugLogger,
            ILogger<FlowService> logger)
        {
            _debugLogger = debugLogger;
            _logger = logger;

            _flows = new List<IFlow<Person, bool>>()
            {
                new MinorMale(debugLogger),
                new MinorFemale(minimumScore, debugLogger),
                new AdultMale(debugLogger),
                new AdultFemale(debugLogger),
                new MinorFemaleWithMinimumScore(minimumScore, debugLogger)
            };
        }

        public void Validation(List<Person> people)
        {
            foreach (var flow in _flows)
            {
                _debugLogger.Clear();
                _debugLogger.AddMessage($"Start flow {flow.GetType().Name}");
                foreach (var person in people.Where(person => flow.Flow.Satisfies(person)))
                {
                    _debugLogger.AddMessage($"{flow.GetType().Name} satisfies: {person.ToString()}");
                    _logger.LogInformation("========================================");
                    foreach (var message in _debugLogger.Messages)
                        _logger.LogInformation(message);
                    _logger.LogInformation("========================================");
                    _debugLogger.Clear();
                }
            }
        }
    }
}