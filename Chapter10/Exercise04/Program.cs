namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var files = getAllFiles("C:\\Users\\infosys\\source\\repos\\OOP2025");

            var fFiles = files.Select(s=>new FileInfo(s)).Where(fi => fi.Length >= 1048576);

            foreach (var file in fFiles) {
                Console.WriteLine($"{file.Length/1048576, 5} MB : {Path.GetFileName(file.Name)}");
            }
        }


        public static List<string> getAllFiles(string path) {
            var work = new List<string>();
            if (Directory.Exists(path)) {
                var files = Directory.GetFiles(path);
                var dirs = Directory.GetDirectories(path);
                work.AddRange(files);

                foreach (var file in dirs) {
                    var t = getAllFiles(file);
                    work.AddRange(t);
                }
            } else if (File.Exists(path)) {
                work.Add(path);
            }
            return work;

        }
    }
}
