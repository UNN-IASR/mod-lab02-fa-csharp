namespace fans
{
    public class State(string name, bool isAcceptState)
    {
        public string Name = name;
        public Dictionary<char, State> Transitions = [];
        public bool IsAcceptState = isAcceptState;
    }

    public class FA1
    {
        public State a = new("a", false);
        public State b = new("b", false);
        public State c = new("c", false);
        public State d = new("d", false);
        public State e = new("e", true);

        private State InitialState => a;

        public FA1()
        {
            a.Transitions['0'] = b;
            a.Transitions['1'] = c;
            b.Transitions['0'] = d;
            b.Transitions['1'] = e;
            c.Transitions['0'] = e;
            c.Transitions['1'] = c;
            d.Transitions['0'] = d;
            d.Transitions['1'] = d;
            e.Transitions['0'] = d;
            e.Transitions['1'] = e;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (char c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                {
                    return null;
                }
            }
            return current.IsAcceptState;
        }
    }

    public class FA2
    {
        public State a = new("a", false);
        public State b = new("b", false);
        public State c = new("c", false);
        public State d = new("d", true);

        private State InitialState => a;

        public FA2()
        {
            a.Transitions['0'] = b;
            a.Transitions['1'] = c;
            b.Transitions['0'] = a;
            b.Transitions['1'] = d;
            c.Transitions['0'] = d;
            c.Transitions['1'] = a;
            d.Transitions['0'] = c;
            d.Transitions['1'] = b;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (char c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                {
                    return null;
                }
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        public State a = new("a", false);
        public State b = new("b", false);
        public State c = new("c", true);

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
            foreach (char c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                {
                    return null;
                }
            }
            return current.IsAcceptState;
        }
    }

    internal class Program
    {
        private static void Main()
        {
            String s = "01111";

            var fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);

            var fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);

            var fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}
