using System.Collections.Generic;

namespace fa.Code
{
    public abstract class Fa4States : Fa
    {
        protected State A => States["A"];
        protected State B => States["B"];
        protected State C => States["C"];
        protected State D => States["D"];

        protected override void InitStates()
        {
            States["A"] = new State("A", false);
            States["B"] = new State("B", false);
            States["C"] = new State("C", false);
            States["D"] = new State("D", true);
        }

        protected override void SetInitialState() => 
            InitialState = A;

        public override bool? Run(IEnumerable<char> str)
        {
            var currentState = InitialState;
            foreach (var c in str)
            {
                currentState = currentState.Transitions[c];
                if (currentState == State.EndState)
                    return false;
            }
            return currentState.IsAcceptState;
        }
    }
}