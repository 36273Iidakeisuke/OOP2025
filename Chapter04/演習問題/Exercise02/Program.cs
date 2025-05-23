using System;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            Exercise1();
            Console.WriteLine("---");
            Exercise2();
            Console.WriteLine("---");
            Exercise3();

        }

        private static void Exercise1() {
            var value = Console.ReadLine();
            if (int.TryParse(value, out var num)) {
                if (500 <= num) {
                    Console.WriteLine(num);
                } else if (100 <= num) {
                    Console.WriteLine("値を3倍にした数を出力：" + num * 3);
                } else if (0 <= num) {
                    Console.WriteLine("値を２倍にした数を出力：" + num * 2);
                } else if (num < 0) {
                    Console.WriteLine(num);
                } else {
                    Console.WriteLine("この入力には誤りがあります。。。");
                }
            }
        }

        private static void Exercise2() {
            var value = Console.ReadLine();
            if (int.TryParse(value, out var num)) {
                switch (num) {
                    case < 0:
                        Console.WriteLine(num);
                        break;
                    case < 100:
                        Console.WriteLine(num * 2);
                        break;
                    case < 500:
                        Console.WriteLine(num * 3);
                        break;
                    default:
                        Console.WriteLine("この入力には誤りがあります。。。");
                        break;
                }
            }

        }

        private static void Exercise3() {
            var value = Console.ReadLine();
            if (int.TryParse(value, out var num)) {
                var text = num switch {
                    < 0 => num,
                    < 100 => num * 2,
                    < 500 => num * 3,
                    _ => num
                };
                Console.WriteLine(text);
            } else {
                Console.WriteLine("この入力には誤りがあります。。。");
            }
        }
    }
}
