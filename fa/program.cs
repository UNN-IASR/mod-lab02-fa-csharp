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
        public static State a = new State() //��������� ���������(��� 0, ��� 1)
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State() //���� ���� 0, ��� 1
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State() //��� 0 � ������ (�������)
        {
            Name = "c",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State d = new State() //���� 1, ��� 0
        {
            Name = "d",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State e = new State() //���� 0, ���� 1 (�����������)
        {
            Name = "e",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;
        public FA1()
        {
            a.Transitions['0'] = b;
            a.Transitions['1'] = d;

            b.Transitions['0'] = c;
            b.Transitions['1'] = e;

            c.Transitions['0'] = c;
            c.Transitions['1'] = c;

            d.Transitions['0'] = e;
            d.Transitions['1'] = d;

            e.Transitions['0'] = c;
            e.Transitions['1'] = e;
        }
        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c]; 
                if (current == null)              
                    return null;
            }
            return current.IsAcceptState;
        }
    }

  public class FA2
  {
        public static State a = new State() //������ ���-�� 0, ������ ���-�� 1
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State() //��� 0, ����� 1
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State() //����� 0, ��� 1
        {
            Name = "c",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State d = new State() //����� 0, ����� 1 (�����������)
        {
            Name = "d",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;
        public FA2()
        {
            
            a.Transitions['0'] = c;
            a.Transitions['1'] = b;

            b.Transitions['0'] = d;
            b.Transitions['1'] = a;

            c.Transitions['0'] = a;
            c.Transitions['1'] = d;

            d.Transitions['0'] = b;
            d.Transitions['1'] = c;
        }
        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }
  
  public class FA3
  {
        public static State a = new State() //��������� 0, ��� 1
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State() //��������� ���� 1
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State() //��������� 11 (�����������)
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        State InitialState = a;
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
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
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