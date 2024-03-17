using System;
using System.Collections.Generic;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool AcceptState;
    }
    public class FA1
    {
        public static State s1 = new State()
        {
            Name = "s1",
            AcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State s2 = new State()
        {
            Name = "s2",
            AcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State s3 = new State()
        {
            Name = "s3",
            AcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State s4 = new State()
        {
            Name = "s4",
            AcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public State s5 = new State()
        {
            Name = "s5",
            AcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        State InitialState = s1;
        public FA1()
        {
            s1.Transitions['0'] = s2;
            s1.Transitions['1'] = s3;
            s2.Transitions['0'] = s5;
            s2.Transitions['1'] = s4;
            s3.Transitions['0'] = s4;
            s3.Transitions['1'] = s3;
            s4.Transitions['0'] = s5;
            s4.Transitions['1'] = s4;
            s5.Transitions['0'] = s5;
            s5.Transitions['1'] = s5;
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
            return current.AcceptState;
        }
    }
    public class FA2
    {
        public static State s1 = new State()
        {
            Name = "s1",
            AcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State s2 = new State()
        {
            Name = "s2",
            AcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State s3 = new State()
        {
            Name = "s3",
            AcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State s4 = new State()
        {
            Name = "s4",
            AcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        State InitialState = s1;
        public FA2()
        {
            s1.Transitions['0'] = s3;
            s1.Transitions['1'] = s2;
            s2.Transitions['0'] = s4;
            s2.Transitions['1'] = s1;
            s3.Transitions['0'] = s1;
            s3.Transitions['1'] = s4;
            s4.Transitions['0'] = s2;
            s4.Transitions['1'] = s3;
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
            return current.AcceptState;
        }
    }
    public class FA3
    {
        public static State s1 = new State()
        {
            Name = "s1",
            AcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State s2 = new State()
        {
            Name = "s2",
            AcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State s3 = new State()
        {
            Name = "s3",
            AcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        State InitialState = s1;
        public FA3()
        {
            s1.Transitions['0'] = s1;
            s1.Transitions['1'] = s2;
            s2.Transitions['0'] = s1;
            s2.Transitions['1'] = s3;
            s3.Transitions['0'] = s3;
            s3.Transitions['1'] = s3;
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
            return current.AcceptState;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            String s = "010011";
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
