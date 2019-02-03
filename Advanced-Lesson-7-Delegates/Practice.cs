using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_7_Delegates
{
    public class Practice
    {
        /// <summary>
        /// L7.P1. Переписать консольный калькулятор с использованием делегатов. 
        /// Используйте switch/case, чтоб определить какую математическую функцию.
        /// </summary>
        public static void L7P1_Calculator()
        {
            int num1 = 100, num2 = 200;
            Func<int, int, double> op = null;
            bool cycle = true;

            while(cycle)
            {
                switch (Console.ReadLine())
                {
                    case "+":
                        //op = Sum;
                        //Console.WriteLine(op(num1, num2));
                        op = (var1, var2) => var1 + var2;

                        Console.WriteLine(op(num1, num2));
                        break;

                    case "-":
                        op = Sub;
                        Console.WriteLine(op(num1, num2));
                        break;

                    case "q":
                        cycle = false;
                        break;
                }
            }
        }

        public static double Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        public static double Sub(int num1, int num2)
        {
            return num1 - num2;
        }
        /// <summary>
        /// L7.P2. Создать расширяющий метод для коллекции строк.
        /// Метод должен принимать делегат форматирующей функции для строки.
        /// Метод должен проходить по всем элементам коллекции и применять данную форматирующую функцию к каждому элементу.
        /// Реализовать следующие форматирующие функции:
        /// Перевод строки в заглавные буквы.
        /// Замена пробелов на подчеркивание.
        /// Продемонстрировать работу расширяющего метода.
        /// </summary>
        /// 
        public static void L7P2_StringFormater()
        {
            List<string> strList = new List<string>
            {
                "qwert qwe qwe",
                "1W_sglj osogb5_=",
                "2dfgd=afja fh+eg1 3sgkфар"
            };

            strList.FormatStringList(ToUpper);
            PrintList(strList);

            strList.FormatStringList(ToLower);
            PrintList(strList);

            strList.FormatStringList(Replace);
            PrintList(strList);
        }

        public static void PrintList(List<string> tmpList)
        {
            foreach (var item in tmpList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        public static string ToUpper(string str)
        {
            return str.ToUpper();
        }

        public static string ToLower(string str)
        {
            return str.ToLower();
        }

        public static string Replace(string str)
        {
            return str.Replace(' ', '_');
        }
    }

    public static class ListStringExtension
    {
        public static List<string> FormatStringList(this List<string> str, Func<string, string> tmpDelegate)
        {
            for (int i = 0; i < str.Count; i++)
            {
                str[i] = tmpDelegate(str[i]);
            }
            return str;
        }
    }
}
