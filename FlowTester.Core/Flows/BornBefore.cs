namespace FlowTester.Core.Flows
{
    public class BornBefore : IFlow<Person, bool>
    {
        public Spec<Person, bool> Flow { get; }
    }
}