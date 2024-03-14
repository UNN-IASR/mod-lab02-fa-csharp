using System;
using System.Collections.Generic;
using Stateless;

namespace fans {
    public enum State {
        Q0, Q1, Q2, Q3
    }

    public class FA {
        protected readonly StateMachine<State, char> stateMachine;
        protected bool accept;
        public FA() {
            stateMachine = new StateMachine<State, char>(State.Q0);
        }
        public bool? Run(IEnumerable<char> s) {
            foreach (char c in s) {
                if (!stateMachine.CanFire(c)) return null;
                stateMachine.Fire(c);
            }
            return accept;
        }
    }

    public class FA1 : FA {
        public FA1() : base() {
            stateMachine.Configure(State.Q0)
                .OnEntry(() => accept = false)
                .Permit('0', State.Q1)
                .Ignore('1');
            stateMachine.Configure(State.Q1)
                .OnEntry(() => accept = true)
                .Permit('0', State.Q2)
                .Ignore('1');
            stateMachine.Configure(State.Q2)
                .OnEntry(() => accept = false)
                .Ignore('0')
                .Ignore('1'); 
        }
    }

    public class FA2 : FA {
        public FA2() : base() {
            stateMachine.Configure(State.Q0)
                .OnEntry(() => accept = false)
                .Permit('0', State.Q1)
                .Permit('1', State.Q2);
            stateMachine.Configure(State.Q1)
                .OnEntry(() => accept = false)
                .Permit('0', State.Q0)
                .Permit('1', State.Q3);
            stateMachine.Configure(State.Q2)
                .OnEntry(() => accept = false)
                .Permit('0', State.Q3)
                .Permit('1', State.Q0);
            stateMachine.Configure(State.Q3)
                .OnEntry(() => accept = true)
                .Permit('0', State.Q2)
                .Permit('1', State.Q1);
        }
    }

    public class FA3 : FA {
        public FA3() : base() {
            stateMachine.Configure(State.Q0)
                .OnEntry(() => accept = false)
                .Ignore('0')
                .Permit('1', State.Q1);
            stateMachine.Configure(State.Q1)
                .OnEntry(() => accept = false)
                .Permit('0', State.Q0)
                .Permit('1', State.Q2);
            stateMachine.Configure(State.Q2)
                .OnEntry(() => accept = true)
                .Ignore('0')
                .Ignore('1');
        }
    }

    class Program {
        static void Main(string[] args) {
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