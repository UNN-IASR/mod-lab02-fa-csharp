using System;
using System.Collections.Generic;

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
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State()
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;

        public FA()
        {
            a.Transitions['0'] = a;
            a.Transitions['1'] = b;
            b.Transitions['0'] = c;
            b.Transitions['1'] = a;
            c.Transitions['0'] = b;
            c.Transitions['1'] = c;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    public class FA1
    {
        private State start;

        public FA1()
        {
            var s0 = new State { Name = "s0", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            var s1 = new State { Name = "s1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            var s2 = new State { Name = "s2", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            var s3 = new State { Name = "s3", IsAcceptState = true, Transitions = new Dictionary<char, State>() };
            var s4 = new State { Name = "s4", IsAcceptState = false, Transitions = new Dictionary<char, State>() };

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

            start = s0;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = start;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    public class FA2
    {
        private State start;

        public FA2()
        {
            var q00 = new State { Name = "q00", IsAcceptState = false, Transitions = new Dictionary<char, State>() }; // чёт 0, чёт 1
            var q01 = new State { Name = "q01", IsAcceptState = false, Transitions = new Dictionary<char, State>() }; // чёт 0, нечёт 1
            var q10 = new State { Name = "q10", IsAcceptState = false, Transitions = new Dictionary<char, State>() }; // нечёт 0, чёт 1
            var q11 = new State { Name = "q11", IsAcceptState = true, Transitions = new Dictionary<char, State>() };  // нечёт 0, нечёт 1

            q00.Transitions['0'] = q10;
            q00.Transitions['1'] = q01;

            q01.Transitions['0'] = q11;
            q01.Transitions['1'] = q00;

            q10.Transitions['0'] = q00;
            q10.Transitions['1'] = q11;

            q11.Transitions['0'] = q01;
            q11.Transitions['1'] = q10;

            start = q00;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = start;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    // ДКА для задачи 3: содержит подстроку "11"
    public class FA3
    {
        private State start;

        public FA3()
        {
            var q0 = new State { Name = "q0", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            var q1 = new State { Name = "q1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            var q2 = new State { Name = "q2", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

            q0.Transitions['0'] = q0;
            q0.Transitions['1'] = q1;

            q1.Transitions['0'] = q0;
            q1.Transitions['1'] = q2;

            q2.Transitions['0'] = q2;
            q2.Transitions['1'] = q2;

            start = q0;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = start;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Пример использования
            string s = "0000010111";
            FA fa = new FA();
            bool? result = fa.Run(s);
            Console.WriteLine(result);
        }
    }
}
