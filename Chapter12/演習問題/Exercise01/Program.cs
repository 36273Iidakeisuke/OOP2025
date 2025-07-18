using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json.Serialization;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            //問題12.1.1
            var emp = new Employee {
                Id = 123,
                Name = "山田太郎",
                HireDate = new DateTime(2018, 10, 1),
            };
            var jsonString = Serialize<Employee>(emp);
            Console.WriteLine(jsonString);
            var obj = Deserialize<Employee>(jsonString);
            Console.WriteLine(obj);

            //問題12.1.2
            Employee[] employees = [
                new () {
                    Id = 123,
                    Name = "山田太郎",
                    HireDate = new DateTime(2018, 10, 1),
                },
                new () {
                    Id = 198,
                    Name = "田中華子",
                    HireDate = new DateTime(2020, 4, 1),
                },
            ];
            Serialize("employees.json", employees);

            //問題12.1.3
            var empdata = Deserialize_f("employees.json");
            if (empdata is not null) {
                foreach (var empd in empdata)
                    Console.WriteLine(empd);
            }

        }
        //問題12.1.1
        static string Serialize<T>(T emp) {
            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            string jsonString = JsonSerializer.Serialize(emp, options);
            return jsonString;
        }

        static T? Deserialize<T>(string text) {
            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            var novel = JsonSerializer.Deserialize<T>(text, options);
            return novel;
        }


        //問題12.1.2
        //シリアル化してファイルへ出力する
        static void Serialize(string filePath, IEnumerable<Employee> employees) {
            var options = new JsonSerializerOptions {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(employees, options);
            File.WriteAllText(filePath, jsonString);
        }

        //問題12.1.3
        //シリアル化してファイルへ出力する
        static Employee[]? Deserialize_f(string filePath) {
            string text = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            var novel = JsonSerializer.Deserialize<Employee[]>(text, options);
            return novel;
        }


    }

    public record Employee {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("birth")]
        public DateTime HireDate { get; set; }
    }
}
