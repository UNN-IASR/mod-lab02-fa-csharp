using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class State
    {
        public string Name = ""; // Инициализация пустой строкой
        public Dictionary<char, State> Transitions = new Dictionary<char, State>(); // Инициализация пустым словарем
        public bool IsAcceptState;
    }

    /// <summary>
    /// Конечный автомат, принимающий строки с ровно одним '0'
    /// </summary>
    public class FA1
    {
        public bool? Run(string input)
        {
            // Состояния:
            // 0: не встречено '0' (начальное)
            // 1: встречен ровно один '0' (принимающее)
            // 2: встречено более одного '0' (не принимающее)
            int state = 0;

            foreach (char c in input)
            {
                // Если символ не '0' и не '1', возвращаем null
                if (c != '0' && c != '1') return null;

                switch (state)
                {
                    case 0: // Начальное состояние: нет '0'
                        if (c == '0') state = 1; // Переход при встрече первого '0'
                        break;
                    case 1: // Встречен один '0'
                        if (c == '0') state = 2; // Переход при встрече второго '0'
                        break;
                    case 2: // Более одного '0'
                        break; // Остаёмся в не принимающем состоянии
                }
            }

            // Принимаем, если закончили в состоянии 1 (ровно один '0')
            return state == 1;
        }
    }

    /// <summary>
    /// Конечный автомат, принимающий строки с нечётным количеством '0' и нечётным количеством '1'
    /// </summary>
    public class FA2
    {
        public bool? Run(string input)
        {
            // Состояния:
            // 0: чётное '0', чётное '1' (начальное)
            // 1: чётное '0', нечётное '1'
            // 2: нечётное '0', чётное '1'
            // 3: нечётное '0', нечётное '1' (принимающее)
            int state = 0;

            foreach (char c in input)
            {
                // Если символ не '0' и не '1', возвращаем null
                if (c != '0' && c != '1') return null;

                switch (state)
                {
                    case 0: // чётное '0', чётное '1'
                        if (c == '0') state = 2; // Нечётное '0'
                        else if (c == '1') state = 1; // Нечётное '1'
                        break;
                    case 1: // чётное '0', нечётное '1'
                        if (c == '0') state = 3; // Нечётное '0'
                        else if (c == '1') state = 0; // Чётное '1'
                        break;
                    case 2: // нечётное '0', чётное '1'
                        if (c == '0') state = 0; // Чётное '0'
                        else if (c == '1') state = 3; // Нечётное '1'
                        break;
                    case 3: // нечётное '0', нечётное '1'
                        if (c == '0') state = 1; // Чётное '0'
                        else if (c == '1') state = 2; // Чётное '1'
                        break;
                }
            }

            // Принимаем, если оба количества нечётные (состояние 3)
            return state == 3;
        }
    }

    /// <summary>
    /// Конечный автомат, принимающий строки с хотя бы одним "11"
    /// </summary>
    public class FA3
    {
        public bool? Run(string input)
        {
            // Состояния:
            // 0: нет "11", последний символ не '1' (начальное)
            // 1: последняя '1', но нет "11"
            // 2: встречено "11" (принимающее)
            int state = 0;

            foreach (char c in input)
            {
                // Если символ не '0' и не '1', возвращаем null
                if (c != '0' && c != '1') return null;

                switch (state)
                {
                    case 0: // Начальное состояние: нет "11"
                        if (c == '1') state = 1; // Переход при встрече '1'
                        break;
                    case 1: // Последний символ — '1'
                        if (c == '0') state = 0; // Возврат в начальное при '0'
                        else if (c == '1') state = 2; // Переход в принимающее при второй '1'
                        break;
                    case 2: // Встречено "11"
                        if (c == '0') state = 0; // Возврат в начальное при '0'
                        else if (c == '1') state = 2; // Остаёмся в принимающем при '1'
                        break;
                }
            }

            // Принимаем, если закончили в состоянии 2 (есть "11")
            return state == 2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = "01111";

            // Создаём экземпляр первого автомата и запускаем
            var fa1 = new FA1();
            bool? result1 = fa1.Run(input);
            Console.WriteLine(result1);

            // Создаём экземпляр второго автомата и запускаем
            var fa2 = new FA2();
            bool? result2 = fa2.Run(input);
            Console.WriteLine(result2);

            // Создаём экземпляр третьего автомата и запускаем
            var fa3 = new FA3();
            bool? result3 = fa3.Run(input);
            Console.WriteLine(result3);
        }
    }
}
