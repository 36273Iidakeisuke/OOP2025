﻿
using System.Text;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz00000";

            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

            Console.WriteLine("6.3.99");
            Exercise6(text);

        }


        private static void Exercise1(string text) {
            var spaces = text.Count(c => c == ' ');
            //var spaces = text.Count(char.IsWhiteSpace);//別解
            Console.WriteLine("空白数:{0}", spaces);
        }

        private static void Exercise2(string text) {
            var replaced = text.Replace("big", "small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3(string text) {
            var words = text.Split(' ');
            var sb = new StringBuilder();

            foreach (var item in words) {
                sb.Append(item);
                sb.Append(' ');
            }

            var trimwords = sb.ToString().TrimEnd();
            trimwords += '.';
            Console.WriteLine(trimwords);
        }

        private static void Exercise4(string text) {
            var count = text.Split(' ').Length;
            Console.WriteLine("単語数:{0}", count);
        }

        private static void Exercise5(string text) {
            var words = text.Split(' ').Where(s => s.Length <= 4);

            foreach (var word in words)
                Console.WriteLine(word);
        }

        private static void Exercise6(string text) {
            for (char ch = 'a'; ch <= 'z'; ch++) {
                Console.WriteLine(ch + "：" + text.Count(s => s == ch));
            }
        }

    }
}
