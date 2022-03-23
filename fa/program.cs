using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;
  }


  public class FA1
  {
        public static State state0 = new State()
        {
            Name = "state0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State state1 = new State()
        {
            Name = "state1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State state2 = new State()
        {
            Name = "state2",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State state3 = new State()
        {
            Name = "state3",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        public static State state4 = new State()
        {
            Name = "state4",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = state0;

        public FA1()
        {
            state0.Transitions['0'] = state1;
            state0.Transitions['1'] = state2;

            state1.Transitions['0'] = state4;
            state1.Transitions['1'] = state3;

            state2.Transitions['0'] = state3;
            state2.Transitions['1'] = state2;

            state3.Transitions['0'] = state4;
            state3.Transitions['1'] = state3;

            state4.Transitions['0'] = state4;
            state4.Transitions['1'] = state4;
        }

        public bool? Run(IEnumerable<char> s)
    {
            State current = InitialState;
            foreach (var c in s) 
            {
                current = current.Transitions[c]; 
                if (current == null)              
                    return null;
            }
            return current.IsAcceptState;        
        }
  }

    public class FA2
    {
        public static State state0 = new State()
        {
            Name = "state0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State state1 = new State()
        {
            Name = "state1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State state2 = new State()
        {
            Name = "state2",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State state3 = new State()
        {
            Name = "state3",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        public static State state4 = new State()
        {
            Name = "state4",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = state0;

        public FA2()
        {
            state0.Transitions['0'] = state1;
            state0.Transitions['1'] = state2;

            state1.Transitions['0'] = state0;
            state1.Transitions['1'] = state3;

            state2.Transitions['0'] = state4;
            state2.Transitions['1'] = state0;

            state3.Transitions['0'] = state2;
            state3.Transitions['1'] = state1;

            state4.Transitions['0'] = state2;
            state4.Transitions['1'] = state1;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null) return null;
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        public static State state0 = new State()
        {
            Name = "state0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State state1 = new State()
        {
            Name = "state1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State state2 = new State()
        {
            Name = "state2",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = state0;

        public FA3()
        {
            state0.Transitions['0'] = state0;
            state0.Transitions['1'] = state1;

            state1.Transitions['0'] = state0;
            state1.Transitions['1'] = state2;

            state2.Transitions['0'] = state2;
            state2.Transitions['1'] = state2;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null) return null;
            }
            return current.IsAcceptState;
        }
    }

    class Program
  {
    static void Main(string[] args)
    { 
      String s = "01111";
      FA1 fa1 = new FA1();
      bool? result1 = fa1.Run(s);
      Console.WriteLine(result1);
      FA2 fa2 = new FA2();
      bool? result2 = fa2.Run(s);
      Console.WriteLine(result2);
      FA3 fa3 = new FA3();
      bool? result3 = fa3.Run(s);
      Console.WriteLine(result3);
    }
  }
}
