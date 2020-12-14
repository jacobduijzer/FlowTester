using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowTester.Core
{
    public class Spec<TSubject, TResult>
    {
        private readonly ICollection<Predicate<TSubject>> _predicates;
        private TResult _result;

        public Spec() => _predicates = new List<Predicate<TSubject>>();

        public Spec<TSubject, TResult> Where(Predicate<TSubject> predicate)
        {
            _predicates.Add(predicate);
            return this;
        }

        public Spec<TSubject, TResult> WhereNot(Predicate<TSubject> predicate)
        {
            _predicates.Add(subject => !predicate(subject));
            return this;
        }

        public Spec<TSubject, TResult> ResultsIn(TResult result)
        {
            _result = result;
            return this;
        }

        public bool Satisfies(TSubject subject) => _predicates.All(predicate => predicate(subject));

        public List<Predicate<TSubject>> DoesNotSatisfy(TSubject subject) =>
            _predicates.Where(x => x.Invoke(subject)).ToList();

        public TResult Result => _result;

        public static Spec<TSubject, TResult> Builder => new Spec<TSubject, TResult>();
    }
}