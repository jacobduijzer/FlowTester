using System;
using FlowTester.Core.Flows;

namespace FlowTester.Core
{
    public record FlowDataWrapper<TIn, TOut>(DateTime StartDate, IFlow<TIn, TOut> Flow);
}