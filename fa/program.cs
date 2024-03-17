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
        State q0, q1, q2, q3;

        public FA1()
        {
            q0 = new State() { Name = "q0", Transitions = new Dictionary<char, State>(), IsAcceptState = false };
            q1 = new State() { Name = "q1", Transitions = new Dictionary<char, State>(), IsAcceptState = false };
            q2 = new State() { Name = "q2", Transitions = new Dictionary<char, State>(), IsAcceptState = false };
            q3 = new State() { Name = "q3", Transitions = new Dictionary<char, State>(), IsAcceptState = true };

            q0.Transitions['0'] = q1;
            q0.Transitions['1'] = q2;
            q1.Transitions['1'] = q3;
            q2.Transitions['1'] = q2;
            q2.Transitions['0'] = q3;
            q3.Transitions['1'] = q3;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = q0;
            foreach (var c in s)
            {
                if (current == null)
                    return null;
                if (!current.Transitions.ContainsKey(c))
                {
                    return false;
                }
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    public class FA2
    {
        State q0, q1, q2, q3;

        public FA2()
        {
            q0 = new State() { Name = "q0", Transitions = new Dictionary<char, State>(), IsAcceptState = false };
            q1 = new State() { Name = "q1", Transitions = new Dictionary<char, State>(), IsAcceptState = false };
            q2 = new State() { Name = "q2", Transitions = new Dictionary<char, State>(), IsAcceptState = false };
            q3 = new State() { Name = "q3", Transitions = new Dictionary<char, State>(), IsAcceptState = true };

            q0.Transitions['0'] = q1;
            q1.Transitions['0'] = q0;
            q0.Transitions['1'] = q2;
            q2.Transitions['1'] = q0;
            q1.Transitions['1'] = q3;
            q3.Transitions['1'] = q1;
            q2.Transitions['0'] = q3;
            q3.Transitions['0'] = q2;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = q0;
            foreach (var c in s)
            {
                if (current == null)
                    return null;
                if (!current.Transitions.ContainsKey(c))
                {
                    return false;
                }
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        State q0, q1, q2;

        public FA3()
        {
            q0 = new State() { Name = "q0", Transitions = new Dictionary<char, State>(), IsAcceptState = false };
            q1 = new State() { Name = "q1", Transitions = new Dictionary<char, State>(), IsAcceptState = false };
            q2 = new State() { Name = "q2", Transitions = new Dictionary<char, State>(), IsAcceptState = true };

            q0.Transitions['0'] = q0;
            q0.Transitions['1'] = q1;
            q1.Transitions['1'] = q2;
            q2.Transitions['0'] = q2;
            q2.Transitions['1'] = q2;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = q0;
            foreach (var c in s)
            {
                if (current == null)
                    return null;
                if (!current.Transitions.ContainsKey(c))
                {
                    return false;
                }
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "0101";
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