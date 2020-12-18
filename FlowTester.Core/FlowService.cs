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

        private readonly IList<IFlow<Person, string>> _flows;

        public FlowService(
            int minimumScore,
            DebugLogger debugLogger,
            ILogger<FlowService> logger)
        {
            _debugLogger = debugLogger;
            _logger = logger;

            _flows = new List<IFlow<Person, string>>()
            {
                new MinorFemaleWithMinimumScore(minimumScore, debugLogger),
                new MinorMale(debugLogger),
                new MinorFemale(debugLogger),
                new AdultMale(debugLogger),
                new AdultFemale(debugLogger)
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

        public IFlow<Person, string> MatchPerson(Person person)
        {
           foreach(var flow in _flows)
               if (flow.Flow.Satisfies(person))
                   return flow;

           throw new FlowNotFoundException();
        }
    }
}