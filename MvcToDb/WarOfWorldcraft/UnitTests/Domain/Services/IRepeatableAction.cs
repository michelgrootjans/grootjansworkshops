using System;

namespace UnitTests.Domain.Services
{
    internal interface IRepeatableAction
    {
        void Times(int i);
    }

    internal class RepeatableAction : IRepeatableAction
    {
        private readonly Action action;

        public RepeatableAction(Action action)
        {
            this.action = action;
        }

        public void Times(int i)
        {
            for (var j = 0; j < i; j++)
                action();
        }
    }
}