
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            Console.WriteLine("***** 3.2.1 *****");
            Exercise2_1(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.2 *****");
            Exercise2_2(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.3 *****");
            Exercise2_3(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.4 *****");
            Exercise2_4(cities);
            Console.WriteLine();

        }

        private static void Exercise2_1(List<string> cities) {
            Console.WriteLine("都市名を入力。");
            var name = Console.ReadLine();
            do {

                var CityList = cities.FindIndex(s => s == name);
                Console.WriteLine(CityList);

                name = Console.ReadLine();
            } while (!string.IsNullOrEmpty(name));


        }

        private static void Exercise2_2(List<string> cities) {
            Console.WriteLine("小文字の”o”が含まれている都市数。");
            Console.WriteLine(cities.Count(s => s.Contains('o')));
        }

        private static void Exercise2_3(List<string> cities) {
            Console.WriteLine("小文字の”o”が含まれている都市名。");
            var cityname = cities.Where(s => s.Contains('o')).ToArray();
            foreach(var s in cityname) {
                Console.WriteLine(s);
            }
        }

        private static void Exercise2_4(List<string> cities) {
            Console.WriteLine("頭文字の”B”の都市の文字数。");
            var cityName = cities.Where(s => s.StartsWith('B'))
                .Select(s => new { s,s.Length}).ToArray();
            foreach(var data in cityName) {
                Console.WriteLine(data.s + "：" + data.Length + "文字");
            }
        }
    }
}
