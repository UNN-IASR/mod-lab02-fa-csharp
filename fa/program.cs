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
        public static State i0 = new State(){
          Name = "i0",
          IsAcceptState = false,
          Transitions = new Dictionary<char, State>()
        };

        public static State i1 = new State(){
          Name = "i1",
          IsAcceptState = false,
          Transitions = new Dictionary<char, State>()
        };

        public static State i2 = new State(){
          Name = "i2",
          IsAcceptState = false,
          Transitions = new Dictionary<char, State>()
        };

        public static State i3 = new State(){
          Name = "i3",
          IsAcceptState = true,
          Transitions = new Dictionary<char, State>()
        };

        public static State i4 = new State(){
          Name = "i4",
          IsAcceptState = false,
          Transitions = new Dictionary<char, State>()
        };

        State InitialState = i0;

        public FA1() {
            i0.Transitions['0'] = i1;
            i0.Transitions['1'] = i2;

            i1.Transitions['0'] = i4;
            i1.Transitions['1'] = i3;

            i2.Transitions['0'] = i3;
            i2.Transitions['1'] = i2;

            i3.Transitions['0'] = i4;
            i3.Transitions['1'] = i3;

            i4.Transitions['0'] = i4;
            i4.Transitions['1'] = i4;
        }

        public bool ? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach(var c in s)
            {
                current = current.Transitions[c];
                if (current == null) return null;
            }
            return current.IsAcceptState;
        }
    }

    public class FA2
    {
        public static State i0 = new State(){
            Name = "i0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State i1 = new State(){
            Name = "i1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State i2 = new State(){
            Name = "i2",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State i3 = new State(){
            Name = "i3",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        public static State i4 = new State(){
            Name = "i4",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = i0;

        public FA2() {
            i0.Transitions['0'] = i1;
            i0.Transitions['1'] = i2;

            i1.Transitions['0'] = i0;
            i1.Transitions['1'] = i3;

            i2.Transitions['0'] = i4;
            i2.Transitions['1'] = i0;

            i3.Transitions['0'] = i2;
            i3.Transitions['1'] = i1;

            i4.Transitions['0'] = i2;
            i4.Transitions['1'] = i1;
        }

        public bool ? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach(var c in s)
            {
                current = current.Transitions[c];
                if (current == null) return null;
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        public static State i0 = new State(){
            Name = "i0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State i1 = new State(){
            Name = "i1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        public static State i2 = new State(){
            Name = "i2",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = i0;

        public FA3() {
            i0.Transitions['0'] = i0;
            i0.Transitions['1'] = i1;

            i1.Transitions['0'] = i0;
            i1.Transitions['1'] = i2;

            i2.Transitions['0'] = i2;
            i2.Transitions['1'] = i2;
        }

        public bool ? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach(var c in s)
            {
                current = current.Transitions[c];
                if (current == null) return null;
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
            bool ? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool ? result2 = fa2.Run(s);
            Console.WriteLine(result2);
            FA3 fa3 = new FA3();
            bool ? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}
