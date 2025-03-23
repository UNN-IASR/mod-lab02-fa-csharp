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
      int cnt0 = 0;
      int cnt1 = 0;
      foreach(var e in s) {
        if(e == '0') {
           cnt0++;
        } else {
          cnt1++;
        }
      return cnt0 == 1 && cnt1 > 0;  
    }
  }

  public class FA2
  {
    public bool? Run(IEnumerable<char> s)
    {
     int cnt0 = 0;
      int cnt1 = 0;
      foreach(var e in s) {
        if(e == '0') {
           cnt0++;
        } else {
          cnt1++;
        }
      return cnt0 % 2 && cnt1 % 2; 
    }
  }
  
  public class FA3
  {
    public bool? Run(IEnumerable<char> s)
    {
      for(int i = 1; i < s.Count(); ++i){
          if(s[i] == '1' && s[i - 1] == '1') {
            return true;
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
