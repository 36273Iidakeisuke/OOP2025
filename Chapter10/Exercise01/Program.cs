using System.Text.RegularExpressions;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var filePath = "source.txt";
            if (File.Exists(filePath)) {
                using var reader = new StreamReader(filePath);
                int cnt = 0;
                while (!reader.EndOfStream) {
                    var line = reader.ReadLine() ?? string.Empty;
                    //if (Regex.IsMatch(line, @"\sclass\s")) {
                    //    cnt++;
                    //}
                    string[] words = line.Split(' ');
                    var word = words.Where(s => s.Contains("class"));
                    if (word.Count() > 0) {
                        cnt++;
                    }
                }

                Console.WriteLine(cnt);
            }
        }
    }
}
