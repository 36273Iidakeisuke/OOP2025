
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();

            Exercise2(text);



        }

        private static void Exercise1(string text) {
            var dictionary = new Dictionary<char, int>();
            var work = text.ToUpper();
            foreach (var c in work) {
                if ('A' <= c && c <= 'Z') {
                    if (dictionary.ContainsKey(c)) {
                        dictionary[c] ++;
                    } else {
                        dictionary[c] = 1;
                    }
                }
            }
            
            foreach (var item in dictionary.OrderBy(p => p.Key)) {
                Console.WriteLine(item.Key + "：" +item.Value);
            }

        }

        private static void Exercise2(string text) {

        }
    }
}
