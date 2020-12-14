using FlowTester.Core.Predicates;
using Microsoft.Extensions.Logging;

namespace FlowTester.Core.Flows
{
    public class MinorFemaleWithMinimumScore : IFlow<Person, bool>
    {
        public Spec<Person, bool> Flow { get; }

        public MinorFemaleWithMinimumScore(int minimumScore, DebugLogger debugLogger)
        {
            Flow = new Spec<Person, bool>()
                .Where(new MinorPredicate(debugLogger).Predicate)
                .WhereNot(new MalePredicate(debugLogger).Predicate)
                .Where(new MinimumScoreValidation(minimumScore, debugLogger).Predicate)
                .ResultsIn(true);
        }
    }
}