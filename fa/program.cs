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
    public FA1()
        {
            q0 = new State() { Name = "q0", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            q1 = new State() { Name = "q1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            q2 = new State() { Name = "q2", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            q3 = new State() { Name = "q3", IsAcceptState = true, Transitions = new Dictionary<char, State>() };
            q4 = new State() { Name = "q4", IsAcceptState = false, Transitions = new Dictionary<char, State>() };

            q0.Transitions['0'] = q2;
            q0.Transitions['1'] = q1;
      
            q1.Transitions['0'] = q3;
            q1.Transitions['1'] = q1;

            q2.Transitions['0'] = q4;
            q2.Transitions['1'] = q3;

            q3.Transitions['0'] = q4;
            q3.Transitions['1'] = q3;

            q4.Transitions['0'] = q4;
            q4.Transitions['1'] = q4;

            initialState = q0;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = initialState;
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
     private State q00, q01, q10, q11;
        private State initialState;

        public FA2()
        {
            q00 = new State() { Name = "q00", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            q01 = new State() { Name = "q01", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            q10 = new State() { Name = "q10", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            q11 = new State() { Name = "q11", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

            // Из q00
            q00.Transitions['0'] = q10;
            q00.Transitions['1'] = q01;

            // Из q01
            q01.Transitions['0'] = q11;
            q01.Transitions['1'] = q00;

            // Из q10
            q10.Transitions['0'] = q00;
            q10.Transitions['1'] = q11;

            // Из q11
            q11.Transitions['0'] = q01;
            q11.Transitions['1'] = q10;

            initialState = q00;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = initialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }public bool? Run(IEnumerable<char> s)
    {
      return false;
    }
  }
  
  public class FA3
  {
    private State s0, s1, s2;
        private State initialState;

        public FA3()
        {
            s0 = new State() { Name = "s0", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            s1 = new State() { Name = "s1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            s2 = new State() { Name = "s2", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

            s0.Transitions['0'] = s0;
            s0.Transitions['1'] = s1;

            s1.Transitions['0'] = s0;
            s1.Transitions['1'] = s2;

            s2.Transitions['0'] = s2;
            s2.Transitions['1'] = s2;

            initialState = s0;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = initialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      String s = "011001011";
      FA1 fa1 = new FA1();
      bool? result1 = fa1.Run(s);
      Console.WriteLine(result1);

    }
  }
