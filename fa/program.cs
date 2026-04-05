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

    public class FA1
    {
        // Допускает бинарную строку, содержащую ровно один '0' и хотя бы одну '1'
        public bool? Run(IEnumerable<char> s)
        {
            int zeroCount = 0;
            int oneCount = 0;

            foreach (char c in s)
            {
                if (c == '0')
                {
                    zeroCount++;
                }
                else if (c == '1')
                {
                    oneCount++;
                }
                else
                {
                    return null; // не бинарная строка
                }
            }

            return zeroCount == 1 && oneCount >= 1;
        }
    }

    public class FA2
    {
        // Допускает бинарную строку, содержащую нечетное количество '0' и нечетное количество '1'
        public bool? Run(IEnumerable<char> s)
        {
            int zeroCount = 0;
            int oneCount = 0;

            foreach (char c in s)
            {
                if (c == '0')
                {
                    zeroCount++;
                }
                else if (c == '1')
                {
                    oneCount++;
                }
                else
                {
                    return null; // не бинарная строка
                }
            }

            return zeroCount % 2 == 1 && oneCount % 2 == 1;
        }
    }

    public class FA3
    {
        // Допускает бинарную строку, содержащую подстроку "11"
        public bool? Run(IEnumerable<char> s)
        {
            bool previousWasOne = false;

            foreach (char c in s)
            {
                if (c != '0' && c != '1')
                {
                    return null; // не бинарная строка
                }

                if (c == '1')
                {
                    if (previousWasOne)
                    {
                        return true;
                    }

                    previousWasOne = true;
                }
                else
                {
                    previousWasOne = false;
                }
            }

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string s = "01111";

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
