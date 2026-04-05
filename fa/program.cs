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
        private State startState;

        public FA1()
        {
            var s0 = new State { Name = "S0", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            var s1 = new State { Name = "S1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            var s2 = new State { Name = "S2", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            var s3 = new State { Name = "S3", IsAcceptState = true, Transitions = new Dictionary<char, State>() };
            var s4 = new State { Name = "S4", IsAcceptState = false, Transitions = new Dictionary<char, State>() };

            s0.Transitions['0'] = s2;
            s0.Transitions['1'] = s1;
            s1.Transitions['0'] = s3;
            s1.Transitions['1'] = s1;
            s2.Transitions['0'] = s4;
            s2.Transitions['1'] = s3;
            s3.Transitions['0'] = s4;
            s3.Transitions['1'] = s3;
            s4.Transitions['0'] = s4;
            s4.Transitions['1'] = s4;
            startState = s0;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = startState;
            foreach (char c in s)
            {
                if (!current.Transitions.TryGetValue(c, out State next))
                    return null;
                current = next;
            }
            return current.IsAcceptState;
        }
    }

    public class FA2
    {
        private State startState;

        public FA2()
        {
            var s00 = new State { Name = "S00", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            var s01 = new State { Name = "S01", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            var s10 = new State { Name = "S10", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            var s11 = new State { Name = "S11", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

            s00.Transitions['0'] = s10;
            s00.Transitions['1'] = s01;
            s01.Transitions['0'] = s11;
            s01.Transitions['1'] = s00;
            s10.Transitions['0'] = s00;
            s10.Transitions['1'] = s11;
            s11.Transitions['0'] = s01;
            s11.Transitions['1'] = s10;
            startState = s00;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = startState;
            foreach (char c in s)
            {
                if (!current.Transitions.TryGetValue(c, out State next))
                    return null;
                current = next;
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        private State startState;

        public FA3()
        {
            var s0 = new State { Name = "S0", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            var s1 = new State { Name = "S1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            var s2 = new State { Name = "S2", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

            s0.Transitions['0'] = s0;
            s0.Transitions['1'] = s1;
            s1.Transitions['0'] = s0;
            s1.Transitions['1'] = s2;
            s2.Transitions['0'] = s2;
            s2.Transitions['1'] = s2;
            startState = s0;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = startState;
            foreach (char c in s)
            {
                if (!current.Transitions.TryGetValue(c, out State next))
                    return null;
                current = next;
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