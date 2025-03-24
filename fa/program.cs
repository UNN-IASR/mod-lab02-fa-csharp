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
  public class FA
  {
    public static State a = new State()
    {
      Name = "a",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State X = new State()
    {
      Name = "X",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State InitialState = a;
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
    public FA()
    {
      X.Transitions['0'] = X;
      X.Transitions['1'] = X;
    }
  }
  public class FA1 : FA
  {
    public State b = new State()
    {
      Name = "b",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State c = new State()
    {
      Name = "c",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public static State d = new State()
    {
      Name = "d",
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };
    public State e = new State()
    {
      Name = "e",
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };
    public FA1()
    {
      a.Transitions['0'] = b;
      a.Transitions['1'] = c;
      b.Transitions['0'] = X;
      b.Transitions['1'] = d;
      c.Transitions['0'] = e;
      c.Transitions['1'] = c;
      d.Transitions['0'] = X;
      d.Transitions['1'] = d;
      e.Transitions['0'] = X;
      e.Transitions['1'] = e;
    }
  }
  public class FA2 : FA
  {
    public State b = new State()
    {
      Name = "b",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State c = new State()
    {
      Name = "c",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public static State d = new State()
    {
      Name = "d",
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };
    public FA2()
    {
      a.Transitions['0'] = c;
      a.Transitions['1'] = b;
      b.Transitions['0'] = d;
      b.Transitions['1'] = a;
      c.Transitions['0'] = a;
      c.Transitions['1'] = d;
      d.Transitions['0'] = b;
      d.Transitions['1'] = c;
    }
  }
  public class FA3 : FA
  {
    public State b = new State()
    {
      Name = "b",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State c = new State()
    {
      Name = "c",
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };
    public FA3()
    {
      a.Transitions['0'] = a;
      a.Transitions['1'] = b;
      b.Transitions['0'] = a;
      b.Transitions['1'] = c;
      c.Transitions['0'] = c;
      c.Transitions['1'] = c;
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