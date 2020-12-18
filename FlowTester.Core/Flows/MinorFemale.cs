using FlowTester.Core.Predicates;

namespace FlowTester.Core.Flows
{
    public class MinorFemale : IFlow<Person, string>
    {
        public Spec<Person, string> Flow { get; }

        public MinorFemale(DebugLogger debugLogger) =>
            Flow = new Spec<Person, string>()
                .Where(new MinorPredicate(debugLogger).Predicate)
                .WhereNot(new MalePredicate(debugLogger).Predicate)
                .ResultsIn(nameof(MinorFemale));
    }
}