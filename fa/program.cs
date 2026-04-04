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
        private State q0 = new State()
        {
            Name = "q0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        private State q1 = new State()
        {
            Name = "q1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        private State q2 = new State()
        {
            Name = "q2",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        private State dead = new State()
        {
            Name = "dead",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        private State InitialState;

        public FA1()
        {
            dead.Transitions['0'] = dead;
            dead.Transitions['1'] = dead;

            q0.Transitions['0'] = q1;
            q0.Transitions['1'] = q0;

            q1.Transitions['0'] = dead;
            q1.Transitions['1'] = q2;

            q2.Transitions['0'] = dead;
            q2.Transitions['1'] = q2;

            InitialState = q0;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    public class FA2
    {
        private State s00 = new State()
        {
            Name = "s00",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        private State s01 = new State()
        {
            Name = "s01",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        private State s10 = new State()
        {
            Name = "s10",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        private State s11 = new State()
        {
            Name = "s11",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        private State InitialState;

        public FA2()
        {
            s00.Transitions['0'] = s10;
            s00.Transitions['1'] = s01;

            s01.Transitions['0'] = s11;
            s01.Transitions['1'] = s00;

            s10.Transitions['0'] = s00;
            s10.Transitions['1'] = s11;

            s11.Transitions['0'] = s01;
            s11.Transitions['1'] = s10;

            InitialState = s00;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        private State p0 = new State()
        {
            Name = "p0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        private State p1 = new State()
        {
            Name = "p1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        private State p2 = new State()
        {
            Name = "p2",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        private State InitialState;

        public FA3()
        {
            p0.Transitions['0'] = p0;
            p0.Transitions['1'] = p1;

            p1.Transitions['0'] = p0;
            p1.Transitions['1'] = p2;

            p2.Transitions['0'] = p2;
            p2.Transitions['1'] = p2;

            InitialState = p0;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FA1 fa1 = new FA1();
            Console.WriteLine(fa1.Run("011"));
            Console.WriteLine(fa1.Run("001"));

            FA2 fa2 = new FA2();
            Console.WriteLine(fa2.Run("01"));
            Console.WriteLine(fa2.Run("10"));
            Console.WriteLine(fa2.Run("0011"));

            FA3 fa3 = new FA3();
            Console.WriteLine(fa3.Run("0011"));
            Console.WriteLine(fa3.Run("010"));
        }
    }
}