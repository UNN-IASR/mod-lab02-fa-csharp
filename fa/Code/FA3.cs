using System.Collections.Generic;

namespace fa.Code
{
    public class FA3 : Fa
    {
        private State A => States["A"];
        private State B => States["B"];
        private State C => States["C"];

        protected override void InitStates()
        {
            States["A"] = new State("A", false);
            States["B"] = new State("B", false);
            States["C"] = new State("C", true);
        }

        protected override void InitTransitions()
        {
            A.Transitions['0'] = A;
            A.Transitions['1'] = B;
            B.Transitions['0'] = A;
            B.Transitions['1'] = C;
            C.Transitions['0'] = A;
            C.Transitions['1'] = C;
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