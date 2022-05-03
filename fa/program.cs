using System;
using System.Collections.Generic;

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
        public static State State0 = new State()
        {
            Name = "State 0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public State State1 = new State()
        {
            Name = "State 1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public State State2 = new State()
        {
            Name = "State 2",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public State State3 = new State()
        {
            Name = "State 3",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = State0;

        public FA1()
        {
            State0.Transitions['0'] = State2;
            State0.Transitions['1'] = State1;
            State1.Transitions['0'] = State3;
            State1.Transitions['1'] = State1;
            State2.Transitions['0'] = null;
            State2.Transitions['1'] = State3;
            State3.Transitions['0'] = null;
            State3.Transitions['1'] = State3;
        }

        public bool? Run(IEnumerable<char> s)
        {
            var current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return false;
            }
            return current.IsAcceptState;
        }
    }

    public class FA2
    {
        public static State State0 = new State()
        {
            Name = "State 0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public State State1 = new State()
        {
            Name = "State 1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public State State2 = new State()
        {
            Name = "State 2",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public State State3 = new State()
        {
            Name = "State 3",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = State0;

        public FA2()
        {
            State0.Transitions['0'] = State2;
            State0.Transitions['1'] = State1;
            State1.Transitions['0'] = State3;
            State1.Transitions['1'] = State0;
            State2.Transitions['0'] = State0;
            State2.Transitions['1'] = State3;
            State3.Transitions['0'] = State1;
            State3.Transitions['1'] = State2;
        }

        public bool? Run(IEnumerable<char> s)
        {
            var current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return false;
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        public static State State0 = new State()
        {
            Name = "State 0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public State State1 = new State()
        {
            Name = "State 1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public State State2 = new State()
        {
            Name = "State 2",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = State0;

        public FA3()
        {
            State0.Transitions['0'] = State0;
            State0.Transitions['1'] = State1;
            State1.Transitions['0'] = State0;
            State1.Transitions['1'] = State2;
            State2.Transitions['0'] = State0;
            State2.Transitions['1'] = State2;
        }

        public bool? Run(IEnumerable<char> s)
        {
            var current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return false;
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