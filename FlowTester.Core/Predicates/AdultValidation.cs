using System;

namespace FlowTester.Core.Predicates
{
    public class AdultPredicate : PredicateBase
    {
        public AdultPredicate(DebugLogger logger) : base(logger) { }
        
        public override Predicate<Person> Predicate => person =>
        { 
            AddLogMessage($"{person}: {_ageCheck(person.Age)}");
            return _ageCheck(person.Age);
        };

        private readonly Func<int, bool> _ageCheck = x => x >= 18;
        
    }
}