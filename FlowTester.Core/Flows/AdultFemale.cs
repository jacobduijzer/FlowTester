using FlowTester.Core.Predicates;

namespace FlowTester.Core.Flows
{
    public class AdultFemale : IFlow<Person, string>
    {
        public Spec<Person, string> Flow { get; }

        public AdultFemale(DebugLogger debugLogger) =>
            Flow = new Spec<Person, string>()
                .Where(new AdultPredicate(debugLogger).Predicate)
                .WhereNot(new MalePredicate(debugLogger).Predicate)
                .ResultsIn(nameof(AdultFemale));
    }
}