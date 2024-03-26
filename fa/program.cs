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
    public static State Start = new State()
    {
        Name = "Start",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State Zero = new State()
    {
        Name = "Zero",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State One = new State()
    {
        Name = "One",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State Stop = new State()
    {
        Name = "Stop",
        IsAcceptState = true,
        Transitions = new Dictionary<char, State>()
    };

    State InitialState = Start;

    public FA1()
    {
        Start.Transitions['0'] = Zero;
        Start.Transitions['1'] = One;
        Zero.Transitions['0'] = null;
        Zero.Transitions['1'] = Stop;
        One.Transitions['0'] = Stop;
        One.Transitions['1'] = One;
        Stop.Transitions['0'] = null;
        Stop.Transitions['1'] = Stop;
    }

    public bool? Run(IEnumerable<char> s)
    {
        State current = InitialState;
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
    public static State Start = new State()
    {
        Name = "Start",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State EvenZero = new State()
    {
        Name = "EvenZero",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State EvenOne = new State()
    {
        Name = "EvenOne",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State Stop = new State()
    {
        Name = "Stop",
        IsAcceptState = true,
        Transitions = new Dictionary<char, State>()
    };

    State InitialState = Start;

    public FA2()
    {
        Start.Transitions['0'] = EvenOne;
        Start.Transitions['1'] = EvenZero;
        EvenOne.Transitions['1'] = Stop;
        EvenOne.Transitions['0'] = Start;
        EvenZero.Transitions['1'] = Start;
        EvenZero.Transitions['0'] = Stop;
        Stop.Transitions['1'] = EvenOne;
        Stop.Transitions['0'] = EvenZero;
    }

    public bool? Run(IEnumerable<char> s)
    {
        State current = InitialState;
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
    public static State Start = new State()
    {
        Name = "Start",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State One = new State()
    {
        Name = "One",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State Stop = new State()
    {
        Name = "Stop",
        IsAcceptState = true,
        Transitions = new Dictionary<char, State>()
    };
    State InitialState = Start;

    public FA3()
    {
        Start.Transitions['0'] = Start;
        Start.Transitions['1'] = One;
        One.Transitions['1'] = Stop;
        One.Transitions['0'] = Start;
        Stop.Transitions['0'] = Stop;
        Stop.Transitions['1'] = Stop;
    }

    public bool? Run(IEnumerable<char> s)
    {
        State current = InitialState;
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