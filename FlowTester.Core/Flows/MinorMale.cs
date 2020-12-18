using FlowTester.Core.Predicates;

namespace FlowTester.Core.Flows
{
    public class MinorMale : IFlow<Person, string>
    {
        public Spec<Person, string> Flow { get; }

        public MinorMale(DebugLogger debugLogger) =>
            Flow = new Spec<Person, string>()
                .Where(new MinorPredicate(debugLogger).Predicate)
                .Where(new MalePredicate(debugLogger).Predicate)
                .ResultsIn(nameof(MinorMale));
    }
}