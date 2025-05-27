namespace LinqSample {
    internal class Program {
        static void Main(string[] args) {


            var numbers = Enumerable.Range(1, 100);

            ////合計値を出力
            //Console.WriteLine(numbers.Sum());
            ////平均値を出力
            //Console.WriteLine(numbers.Average());
            ////偶数の合計値
            //Console.WriteLine(numbers.Where(s => s % 2 == 0).Sum());

            //8の倍数の合計値
            Console.WriteLine("8の倍数の合計値：" + numbers.Where(s => s % 8 == 0).Sum());


            //foreach (var num in numbers) {
            //    Console.WriteLine();
            //}
        }
    }
}
