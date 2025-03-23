
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
        public static State q0 = new State()
        {
            Name = "q0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q1 = new State()
        {
            Name = "q1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q2 = new State()
        {
            Name = "q2",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q3 = new State()
        {
            Name = "q3",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public State q4 = new State()
        {
            Name = "q4",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public State q5 = new State()
        {
            Name = "q5",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = q0;

        public FA1()
        {
            q0.Transitions['0'] = q1;
            q0.Transitions['1'] = q2;
            q1.Transitions['0'] = q5;
            q1.Transitions['1'] = q3;
            q3.Transitions['0'] = q5;
            q3.Transitions['1'] = q3;
            q2.Transitions['0'] = q4;
            q2.Transitions['1'] = q2;
            q4.Transitions['0'] = q5;
            q4.Transitions['1'] = q4;
            q5.Transitions['0'] = q5;
            q5.Transitions['1'] = q5;
        }
        public bool Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    public class FA2
    {
        public static State q00 = new State()
        {
            Name = "q00",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q10 = new State()
        {
            Name = "q10",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q01 = new State()
        {
            Name = "q01",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q11 = new State()
        {
            Name = "q11",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = q00;

        public FA2()
        {
            q00.Transitions['0'] = q10;
            q00.Transitions['1'] = q01;
            q01.Transitions['0'] = q11;
            q01.Transitions['1'] = q00;
            q10.Transitions['0'] = q00;
            q10.Transitions['1'] = q11;
            q11.Transitions['0'] = q01;
            q11.Transitions['1'] = q10;
        }
        public bool Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        public static State q0 = new State()
        {
            Name = "q0",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q1 = new State()
        {
            Name = "q1",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State q2 = new State()
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
        public bool Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
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