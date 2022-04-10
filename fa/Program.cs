using System;
using fa.Code;

namespace fans
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string str = "01111";
            Run(new FA1(), str);
            Run(new FA2(), str);
            Run(new FA3(), str);
        }

        private static void Run(Fa fa, string str) => 
            Console.WriteLine(fa.Run(str));
    }
}