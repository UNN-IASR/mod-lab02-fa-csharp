using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string? Name;
    public Dictionary<char, State>? Transitions;
    public bool IsAcceptState;
  }


  public class FA1
  {
    State a = new State() // Начальное состояние
    {
      Name = "a",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    State b = new State() // Нашли первый ноль
    {
      Name = "b",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    State c = new State() // Принимающее состояние
    {
      Name = "с",
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };

    State d = new State() // Отклоняющее состояние (больше одного нуля)
    {
      Name = "d",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    State e = new State() // Состояние только для единиц
    {
      Name = "e",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };

    State InitialState;

    public FA1()
    {
      InitialState = a;

      a.Transitions['0'] = b;
      a.Transitions['1'] = e;

      b.Transitions['0'] = d;
      b.Transitions['1'] = c;

      c.Transitions['0'] = d;
      c.Transitions['1'] = c;

      d.Transitions['0'] = d;
      d.Transitions['1'] = d;

      e.Transitions['0'] = c;
      e.Transitions['1'] = e;
    }

    public bool? Run(IEnumerable<char> s)
    {
      State current = InitialState;
      foreach (char c in s)
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
    public bool? Run(IEnumerable<char> s)
    {
      return false;
    }
  }
  
  public class FA3
  {
    public bool? Run(IEnumerable<char> s)
    {
      return false;
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