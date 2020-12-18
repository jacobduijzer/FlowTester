using FlowTester.Core.Predicates;

namespace FlowTester.Core.Flows
{
    public class AdultMale : IFlow<Person, string>
    {
        public Spec<Person, string> Flow { get; }

        public AdultMale(DebugLogger debugLogger) =>
            Flow = new Spec<Person, string>()
                .Where(new AdultPredicate(debugLogger).Predicate)
                .Where(new MalePredicate(debugLogger).Predicate)
                .ResultsIn(nameof(AdultMale));
    }
}