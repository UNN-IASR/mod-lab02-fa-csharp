using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string Label;
    public Dictionary<char, State> Paths;
    public bool IsFinalState;
  }

  public class FA1
  {
        public static State start = new State()
        {
            Label = "start",
            IsFinalState = false,
            Paths = new Dictionary<char, State>()
        };
        public static State mid1 = new State()
        {
            Label = "mid1",
            IsFinalState = false,
            Paths = new Dictionary<char, State>()
        };
        public static State mid2 = new State()
        {
            Label = "mid2",
            IsFinalState = false,
            Paths = new Dictionary<char, State>()
        };
        public static State mid3 = new State()
        {
            Label = "mid3",
            IsFinalState = false,
            Paths = new Dictionary<char, State>()
        };
        public static State accept = new State()
        {
            Label = "accept",
            IsFinalState = true,
            Paths = new Dictionary<char, State>()
        };

        State EntryState = start;

        public FA1()
        {
            start.Paths['0'] = mid1;
            start.Paths['1'] = mid2;
            mid1.Paths['0'] = mid3;
            mid1.Paths['1'] = accept;
            mid2.Paths['0'] = accept;
            mid2.Paths['1'] = mid2;
            mid3.Paths['0'] = mid3;
            mid3.Paths['1'] = mid3;
            accept.Paths['0'] = mid3;
            accept.Paths['1'] = accept;
        }

        public bool? Run(IEnumerable<char> input)
        {
            State current = EntryState;
            foreach (var symbol in input)
            {
                current = current.Paths[symbol];
            }
            return current.IsFinalState;
        }
  }

  public class FA2
  {
        public static State start = new State()
        {
            Label = "start",
            IsFinalState = false,
            Paths = new Dictionary<char, State>()
        };
        public static State step1 = new State()
        {
            Label = "step1",
            IsFinalState = false,
            Paths = new Dictionary<char, State>()
        };
        public static State step2 = new State()
        {
            Label = "step2",
            IsFinalState = false,
            Paths = new Dictionary<char, State>()
        };
        public static State success = new State()
        {
            Label = "success",
            IsFinalState = true,
            Paths = new Dictionary<char, State>()
        };

        State EntryState = start;

        public FA2()
        {
            start.Paths['0'] = step2;
            start.Paths['1'] = step1;
            step1.Paths['0'] = success;
            step1.Paths['1'] = start;
            step2.Paths['0'] = start;
            step2.Paths['1'] = success;
            success.Paths['0'] = step1;
            success.Paths['1'] = step2;
        }
        public bool? Run(IEnumerable<char> input)
        {
            State current = EntryState;
            foreach (var symbol in input)
            {
                current = current.Paths[symbol];
            }
            return current.IsFinalState;
        }
    }
  
  public class FA3
  {
        public static State start = new State()
        {
            Label = "start",
            IsFinalState = false,
            Paths = new Dictionary<char, State>()
        };
        public static State middle = new State()
        {
            Label = "middle",
            IsFinalState = false,
            Paths = new Dictionary<char, State>()
        };
        public static State end = new State()
        {
            Label = "end",
            IsFinalState = true,
            Paths = new Dictionary<char, State>()
        };

        State EntryState = start;

        public FA3()
        {
            start.Paths['0'] = start;
            start.Paths['1'] = middle;
            middle.Paths['0'] = start;
            middle.Paths['1'] = end;
            end.Paths['0'] = end;
            end.Paths['1'] = end;
        }
        public bool? Run(IEnumerable<char> input)
        {
            State current = EntryState;
            foreach (var symbol in input)
            {
                current = current.Paths[symbol];
            }
            return current.IsFinalState;
        }
    }

  class Program
  {
    static void Main(string[] args)
    {
      String s = "01111";
      FA1 automaton1 = new FA1();
      bool? result1 = automaton1.Run(s);
      Console.WriteLine(result1);
      FA2 automaton2 = new FA2();
      bool? result2 = automaton2.Run(s);
      Console.WriteLine(result2);
      FA3 automaton3 = new FA3();
      bool? result3 = automaton3.Run(s);
      Console.WriteLine(result3);
    }
  }
}
