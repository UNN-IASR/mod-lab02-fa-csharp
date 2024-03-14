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
        public static State q_0 = new State()
        {
            Name = "q_0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q_1 = new State()
        {
            Name = "q_1",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public State q_2 = new State()
        {
            Name = "q_2",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        
        State InitialState = q_0;

        public FA1()
        {
            q_0.Transitions['0'] = q_1;
            q_0.Transitions['1'] = q_0;
            q_1.Transitions['0'] = q_2;
            q_1.Transitions['1'] = q_1;
            q_2.Transitions['0'] = q_2;
            q_2.Transitions['1'] = q_2;         
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
            return current.IsAcceptState;         // результат true если в конце финальное состояние 
        }
    }

    public class FA2
    {
        public static State q_0 = new State()
        {
            Name = "q_0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q_1 = new State()
        {
            Name = "q_1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q_2 = new State()
        {
            Name = "q_2",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public State q_3 = new State()
        {
            Name = "q_3",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        
        State InitialState = q_0;

        public FA2()
        {
            q_0.Transitions['0'] = q_1;
            q_0.Transitions['1'] = q_3;
            q_1.Transitions['0'] = q_0;
            q_1.Transitions['1'] = q_2;
            q_2.Transitions['0'] = q_3;
            q_2.Transitions['1'] = q_1;
            q_3.Transitions['0'] = q_2;
            q_3.Transitions['1'] = q_3;         
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
            return current.IsAcceptState;         // результат true если в конце финальное состояние 
        }
    }
    
    public class FA3
    {
        public static State q_0 = new State()
        {
            Name = "q_0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q_1 = new State()
        {
            Name = "q_1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q_2 = new State()
        {
            Name = "q_2",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        
        State InitialState = q_0;

        public FA3()
        {
            q_0.Transitions['0'] = q_0;
            q_0.Transitions['1'] = q_1;
            q_1.Transitions['0'] = q_0;
            q_1.Transitions['1'] = q_2;
            q_2.Transitions['0'] = q_2;
            q_2.Transitions['1'] = q_2;        
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
