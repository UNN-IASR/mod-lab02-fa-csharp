using System;
using System.Collections.Generic;
using System.Linq;

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
        private State s00;
        private State s01;
        private State s10;
        private State s11;
        private State s20;
        
        private State InitialState;
        
        public FA1()
        {
            s00 = new State() { Name = "S00", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            s01 = new State() { Name = "S01", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            s10 = new State() { Name = "S10", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            s11 = new State() { Name = "S11", IsAcceptState = true, Transitions = new Dictionary<char, State>() };
            s20 = new State() { Name = "S20", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            
            s00.Transitions['0'] = s10;
            s00.Transitions['1'] = s01;
            s01.Transitions['0'] = s11;
            s01.Transitions['1'] = s01;
            s10.Transitions['0'] = s20;
            s10.Transitions['1'] = s11;
            s11.Transitions['0'] = s20;
            s11.Transitions['1'] = s11;
            s20.Transitions['0'] = s20;
            s20.Transitions['1'] = s20;
            
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
            }
            return current.IsAcceptState;
        }
    }
  
    public class FA2
    {
        private State s00;
        private State s01;
        private State s10;
        private State s11;
        
        private State InitialState;
        
        public FA2()
        {
            s00 = new State() { Name = "S00", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            s01 = new State() { Name = "S01", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            s10 = new State() { Name = "S10", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            s11 = new State() { Name = "S11", IsAcceptState = true, Transitions = new Dictionary<char, State>() };
            
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
            }
            return current.IsAcceptState;
        }
    }
    
    public class FA3
    {
        private State s0;
        private State s1;
        private State s2;
        
        private State InitialState;
        
        public FA3()
        {
            s0 = new State() { Name = "S0", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            s1 = new State() { Name = "S1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            s2 = new State() { Name = "S2", IsAcceptState = true, Transitions = new Dictionary<char, State>() };
            
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
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
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