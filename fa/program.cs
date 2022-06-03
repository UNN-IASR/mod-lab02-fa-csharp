  public class FA1
  {
    public static State a = new State()
    {
      Name = "a",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
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
    public State d = new State()
    {
      Name = "d",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State e = new State()
    {
      Name = "e",
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
      return false;
      State current = InitialState;
      foreach (var c in s)
      {
          current = current.Transitions[c];
          if (current == null) {
            return null;
          }
      }
      return current.IsAcceptState;
    }
  }

  public class FA2
  {
     public static State a = new State()
    {
      Name = "a",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
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
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public FA2()
        {
          a.Transitions['0'] = b;
          a.Transitions['1'] = c;
          b.Transitions['0'] = a;
          b.Transitions['1'] = d;
          c.Transitions['0'] = d;
          c.Transitions['1'] = a;
          d.Transitions['0'] = c;
          d.Transitions['1'] = b; 
        }
    public bool? Run(IEnumerable<char> s)
    {
      return false;
      State current = InitialState;
      foreach (var c in s)
      {
          current = current.Transitions[c];
          if (current == null) {
            return null;
          }
      }
      return current.IsAcceptState;
    }
  }
  
  public class FA3
  {
    public static State a = new State()
    {
      Name = "a",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
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
      return false;
      State current = InitialState;
      foreach (var c in s)
      {
          current = current.Transitions[c];
          if (current == null) {
            return null;
          }
      }
      return current.IsAcceptState;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      String s = "01011";
      String s = "010101";
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
