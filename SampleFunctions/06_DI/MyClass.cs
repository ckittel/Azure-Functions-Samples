using System;

namespace SampleFunctions.Di
{
    public class MyClass : IMyClass
    {
        private readonly DateTime _startedAt = DateTime.UtcNow;

        public string GetMessage()
        {
            return $"Hello from {_startedAt}.";
        }
    }
}
