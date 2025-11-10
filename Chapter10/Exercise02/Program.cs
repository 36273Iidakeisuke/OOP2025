namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var filePath = "source.txt";
            var line = File.ReadLines(filePath)
                .Select((s, ix) => $"{ix + 1,4}: {s}");
            foreach (var item in line) {
                Console.WriteLine(item);
            }


        }
    }
}
