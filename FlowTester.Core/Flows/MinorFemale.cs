using FlowTester.Core.Predicates;
using Microsoft.Extensions.Logging;

namespace FlowTester.Core.Flows
{
    public class MinorFemale : IFlow<Person, bool>
    {
        public Spec<Person, bool> Flow { get; }

        public MinorFemale(int minimumScore, DebugLogger debugLogger)
        {
            Flow = new Spec<Person, bool>()
                .Where(new MinorPredicate(debugLogger).Predicate)
                .WhereNot(new MalePredicate(debugLogger).Predicate)
                .WhereNot(new MinimumScoreValidation(minimumScore, debugLogger).Predicate)
                .ResultsIn(true);
        }
    }
}