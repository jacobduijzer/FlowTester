using FlowTester.Core.Predicates;

namespace FlowTester.Core.Flows
{
    public class AdultMale : IFlow<Person, bool>
    {
        public Spec<Person, bool> Flow { get; }
        
        public AdultMale(DebugLogger debugLogger)
        {
            Flow = new Spec<Person, bool>()
                .Where(new AdultPredicate(debugLogger).Predicate)
                .Where(new MalePredicate(debugLogger).Predicate)
                .ResultsIn(true);
        }
    }
}