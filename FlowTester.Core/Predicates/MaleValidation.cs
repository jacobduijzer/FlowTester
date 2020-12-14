using System;

namespace FlowTester.Core.Predicates
{
    public class MalePredicate : PredicateBase
    {
        public MalePredicate(DebugLogger logger) : base(logger) { }

        public override Predicate<Person> Predicate => person =>
        {
            AddLogMessage($"{person.ToString()}: {_sexCheck(person)}");
            return _sexCheck(person);
        };

        private readonly Func<Person, bool> _sexCheck = person => person.Sex.Equals("M");
    }
}