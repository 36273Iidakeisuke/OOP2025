namespace Exercise03 {
    internal class Program {
        static
            void
            Main
            (string[] args) 
            {
            var filePath = "source1.txt";
            var filePath2 = "source2.txt";
            var newFilePath = "newSource.txt";
            var line = File.ReadLines(filePath);
            var line2 = File.ReadLines(filePath2);
            var line3 = new List<string>();
            line3.AddRange(line);
            line3.AddRange(line2);

            File.WriteAllLines(newFilePath,line3);
        }
    }
}
