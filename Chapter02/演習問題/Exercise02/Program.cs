namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            PrintInchiToMeterList(1, 10);
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
