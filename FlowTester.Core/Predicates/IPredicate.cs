using System;

namespace FlowTester.Core.Predicates
{
    public interface IPredicate<in T>
    {
        Predicate<T> Predicate { get; }
    }
}