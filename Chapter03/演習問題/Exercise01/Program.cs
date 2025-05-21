
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };


            // 3.1.1
            Exercise1(numbers);
            Console.WriteLine("-----");

            // 3.1.2
            Exercise2(numbers);
            Console.WriteLine("-----");

            // 3.1.3
            Exercise3(numbers);
            Console.WriteLine("-----");

            // 3.1.4
            Exercise4(numbers);
        }

        private static void Exercise1(List<int> numbers) {
            Console.WriteLine("8か9で割り切れるかどうか");
            Console.WriteLine (numbers.Exists(n => n % 8 == 0 || n % 9 == 0) ? "真" : "偽");
        }

        private static void Exercise2(List<int> numbers) {
            Console.WriteLine("各要素を2.0で割った値");
            numbers.ForEach(n => Console.WriteLine(n / 2.0));

        }

        private static void Exercise3(List<int> numbers) {
            Console.WriteLine("値が50以上の要素");
            numbers.Where(n => 50 <= n).ToList().ForEach(Console.WriteLine);
        }

        private static void Exercise4(List<int> numbers) {
            Console.WriteLine("値を2倍にして要素に格納し、その要素を出力");
            numbers.Select(n => n * 2).ToList().ForEach(Console.WriteLine);
            
        }
    }
}
