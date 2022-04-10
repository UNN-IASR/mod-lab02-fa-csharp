using System.Collections.Generic;

namespace fa.Code
{
    public abstract class Fa
    {
        protected readonly Dictionary<string, State> States;
        protected State InitialState;

        protected Fa()
        {
            States = new Dictionary<string, State>();
            InitStates();
            InitTransitions();
            SetInitialState();
        }

        public abstract bool? Run(IEnumerable<char> str);
        protected abstract void InitStates();
        protected abstract void InitTransitions();
        protected abstract void SetInitialState();
    }
}