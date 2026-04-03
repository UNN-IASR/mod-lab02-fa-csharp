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
        State s0, s1, s2, s3, dead;
        State InitialState;

        public FA1()
        {
            s0   = new State { Name = "s0",   IsAcceptState = false,
                Transitions = new Dictionary<char, State>() };
            s1   = new State { Name = "s1",   IsAcceptState = false,
                Transitions = new Dictionary<char, State>() };
            s2   = new State { Name = "s2",   IsAcceptState = false,
                Transitions = new Dictionary<char, State>() };
            s3   = new State { Name = "s3",   IsAcceptState = true,
                Transitions = new Dictionary<char, State>() };
            dead = new State { Name = "dead", IsAcceptState = false,
                Transitions = new Dictionary<char, State>() };

            s0.Transitions['0'] = s2;
            s0.Transitions['1'] = s1;
            s1.Transitions['0'] = s3;
            s1.Transitions['1'] = s1;
            s2.Transitions['0'] = dead;
            s2.Transitions['1'] = s3;
            s3.Transitions['0'] = dead;
            s3.Transitions['1'] = s3;
            dead.Transitions['0'] = dead;
            dead.Transitions['1'] = dead;

            InitialState = s0;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c)) return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }


    public class FA2
    {
        State s00, s01, s10, s11;
        State InitialState;

        public FA2()
        {
            s00 = new State { Name = "s00", IsAcceptState = false,
                Transitions = new Dictionary<char, State>() };
            s01 = new State { Name = "s01", IsAcceptState = false,
                Transitions = new Dictionary<char, State>() };
            s10 = new State { Name = "s10", IsAcceptState = false,
                Transitions = new Dictionary<char, State>() };
            s11 = new State { Name = "s11", IsAcceptState = true,
                Transitions = new Dictionary<char, State>() };

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
                if (!current.Transitions.ContainsKey(c)) return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }


    public class FA3
    {
        State s0, s1, s2;
        State InitialState;

        public FA3()
        {
            s0 = new State { Name = "s0", IsAcceptState = false,
                Transitions = new Dictionary<char, State>() };
            s1 = new State { Name = "s1", IsAcceptState = false,
                Transitions = new Dictionary<char, State>() };
            s2 = new State { Name = "s2", IsAcceptState = true,
                Transitions = new Dictionary<char, State>() };

            s0.Transitions['0'] = s0;
            s0.Transitions['1'] = s1;
            s1.Transitions['0'] = s0;
            s1.Transitions['1'] = s2;
            s2.Transitions['0'] = s2;
            s2.Transitions['1'] = s2;

            InitialState = s0;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c)) return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FA1 fa1 = new FA1();
            Console.WriteLine("FA1 '101': " + fa1.Run("101"));

            FA2 fa2 = new FA2();
            Console.WriteLine("FA2 '0101': " + fa2.Run("0101"));

            FA3 fa3 = new FA3();
            Console.WriteLine("FA3 '0011': " + fa3.Run("0011"));
        }
    }
}
