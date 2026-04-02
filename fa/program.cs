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
    public static State q0 = new State() // Нет 0 и 1
        {
            Name = "q0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
    public static State q1 = new State() // Есть 0, но нет 1
        {
            Name = "q1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
    public static State q2 = new State() // Нет 0, но есть 1
        {
            Name = "q2",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
    public static State q3 = new State() // Больше одного 0
        {
            Name = "q3",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
    public static State q4 = new State() // Есть 0 и 1
        {
            Name = "q4",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
    State InitialState = q0;
    public FA1()
    {
      q0.Transitions['0'] = q1;
      q0.Transitions['1'] = q2; 

      q1.Transitions['0'] = q3;
      q1.Transitions['1'] = q4;

      q2.Transitions['0'] = q4;
      q2.Transitions['1'] = q2;

      q3.Transitions['0'] = q3;
      q3.Transitions['1'] = q3;

      q4.Transitions['0'] = q3;
      q4.Transitions['1'] = q4;
    }
    public bool? Run(IEnumerable<char> s)
    {
      State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;   
    }
  }

  public class FA2
  {
    public static State q0 = new State() // Четные 0, четные 1
        {
            Name = "q0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
    public static State q1 = new State() // четные 0, нечетные 1
        {
            Name = "q1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
    public static State q2 = new State() // нечетные 0, четные 1
        {
            Name = "q2",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
    public static State q3 = new State() // Оба нечетные
        {
            Name = "q3",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

    State InitialState = q0;
    public FA2()
    {
      q0.Transitions['0'] = q2;
      q0.Transitions['1'] = q1; 

      q1.Transitions['0'] = q3;
      q1.Transitions['1'] = q0;

      q2.Transitions['0'] = q0;
      q2.Transitions['1'] = q3;

      q3.Transitions['0'] = q1;
      q3.Transitions['1'] = q2;

    }
    public bool? Run(IEnumerable<char> s)
    {
      State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;   
    }
  }
  
  public class FA3
  {
    public static State q0 = new State() // Не содержит вообще 1
        {
            Name = "q0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
    public static State q1 = new State() // Содержит 1 единицу
        {
            Name = "q1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
    public static State q2 = new State() // Содержит 11
        {
            Name = "q2",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
    State InitialState = q0;
    public FA3()
    {
      q0.Transitions['0'] = q0;
      q0.Transitions['1'] = q1; 

      q1.Transitions['0'] = q0;
      q1.Transitions['1'] = q2;

      q2.Transitions['0'] = q2;
      q2.Transitions['1'] = q2;
    }
    public bool? Run(IEnumerable<char> s)
    {
      State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
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