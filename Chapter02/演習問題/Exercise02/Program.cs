namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("１：インチからメートル");
            Console.WriteLine("２：メートルからインチ");
            Console.Write("入力：");
            int n = int.Parse(Console.ReadLine());


            Console.Write("はじめ：");
            int start = int.Parse(Console.ReadLine());

            Console.Write("おわり：");
            int end = int.Parse(Console.ReadLine());

            if (n == 1) {
                PrintInchiToMeterList(start, end);
            } else {
                PrintMeterToInchiList(start, end);
            }


        }


        // インチからメートルへの対応表を出力
        static void PrintInchiToMeterList(int start, int end) {
            for (int inchi = start; inchi <= end; inchi++) {
                double meter = InchiConverter.ToMeter(inchi);
                Console.WriteLine($"{inchi}inchi = {meter:0.0000}m");
            }
        }

        // メートルからインチへの対応表を出力
        static void PrintMeterToInchiList(int start, int end) {
            for (int meter = start; meter <= end; meter++) {
                double inchi = InchiConverter.FromMeter(meter);
                Console.WriteLine($"{meter}m = {inchi:0.0000}inchi");
            }
        }


    }
}
