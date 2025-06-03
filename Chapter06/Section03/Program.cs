using System.Text;

namespace Section03 {
    internal class Program {
        static void Main(string[] args) {
            //var languages = new[] { "C#", "Java", "Python", "Ruby", };
            //var separator = ", ";
            //var result = String.Join(separator, languages);
            //Console.WriteLine(result);

            var sb = new StringBuilder();
            foreach (var word in GetWords()) {
                sb.Append(word);
            }
            var text = sb.ToString();
            Console.WriteLine(text);

            String str = "";
            foreach (var words in GetWords()) {
                str += words;
            }

            Console.WriteLine(str);

        }

        private static IEnumerable<object> GetWords() {
            return ["Orange", "Lemon", "Strawberry"];
        }
    }
}
