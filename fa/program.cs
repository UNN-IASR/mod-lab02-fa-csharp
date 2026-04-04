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
        public bool? Run(IEnumerable<char> s)
        {
            int counter_0 = 0;
            int counter_1 = 0;
            foreach (var item in s)
            {
                if (item == '0')
                {
                    counter_0++;
                    if (counter_0 > 1)
                    {
                        return false;
                    }
                }
                else if (item == '1')
                {
                    counter_1++;
                }
            }
            if ((counter_1 == 0) && ((counter_1 + counter_0) != s.Count()))
            {
                return false;
            }
            return true;
        }
    }

    public class FA2
    {
        public bool? Run(IEnumerable<char> s)
        {
            int counter_0 = 0;
            int counter_1 = 0;
            foreach (var item in s)
            {
                if (item == '0')
                {
                    counter_0++;
                }
                else if (item == '1')
                {
                    counter_1++;
                }
            }
            if (((counter_0 + counter_1) != s.Count()) && (counter_0 % 2 == 1) && (counter_1 % 2 == 1))
            {
                return true;
            }
            return false;
        }
    }

    public class FA3
    {
        public bool? Run(IEnumerable<char> s)
        {
            string tmp = "";
            foreach (var item in s)
            {
                if (tmp.Count() < 2)
                {
                    tmp += item.ToString();
                }
                else if (tmp.Length == 2 && tmp == "11")
                {
                    return true;
                }
                else
                {
                    tmp = tmp.Substring(1);
                }
            }
            return false;
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
