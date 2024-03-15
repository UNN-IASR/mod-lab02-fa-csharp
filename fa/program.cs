using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
        public State(string name, Dictionary<char, State> transitions, bool isAcceptState)
        {
            if (name != null) {
                Name = name;
            }
            else Name = "";
            if (transitions != null) {
                Transitions = transitions;
            }
            else Transitions = new Dictionary<char, State> ();
            IsAcceptState = isAcceptState;
        }
        public State() {
            Name = "";
            Transitions = new Dictionary<char, State> ();
            IsAcceptState = false;
        }
    }

    public class FA1
    {
        public State q0 = new State("q0", new Dictionary<char, State>(), false);
        public State q1 = new State("q1", new Dictionary<char, State>(), false);
        public State q2 = new State("q2", new Dictionary<char, State>(), false);
        public State q3 = new State("q3", new Dictionary<char, State>(), true);
        public State q4 = new State("q4", new Dictionary<char, State>(), false);
        public State initstate = new State();
        public FA1()
        {
           q0.Transitions['0'] = q1;
           q0.Transitions['1'] = q4;
           q1.Transitions['0'] = q2;
           q1.Transitions['1'] = q3;
           q2.Transitions['0'] = q2;
           q2.Transitions['1'] = q2;     
           q3.Transitions['0'] = q2;
           q3.Transitions['1'] = q3;
           q4.Transitions['0'] = q3;
           q4.Transitions['1'] = q4;         
        }
        public bool? Run(IEnumerable<char> s)
        {
            initstate = q0;
            State current = initstate;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;         // результат true если в конце финальное состояние 
        }
    }

    public class FA2
    {
        public State q0 = new State("q0", new Dictionary<char, State>(), false);
        public State q1 = new State("q1", new Dictionary<char, State>(), false);
        public State q2 = new State("q2", new Dictionary<char, State>(), false);
        public State q3 = new State("q3", new Dictionary<char, State>(), false);
        public State q4 = new State("q4", new Dictionary<char, State>(), true);
        public State q5 = new State("q5", new Dictionary<char, State>(), false);
        public State q6 = new State("q6", new Dictionary<char, State>(), false);
        public State q7 = new State("q7", new Dictionary<char, State>(), false);
        public State q8 = new State("q8", new Dictionary<char, State>(), false);
        
        public State initstate = new State();
        public FA2()
        {
           q0.Transitions['0'] = q1;
           q0.Transitions['1'] = q3;
           q1.Transitions['0'] = q2;
           q1.Transitions['1'] = q4;
           q2.Transitions['0'] = q1;
           q2.Transitions['1'] = q5;     
           q3.Transitions['0'] = q4;
           q3.Transitions['1'] = q6;    
           q4.Transitions['0'] = q5;
           q4.Transitions['1'] = q7;
           q5.Transitions['0'] = q4;
           q5.Transitions['1'] = q8;
           q6.Transitions['0'] = q7;
           q6.Transitions['1'] = q3; 
           q7.Transitions['0'] = q8;
           q7.Transitions['1'] = q4;
           q8.Transitions['0'] = q7;
           q8.Transitions['1'] = q5;  
        }
        public bool? Run(IEnumerable<char> s)
        {
            initstate = q0;
            State current = initstate;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;         // результат true если в конце финальное состояние 
        }
    }

    public class FA3
    {
        public State q0 = new State("q0", new Dictionary<char, State>(), false);
        public State q1 = new State("q1", new Dictionary<char, State>(), false);
        public State q2 = new State("q2", new Dictionary<char, State>(), true);
        public State q3 = new State("q3", new Dictionary<char, State>(), false);
        public State initstate = new State();
        public FA3()
        {
           q0.Transitions['0'] = q0;
           q0.Transitions['1'] = q1;
           q1.Transitions['0'] = q3;
           q1.Transitions['1'] = q2;
           q2.Transitions['0'] = q2;
           q2.Transitions['1'] = q2;     
           q3.Transitions['0'] = q0;
           q3.Transitions['1'] = q1;       
        }
        public bool? Run(IEnumerable<char> s)
        {
            initstate = q0;
            State current = initstate;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
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
