
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            List<string> langs = [
            "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
            "JavaScript", "Swift", "Go",
            ];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);



        }

        private static void Exercise1(List<string> langs) {
            Console.WriteLine("Sが含まれるもの：");
            foreach (var s in langs) {
                if (s.Contains('S'))
                    Console.WriteLine(s);
            }
            Console.WriteLine("Sが含まれるもの：");
            for (int i = 0; i < langs.Count; i++) {
                if (langs[i].Contains('S')) {
                    Console.WriteLine(langs[i]);
                }
            }
            Console.WriteLine("Sが含まれるもの：");

            int n = 0;
            while (n < langs.Count) {
                if (langs[n].Contains('S')) {
                    Console.WriteLine(langs[n]);
                }
                n++;
            }
        }

        private static void Exercise2(List<string> langs) {
            var index = langs.Where(s => s.Contains('S'));
            foreach(var s in index) {
                Console.WriteLine(s);
            }
        }

        private static void Exercise3(List<string> langs) {
            var lang = langs.Find(s => s.Length == 10)?? "unknown";
            Console.WriteLine(lang);
        }
    }
}
