using fans;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FA1 fA1 = new FA1();
            String s1 = "01111";
            var result = fA1.Run(s1);
            Console.WriteLine(result == true);
        }
    }
}
