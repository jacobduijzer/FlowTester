using System;

namespace FlowTester.Core.Predicates
{
    public class MinimumScoreValidation : PredicateBase
    {
        private readonly int _minimumScore;

        public MinimumScoreValidation(int minimumScore, DebugLogger logger) : base(logger) =>
            _minimumScore = minimumScore;

        public override Predicate<Person> Predicate => person =>
        {
            AddLogMessage($"{person.ToString()}: {_sexCheck(person, _minimumScore)}");
            return _sexCheck(person, _minimumScore);
        };

        private readonly Func<Person, int, bool> _sexCheck = (person, minimumScore) =>
            person.Score > 0 && person.Score >= minimumScore;
    }
}