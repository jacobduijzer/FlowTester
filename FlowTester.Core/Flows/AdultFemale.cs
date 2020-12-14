using FlowTester.Core.Predicates;

namespace FlowTester.Core.Flows
{
    public class AdultFemale : IFlow<Person, bool>
    {
        public Spec<Person, bool> Flow { get; }
        
        public AdultFemale(DebugLogger debugLogger)
        {
            Flow = new Spec<Person, bool>()
                .Where(new AdultPredicate(debugLogger).Predicate)
                .WhereNot(new MalePredicate(debugLogger).Predicate)
                .ResultsIn(true);
        }
    }
}