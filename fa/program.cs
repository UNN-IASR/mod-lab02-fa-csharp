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

    public State(string name, bool isAcceptState)
    {
        Name = name;
        IsAcceptState = isAcceptState;
        Transitions = new Dictionary<char, State>();
    }
   }


  public class FA1
  {
    private State InitialState;
    public FA1()
    {
        var a = new State("a", false);
        var b = new State("b", false);
        var c = new State("c", true);
        var d = new State("d", false);
        var e = new State("e", false);


        a.Transitions['0'] = b;
        a.Transitions['1'] = d;
        b.Transitions['0'] = e;
        b.Transitions['1'] = c;
        c.Transitions['0'] = e;
        c.Transitions['1'] = c;
        d.Transitions['0'] = c;
        d.Transitions['1'] = d;
        e.Transitions['0'] = e;
        e.Transitions['1'] = e;

        InitialState = a;
    }
    public bool? Run(IEnumerable<char> s)
    {
        State current = InitialState;
        foreach (var c in s) // цикл по всем символам 
        {
            if (!current.Transitions.TryGetValue(c, out current))
                return null;
        }
        return current.IsAcceptState;
    }
  }

  public class FA2
  {
    private State InitialState;
    public FA2()
    {
        var a = new State("a", false);
        var b = new State("b", true);
        var c = new State("c", false);
        var d = new State("d", false);


        a.Transitions['0'] = c;
        a.Transitions['1'] = d;
        b.Transitions['0'] = d;
        b.Transitions['1'] = c;
        c.Transitions['0'] = a;
        c.Transitions['1'] = b;
        d.Transitions['0'] = b;
        d.Transitions['1'] = a;

        InitialState = a;
    }

    public bool? Run(IEnumerable<char> s)
    {
        State current = InitialState;
        foreach (var c in s) // цикл по всем символам 
        {
            if (!current.Transitions.TryGetValue(c, out current))
                return null;
        }
        return current.IsAcceptState;
    }
  }
  
  public class FA3
  {
    private State InitialState;
    public FA3()
    {
        var a = new State("a", false);
        var b = new State("b", false);
        var c = new State("c", true);


        a.Transitions['0'] = a;
        a.Transitions['1'] = b;
        b.Transitions['0'] = a;
        b.Transitions['1'] = c;
        c.Transitions['0'] = c;
        c.Transitions['1'] = c;

        InitialState = a;
    }

    public bool? Run(IEnumerable<char> s)
    {
        State current = InitialState;
        foreach (var c in s) // цикл по всем символам 
        {
            if (!current.Transitions.TryGetValue(c, out current))
                return null;
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