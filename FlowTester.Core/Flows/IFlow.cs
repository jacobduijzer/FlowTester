namespace FlowTester.Core.Flows
{
    public interface IFlow<TIn, TOut>
    {
        Spec<TIn, TOut> Flow { get; }
    }
}