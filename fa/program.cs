using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans;

class Program
{
  static void Main(string[] args)
  {
    String str = "0111";
    FA1 fa1 = new FA1();
    bool? res = fa1.Run(str);
    Console.WriteLine(res.ToString());
  }
}