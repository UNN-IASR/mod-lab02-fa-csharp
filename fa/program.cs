using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class FA1
    {
        public bool? Run(string s)
        {
            // Состояния:
            // q0: не встречено '0'
            // q1: встречен один '0', но нет '1'
            // q2: встречен один '0' и хотя бы один '1' (принимающее)
            // q3: более одного '0' (не принимающее)
            int state = 0;

            foreach (char c in s)
            {
                if (c != '0' && c != '1') return null; // Некорректный символ

                switch (state)
                {
                    case 0: // q0
                        if (c == '0') state = 1;
                        break;
                    case 1: // q1
                        if (c == '0') state = 3;
                        else if (c == '1') state = 2;
                        break;
                    case 2: // q2
                        if (c == '0') state = 3;
                        break;
                    case 3: // q3
                        break;
                }
            }

            return state == 2; // Принимающее состояние — q2
        }
    }

    public class FA2
    {
        public bool? Run(string s)
        {
            // Состояния:
            // q00: четное '0', четное '1'
            // q01: четное '0', нечетное '1'
            // q10: нечетное '0', четное '1'
            // q11: нечетное '0', нечетное '1' (принимающее)
            int state = 0;

            foreach (char c in s)
            {
                if (c != '0' && c != '1') return null; // Некорректный символ

                switch (state)
                {
                    case 0: // q00
                        if (c == '0') state = 2;
                        else if (c == '1') state = 1;
                        break;
                    case 1: // q01
                        if (c == '0') state = 3;
                        else if (c == '1') state = 0;
                        break;
                    case 2: // q10
                        if (c == '0') state = 0;
                        else if (c == '1') state = 3;
                        break;
                    case 3: // q11
                        if (c == '0') state = 1;
                        else if (c == '1') state = 2;
                        break;
                }
            }

            return state == 3; // Принимающее состояние — q11
        }
    }

    public class FA3
    {
        public bool? Run(string s)
        {
            // Состояния:
            // q0: не встречено "11", последний символ не '1'
            // q1: последняя '1', но нет "11"
            // q2: встречено "11" (принимающее)
            int state = 0;

            foreach (char c in s)
            {
                if (c != '0' && c != '1') return null; // Некорректный символ

                switch (state)
                {
                    case 0: // q0
                        if (c == '1') state = 1;
                        break;
                    case 1: // q1
                        if (c == '0') state = 0;
                        else if (c == '1') state = 2;
                        break;
                    case 2: // q2
                        if (c == '0') state = 0;
                        else if (c == '1') state = 2;
                        break;
                }
            }

            return state == 2; // Принимающее состояние — q2
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
