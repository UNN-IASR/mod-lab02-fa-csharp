using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
	public class State
	{
		public readonly string Name;
		public readonly bool IsAcceptState = false;
		public Dictionary<char, State> Transitions = new Dictionary<char, State>();
		
		public State (string name, bool isAcceptState = false)
		{
			Name = name;
			IsAcceptState = isAcceptState;
		}
	}


	public class FA1
	{
		public State no0_no1 = new State("no0_no1");
		public State no0_has1 = new State("no0_has1");
		public State one0_no1 = new State("one0_no1");
		public State one0_has1 = new State("one0_has1", true);
		public State many0_no1 = new State("many0_no1");
		public State many0_has1 = new State("many0_has1");

		State InitialState = no0_no1;

		public FA1()
		{
			no0_no1.Transitions['0'] = one0_no1;
			no0_no1.Transitions['1'] = no0_has1;

			no0_has1.Transitions['0'] = one0_has1;
			no0_has1.Transitions['1'] = no0_has1;

			one0_no1.Transitions['0'] = many0_no1;
			one0_no1.Transitions['1'] = one0_has1;

			one0_has1.Transitions['0'] = many0_has1;
			one0_has1.Transitions['1'] = one0_has1;

			many0_no1.Transitions['0'] = many0_no1;
			many0_no1.Transitions['1'] = many0_has1;

			many0_has1.Transitions['0'] = many0_has1;
			many0_has1.Transitions['1'] = many0_has1;
		}

		public bool? Run(IEnumerable<char> s)
		{
			State current = InitialState;
			foreach (var c in s)
			{
				current = current.Transitions[c];
				if (current == null) return null;
			}
			return current.IsAcceptState;
		}
	}

	public class FA2
	{
		public State even0_even1 = new State("even0_even1");
		public State even0_odd1 = new State("even0_odd1");
		public State odd0_even1 = new State("odd0_even1");
		public State odd0_odd1 = new State("odd0_odd1", true);

		State InitialState = even0_even1;

		public FA2()
		{
			even0_even1.Transitions['0'] = odd0_even1;
			even0_even1.Transitions['1'] = even0_odd1;

			even0_odd1.Transitions['0'] = odd0_odd1;
			even0_odd1.Transitions['1'] = even0_even1;

			odd0_even1.Transitions['0'] = even0_even1;
			odd0_even1.Transitions['1'] = odd0_odd1;

			odd0_odd1.Transitions['0'] = even0_odd1;
			odd0_odd1.Transitions['1'] = odd0_even1;
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
		public State no1 = new State("no1");
		public State one1 = new State("one1");
		public State has11 = new State("has11", true);

		State InitialState = no1;

		public FA3()
		{
			no1.Transitions['0'] = no1;
			no1.Transitions['1'] = one1;

			one1.Transitions['0'] = no1;
			one1.Transitions['1'] = has11;

			has11.Transitions['0'] = has11;
			has11.Transitions['1'] = has11;
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