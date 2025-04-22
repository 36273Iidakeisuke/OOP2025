namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            Console.Write("はじめ：");
            int start = int.Parse(Console.ReadLine());

            Console.Write("おわり：");
            int end = int.Parse(Console.ReadLine());

            PrintInchiToMeterList(start, end);
        }

        // インチからメートルへの対応表を出力
        static void PrintInchiToMeterList(int start, int end) {
            for (int inchi = start; inchi <= end; inchi++) {
                double meter = InchiConverter.ToMeter(inchi);
                Console.WriteLine($"{inchi}inchi = {meter:0.0000}m");
            }
        }

    }
}
