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
    public static State a = new State()
    {
      Name = "0",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State b = new State()
    {
      Name = "1",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State c = new State()
    {
      Name = "2",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State d = new State()
    {
      Name = "3",
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };

    public static State e = new State()
    {
      Name = "4",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public FA1()
    {
      a.Transitions['0'] = c;
      a.Transitions['1'] = b;
      b.Transitions['0'] = d;
      b.Transitions['1'] = b;
      c.Transitions['0'] = e;
      c.Transitions['1'] = d;
      d.Transitions['0'] = e;
      d.Transitions['1'] = d;
      e.Transitions['0'] = e;
      e.Transitions['1'] = e;
    }

    public bool? Run(IEnumerable<char> s)
    {
      State state = a;
      foreach (var ch in s)
      {
        state = state.Transitions[ch];
        if (state == null)
          return null;
      }
      return state.IsAcceptState;
    }
  }

  public class FA2
  {
    public static State a = new State()
    {
      Name = "0",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State b = new State()
    {
      Name = "1",
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };

    public static State c = new State()
    {
      Name = "2",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State d = new State()
    {
      Name = "3",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public FA2()
    {
      a.Transitions['0'] = c;
      a.Transitions['1'] = d;
      b.Transitions['0'] = d;
      b.Transitions['1'] = c;
      c.Transitions['0'] = a;
      c.Transitions['1'] = b;
      d.Transitions['0'] = b;
      d.Transitions['1'] = a;
    }

    public bool? Run(IEnumerable<char> s)
    {
      State state = a;
      foreach (var ch in s)
      {
        state = state.Transitions[ch];
        if (state == null)
          return null;
      }
      return state.IsAcceptState;
    }
  }
  
  public class FA3
  {
    public static State a = new State()
    {
      Name = "0",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State b = new State()
    {
      Name = "1",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    public static State c = new State()
    {
      Name = "2",
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

    public bool? Run(IEnumerable<char> s)
    {
      State state = a;
      foreach (var ch in s)
      {
        state = state.Transitions[ch];
        if (state == null)
          return null;
      }
      return state.IsAcceptState;
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