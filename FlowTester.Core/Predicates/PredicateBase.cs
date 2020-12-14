using System;

namespace FlowTester.Core.Predicates
{
    public abstract class PredicateBase : IPredicate<Person>
    {
        private readonly DebugLogger _logger;
        
        protected PredicateBase(DebugLogger debugLogger) => _logger = debugLogger;
        
        public abstract Predicate<Person> Predicate { get; }

        protected void AddLogMessage(string message)
            => _logger.AddMessage($"{GetType().Name}: {message}");

    }
}