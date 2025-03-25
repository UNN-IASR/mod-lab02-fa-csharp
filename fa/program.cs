using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
        string _name;
        bool _isAcceptState;
        public Dictionary<char, State> Transitions;

        public bool IsAcceptState {  get { return _isAcceptState; } }

        public State(string Name, bool IsAcceptState)
        {
            this._name = Name;
            Transitions = new Dictionary<char, State>();
            this._isAcceptState = IsAcceptState;
        }
  }


  public class FA1
  {
        static State q0 = new State("q0", false); //начальное состояние
        static State q1 = new State("q1", false); //встретили хотя бы одну 1, 0 еще не встретили
        static State q2 = new State("q2", false); //встретили ровно один 0, но 1 еще не встречена
        static State q3 = new State("q3", true);  //встречен ровно один 0 и хотя бы 1 единиица
        static State q4 = new State("q4", false); //встречено более одного 0
        State InitialState = q0;

        public FA1()
        {
            q0.Transitions['0'] = q2;
            q0.Transitions['1'] = q1;

            q1.Transitions['0'] = q3;
            q1.Transitions['1'] = q1;

            q2.Transitions['0'] = q4;
            q2.Transitions['1'] = q3;

            q3.Transitions['0'] = q4;
            q3.Transitions['1'] = q3;

            q4.Transitions['0'] = q4;
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
        static State q1 = new State("q1", false); // оба четные
        static State q2 = new State("q2", false); //четное 0 и нечетное 1
        static State q3 = new State("q3", false); //нечетное 0 и четное 1
        static State q4 = new State("q4", true); //оба нечетные
        State InitialState = q1;

        public FA2()
        {
            q1.Transitions['0'] = q3;
            q1.Transitions['1'] = q2;

            q2.Transitions['0'] = q4;
            q2.Transitions['1'] = q1;

            q3.Transitions['0'] = q1;
            q3.Transitions['1'] = q4;

            q4.Transitions['0'] = q2;
            q4.Transitions['1'] = q3;
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
        static State q1 = new State("q1", false); // ищем 1
        static State q2 = new State("q2", false); //нашли 1
        static State q3 = new State("q3", true); //нашли две 1 подряд

        State InitialState = q1;

        public FA3()
        {
            q1.Transitions['0'] = q1;
            q1.Transitions['1'] = q2;

            q2.Transitions['0'] = q1;
            q2.Transitions['1'] = q3;

            q3.Transitions['0'] = q3;
            q3.Transitions['1'] = q3;
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