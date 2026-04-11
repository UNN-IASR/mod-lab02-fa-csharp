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
        int count0 = 0;
        int count1 = 0;

        foreach (var c in s)
        {
            if (c == '0') count0++;
            else if (c == '1') count1++;
            else return null; // недопустимый символ
        }

        return count0 == 1 && count1 >= 1;
    }
}

  public class FA2
{
    public bool? Run(IEnumerable<char> s)
    {
        int count0 = 0;
        int count1 = 0;

        foreach (var c in s)
        {
            if (c == '0') count0++;
            else if (c == '1') count1++;
            else return null;
        }

        return count0 % 2 == 1 && count1 % 2 == 1;
    }
}
  
  public class FA3
{
    public bool? Run(IEnumerable<char> s)
    {
        bool prevWasOne = false;

        foreach (var c in s)
        {
            if (c != '0' && c != '1') return null;

            if (c == '1')
            {
                if (prevWasOne)
                    return true;

                prevWasOne = true;
            }
            else
            {
                prevWasOne = false;
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
