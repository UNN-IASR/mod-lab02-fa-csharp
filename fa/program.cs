using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fa
{ 
    public class State
    {
        private string _name;
        private Dictionary<char, State> _transitions;
        private bool isAcceptState;

        public string Name { get => _name; set => _name = value; }
        public Dictionary<char, State> Transitions { get => _transitions; set => _transitions = value; }
        public bool IsAcceptState { get => isAcceptState; set => isAcceptState = value; }

        public State(string name, bool state)
        {
            Name = name;
            IsAcceptState = state;
            Transitions = new Dictionary<char, State>();
        }
    }

    public class FA1
    {
        private static State a = new State("a", false);
        private static State b = new State("b", false);
        private static State c = new State("c", false);
        private static State d = new State("d", false);
        private static State e = new State("e", false);
        private static State f = new State("f", true);
        private State InitialState => a;
        public FA1()
        {
            a.Transitions['0'] = b;
            a.Transitions['1'] = c;
            b.Transitions['1'] = f;
            b.Transitions['0'] = d;
            c.Transitions['1'] = c;
            c.Transitions['0'] = f;
            d.Transitions['1'] = d;
            d.Transitions['0'] = e;
            e.Transitions['0'] = e;
            e.Transitions['1'] = d;
            f.Transitions['1'] = f;
            f.Transitions['0'] = e;
        }
        public bool? Run(IEnumerable<char> _str)
        {
            State current = InitialState;
            foreach (var c in _str)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }


    }


    public class FA2
    {
        private static State a = new State("a", false);
        private static State b = new State("b", false);
        private static State c = new State("c", false);
        private static State d = new State("d", true);

        private State InitialState => a;

        public FA2()
        {
            a.Transitions['0'] = c;
            a.Transitions['1'] = b;
            b.Transitions['0'] = d;
            b.Transitions['1'] = a;
            c.Transitions['0'] = a;
            c.Transitions['1'] = d;
            d.Transitions['0'] = b;
            d.Transitions['1'] = c;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        private static State a = new State("a", false);
        private static State b = new State("b", false);
        private static State c = new State("c", true);

        private State InitialState => a;

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
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
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
