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
            Name = "Start State",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State Accept = new State()
        {
            Name = "Accept State",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public static State Decline = new State()
        {
            Name = "Decline State",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public FA1()
        {
            Start.Transitions['0'] = Accept;
            Start.Transitions['1'] = Start;
            Accept.Transitions['0'] = Decline;
            Accept.Transitions['1'] = Accept;
            Decline.Transitions['0'] = Decline;
            Decline.Transitions['1'] = Decline;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = Start;
            foreach (char c in s) {
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }

 
  }

  public class FA2
  {
        public static State Start = new State()
        {
            Name = "Start State",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State Accept = new State()
        {
            Name = "Decline State",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        public static State zero = new State()
        {
            Name = "Accept State",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State one = new State()
        {
            Name = "Decline State",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public FA2()
        {
            Start.Transitions['0'] = zero;
            Start.Transitions['1'] = one;

            Accept.Transitions['0'] = one;
            Accept.Transitions['1'] = zero;

            zero.Transitions['0'] = Start;
            zero.Transitions['1'] = Accept;

            one.Transitions['0'] = Accept;
            one.Transitions['1'] = Start;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = Start;
            foreach (char c in s)
            {
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
  }
  
  public class FA3
  {
        public static State Start = new State()
        {
            Name = "Start State",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State a = new State()
        {
            Name = "Accept State",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public static State b = new State()
        {
            Name = "Decline State",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public FA3()
        {
            Start.Transitions['0'] = Start;
            Start.Transitions['1'] = b;
            a.Transitions['0'] = a;
            a.Transitions['1'] = a;
            b.Transitions['0'] = Start;
            b.Transitions['1'] = a;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = Start;
            foreach (char c in s)
            {
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
