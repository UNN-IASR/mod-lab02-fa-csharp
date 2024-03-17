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
        public bool? Run(IEnumerable<char> s, State InitialState)
        {
            State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                if (current == null) // если его нет, возвращаем признак ошибки             
                    return null;
                if (!current.Transitions.ContainsKey(c))//если нет перехода, false
                    return false;
                current = current.Transitions[c];// меняем состояние на то, в которое у нас переход
            }
            return current.IsAcceptState;         // результат true если в конце финальное состояние 
        }
    }

    public class FA1 : FA
    {
        public static State qstart = new State()
        {
            Name = "qstart",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q1 = new State()
        {
            Name = "q1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q0 = new State()
        {
            Name = "q0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State qend = new State()
        {
            Name = "qend",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = qstart;

        public FA1()
        {
            qstart.Transitions['0'] = q0;
            qstart.Transitions['1'] = q1;
            q0.Transitions['1'] = qend;
            q1.Transitions['1'] = q1;
            q1.Transitions['0'] = qend;
            qend.Transitions['1'] = qend;
        }
        public bool? Run(IEnumerable<char> s) => base.Run(s, InitialState);
    }

    public class FA2 : FA
    {
        public static State qstart = new State()
        {
            Name = "qstart",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q1 = new State()
        {
            Name = "q1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q0 = new State()
        {
            Name = "q0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State qend = new State()
        {
            Name = "qend",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = qstart;

        public FA2()
        {
            qstart.Transitions['0'] = q0;
            qstart.Transitions['1'] = q1;
            q0.Transitions['0'] = qstart;
            q0.Transitions['1'] = qend;
            q1.Transitions['0'] = qend;
            q1.Transitions['1'] = qstart;
            qend.Transitions['0'] = q1;
            qend.Transitions['1'] = q0;
        }
        public bool? Run(IEnumerable<char> s) => base.Run(s, InitialState);
    }

    public class FA3 : FA
    {
        public static State qstart = new State()
        {
            Name = "qstart",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q1 = new State()
        {
            Name = "q1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State qend = new State()
        {
            Name = "qend",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = qstart;

        public FA3()
        {
            qstart.Transitions['0'] = qstart;
            qstart.Transitions['1'] = q1;
            q1.Transitions['0'] = qstart;
            q1.Transitions['1'] = qend;
            qend.Transitions['0'] = qend;
            qend.Transitions['1'] = qend;
        }
        public bool? Run(IEnumerable<char> s) => base.Run(s, InitialState);
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
