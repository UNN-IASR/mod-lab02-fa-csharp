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
        public Dictionary<char, State> Transitions = new Dictionary<char, State>();
        public bool IsAcceptState;
    }

    public abstract class FA
    {
        protected State InitialState;

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;

            foreach (char c in s)
            {
                if (c != '0' && c != '1')
                {
                    return null;
                }

                if (!current.Transitions.ContainsKey(c))
                {
                    return null;
                }

                current = current.Transitions[c];

                if (current == null)
                {
                    return null;
                }
            }

            return current.IsAcceptState;
        }
    }

  
    public class FA1 : FA
    {
        public FA1()
        {
            State q0 = new State { Name = "q0", IsAcceptState = false };
            State q1 = new State { Name = "q1", IsAcceptState = false };
            State q2 = new State { Name = "q2", IsAcceptState = false };
            State q3 = new State { Name = "q3", IsAcceptState = true };
            State qDead = new State { Name = "qDead", IsAcceptState = false };

     
            q0.Transitions['0'] = q1;
            q0.Transitions['1'] = q2;

       
            q1.Transitions['0'] = qDead;
            q1.Transitions['1'] = q3;

       
            q2.Transitions['0'] = q3;
            q2.Transitions['1'] = q2;

            q3.Transitions['0'] = qDead;
            q3.Transitions['1'] = q3;

     
            qDead.Transitions['0'] = qDead;
            qDead.Transitions['1'] = qDead;

            InitialState = q0;
        }
    }

    public class FA2 : FA
    {
        public FA2()
        {
            State ee = new State { Name = "EE", IsAcceptState = false }; 
            State oe = new State { Name = "OE", IsAcceptState = false }; 
            State eo = new State { Name = "EO", IsAcceptState = false }; 
            State oo = new State { Name = "OO", IsAcceptState = true };  

            ee.Transitions['0'] = oe;
            ee.Transitions['1'] = eo;

            oe.Transitions['0'] = ee;
            oe.Transitions['1'] = oo;

            eo.Transitions['0'] = oo;
            eo.Transitions['1'] = ee;

            oo.Transitions['0'] = eo;
            oo.Transitions['1'] = oe;

            InitialState = ee;
        }
    }

  
    public class FA3 : FA
    {
        public FA3()
        {
            State q0 = new State { Name = "q0", IsAcceptState = false };
            State q1 = new State { Name = "q1", IsAcceptState = false };
            State q2 = new State { Name = "q2", IsAcceptState = true };

            q0.Transitions['0'] = q0;
            q0.Transitions['1'] = q1;

            q1.Transitions['0'] = q0;
            q1.Transitions['1'] = q2;

            q2.Transitions['0'] = q2;
            q2.Transitions['1'] = q2;

            InitialState = q0;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            string s1 = "11101";
            string s2 = "1010";
            string s3 = "101101";

            FA1 fa1 = new FA1();
            FA2 fa2 = new FA2();
            FA3 fa3 = new FA3();

            Console.WriteLine("FA1:");
            Console.WriteLine($"{s1} -> {fa1.Run(s1)}");
            Console.WriteLine();

            Console.WriteLine("FA2:");
            Console.WriteLine($"{s2} -> {fa2.Run(s2)}");
            Console.WriteLine();

            Console.WriteLine("FA3:");
            Console.WriteLine($"{s3} -> {fa3.Run(s3)}");
        }
    }
}
