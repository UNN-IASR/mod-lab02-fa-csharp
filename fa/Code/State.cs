using System.Collections.Generic;

namespace fa.Code
{
    public class State
    {
        public const State EndState = null;
        
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;

        public State(string name, bool isAcceptState)
        {
            IsAcceptState = isAcceptState;
            Name = name;
            Transitions = new Dictionary<char, State>();
        }
    }
}