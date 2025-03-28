using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans {
  public class State {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;
  }
  
  public class FA1 {
        public static State st = new State() {
            Name = "start",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State a = new State() {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State() {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State su = new State() {
            Name = "success",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public static State f = new State() {
            Name = "fail",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = st;

        public FA1() {
            st.Transitions['0'] = a;
            st.Transitions['1'] = b;
            a.Transitions['0'] = f;
            a.Transitions['1'] = su;
            b.Transitions['0'] = su;
            b.Transitions['1'] = b;
            su.Transitions['0'] = f;
            su.Transitions['1'] = su;
            f.Transitions['0'] = f;
            f.Transitions['1'] = f;
        }

        public bool? Run(IEnumerable<char> s) {
            State current = InitialState;
            foreach (var c in s) {
                current = current.Transitions[c];
                if (current == null) return null;
            }
            return current.IsAcceptState;
        }
    }

  public class FA2 {
        public static State st = new State() {
            Name = "start",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State a = new State() {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State() {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State su = new State() {
            Name = "success",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = st;

        public FA2() {
            st.Transitions['0'] = b;
            st.Transitions['1'] = a;
            a.Transitions['0'] = su;
            a.Transitions['1'] = st;
            b.Transitions['0'] = st;
            b.Transitions['1'] = su;
            su.Transitions['0'] = a;
            su.Transitions['1'] = b;
        }
    
        public bool? Run(IEnumerable<char> s) {
            State current = InitialState;
            foreach (var c in s) {
                current = current.Transitions[c];
                if (current == null) return null;
            }
            return current.IsAcceptState;         
        }
    }
  
  public class FA3 {
        public static State st = new State() {
            Name = "start",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State a = new State() {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State su = new State() {
            Name = "success",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = st;

        public FA3() {
            st.Transitions['0'] = st;
            st.Transitions['1'] = a;
            a.Transitions['0'] = st;
            a.Transitions['1'] = su;
            su.Transitions['0'] = su;
            su.Transitions['1'] = su;
        }

        public bool? Run(IEnumerable<char> s) {
            State current = InitialState;
            foreach (var c in s) {
                current = current.Transitions[c];
                if (current == null) return null;
            }
            return current.IsAcceptState;
        }
  }

  class Program {
    static void Main(string[] args) {
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
