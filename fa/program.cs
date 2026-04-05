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

      private State q3 = new State()
      {
          Name = "q3",
          IsAcceptState = false,
          Transitions = new Dictionary<char, State>()
      };

      private State q4 = new State()
      {
          Name = "q4",
          IsAcceptState = false,
          Transitions = new Dictionary<char, State>()
      };

      private State InitialState;

      public FA1()
      {
          q0.Transitions['0'] = q1;
          q0.Transitions['1'] = q4;

          q1.Transitions['0'] = q3;
          q1.Transitions['1'] = q2;

          q2.Transitions['0'] = q3;
          q2.Transitions['1'] = q2;

          q3.Transitions['0'] = q3;
          q3.Transitions['1'] = q3;

          q4.Transitions['0'] = q2;
          q4.Transitions['1'] = q4;

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
          }
          return current.IsAcceptState;
      }
  }

  public class FA2
  {
      private State q00 = new State() { Name = "q00", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
      private State q01 = new State() { Name = "q01", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
      private State q10 = new State() { Name = "q10", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
      private State q11 = new State() { Name = "q11", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

      private State InitialState;

      public FA2()
      {
          q00.Transitions['0'] = q10;
          q00.Transitions['1'] = q01;

          q01.Transitions['0'] = q11;
          q01.Transitions['1'] = q00;

          q10.Transitions['0'] = q00;
          q10.Transitions['1'] = q11;

          q11.Transitions['0'] = q01;
          q11.Transitions['1'] = q10;

          InitialState = q00;
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
      private State s0 = new State() { Name = "s0", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
      private State s1 = new State() { Name = "s1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
      private State s2 = new State() { Name = "s2", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

      private State InitialState;

      public FA3()
      {
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
          string s = "0000010111";
          FA1 fa = new FA1();
          bool? result = fa.Run(s);
          Console.WriteLine(result);
      }
  }
}
