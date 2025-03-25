using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
        string _name;
        bool _isAcceptState;
        public Dictionary<char, State> Transitions;

        public bool IsAcceptState {  get { return _isAcceptState; } }

        public State(string Name, bool IsAcceptState)
        {
            this._name = Name;
            Transitions = new Dictionary<char, State>();
            this._isAcceptState = IsAcceptState;
        }
  }


  public class FA1
  {
        static State q0 = new State("q0", false); //��������� ���������
        static State q1 = new State("q1", false); //��������� ���� �� ���� 1, 0 ��� �� ���������
        static State q2 = new State("q2", false); //��������� ����� ���� 0, �� 1 ��� �� ���������
        static State q3 = new State("q3", true);  //�������� ����� ���� 0 � ���� �� 1 ��������
        static State q4 = new State("q4", false); //��������� ����� ������ 0
        State InitialState = q0;

        public FA1()
        {
            q0.Transitions['0'] = q2;
            q0.Transitions['1'] = q1;

            q1.Transitions['0'] = q3;
            q1.Transitions['1'] = q1;

            q2.Transitions['0'] = q4;
            q2.Transitions['1'] = q3;

            q3.Transitions['0'] = q4;
            q3.Transitions['1'] = q3;

            q4.Transitions['0'] = q4;
            q4.Transitions['1'] = q4;
        }
        
        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s) // ���� �� ���� �������� 
            {
                current = current.Transitions[c]; // ������ ��������� �� ��, � ������� � ��� �������
                if (current == null)              // ���� ��� ���, ���������� ������� ������
                    return null;
                // ����� ��������� � ����������
            }
            return current.IsAcceptState;
        }
  }

  public class FA2
  {
        static State q1 = new State("q1", false); // ��� ������
        static State q2 = new State("q2", false); //������ 0 � �������� 1
        static State q3 = new State("q3", false); //�������� 0 � ������ 1
        static State q4 = new State("q4", true); //��� ��������
        State InitialState = q1;

        public FA2()
        {
            q1.Transitions['0'] = q3;
            q1.Transitions['1'] = q2;

            q2.Transitions['0'] = q4;
            q2.Transitions['1'] = q1;

            q3.Transitions['0'] = q1;
            q3.Transitions['1'] = q4;

            q4.Transitions['0'] = q2;
            q4.Transitions['1'] = q3;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s) // ���� �� ���� �������� 
            {
                current = current.Transitions[c]; // ������ ��������� �� ��, � ������� � ��� �������
                if (current == null)              // ���� ��� ���, ���������� ������� ������
                    return null;
                // ����� ��������� � ����������
            }
            return current.IsAcceptState;
        }
    }
  
  public class FA3
  {
        static State q1 = new State("q1", false); // ���� 1
        static State q2 = new State("q2", false); //����� 1
        static State q3 = new State("q3", true); //����� ��� 1 ������

        State InitialState = q1;

        public FA3()
        {
            q1.Transitions['0'] = q1;
            q1.Transitions['1'] = q2;

            q2.Transitions['0'] = q1;
            q2.Transitions['1'] = q3;

            q3.Transitions['0'] = q3;
            q3.Transitions['1'] = q3;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s) // ���� �� ���� �������� 
            {
                current = current.Transitions[c]; // ������ ��������� �� ��, � ������� � ��� �������
                if (current == null)              // ���� ��� ���, ���������� ������� ������
                    return null;
                // ����� ��������� � ����������
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