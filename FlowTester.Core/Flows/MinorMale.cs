using FlowTester.Core.Predicates;

namespace FlowTester.Core.Flows
{
    public class MinorMale : IFlow<Person, bool>
    {
        public Spec<Person, bool> Flow { get; }
        
        public MinorMale(DebugLogger debugLogger)
        {
            Flow = new Spec<Person, bool>()
                .Where(new MinorPredicate(debugLogger).Predicate)
                .Where(new MalePredicate(debugLogger).Predicate)
                .ResultsIn(true);
        }
    }
}