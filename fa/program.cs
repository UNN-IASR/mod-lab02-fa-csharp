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
            public State One = new State()
            {
                Name = "One",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };
            public State Zero = new State()
            {
                Name = "Zero",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };
            public State YES = new State()
            {
                Name = "YES",
                IsAcceptState = true,
                Transitions = new Dictionary<char, State>()
            };

            State InitialState = Start;

            public FA1()
            {
                Start.Transitions['0'] = Zero;
                Start.Transitions['1'] = One;
                One.Transitions['0'] = YES;
                One.Transitions['1'] = One;
                Zero.Transitions['1'] = YES;
                Zero.Transitions['0'] = null;
                YES.Transitions['1'] = YES;
                YES.Transitions['0'] = null;
            }

            public bool? Run(IEnumerable<char> s)
            {
                State current = InitialState;
                foreach (var c in s) // цикл по всем символам 
                {
                    current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                    if (current == null)              // если его нет, возвращаем признак ошибки
                        return false;
                    // иначе переходим к следующему
                }
                return current.IsAcceptState;         // результат true если в конце финальное состояние 
            }
  }

  public class FA2
  {
            public static State Zero = new State()
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
            public State Two = new State()
            {
                Name = "Two",
                IsAcceptState = false,
                Transitions = new Dictionary<char, State>()
            };
            public State Three = new State()
            {
                Name = "Four",
                IsAcceptState = true,
                Transitions = new Dictionary<char, State>()
            };

            State InitialState = Zero;

            public FA2()
            {
                Zero.Transitions['0'] = Two;
                Zero.Transitions['1'] = One;
                One.Transitions['1'] = Zero;
                One.Transitions['0']= Three;
                Two.Transitions['1'] = Three;
                Two.Transitions['0']= Zero;
                Three.Transitions['1'] = Two;
                Three.Transitions['0'] = One;
            }

            public bool? Run(IEnumerable<char> s)
            {
                State current = InitialState;
                foreach (var c in s) // цикл по всем символам 
                {
                    current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                    if (current == null)              // если его нет, возвращаем признак ошибки
                        return false;
                    // иначе переходим к следующему
                }
                return current.IsAcceptState;         // результат true если в конце финальное состояние 
            }
  }
  
  public class FA3
  {
            public static State Zero = new State()
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
            public State Two = new State()
            {
                Name = "Two",
                IsAcceptState = true,
                Transitions = new Dictionary<char, State>()
            };
            State InitialState = Zero;

            public FA3()
            {
                Zero.Transitions['0'] = Zero;
                Zero.Transitions['1'] = One;
                One.Transitions['1']=Two;
                One.Transitions['0'] = Zero;
            }

            public bool? Run(IEnumerable<char> s)
            {
                State current = InitialState;
                foreach (var c in s) // цикл по всем символам 
                {
                    current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                    if (current.IsAcceptState == true)              // если его нет, возвращаем признак ошибки
                        return true;
                    // иначе переходим к следующему
                }
                return current.IsAcceptState;         // результат true если в конце финальное состояние 
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
