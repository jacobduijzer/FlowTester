using System.Collections.Generic;

namespace FlowTester.Core
{
    public class DebugLogger
    {
        public readonly List<string> Messages;

        public DebugLogger() => Messages = new();

        public void AddMessage(string message) =>
            Messages.Add(message);

        public void Clear() => Messages.Clear();
    }
}