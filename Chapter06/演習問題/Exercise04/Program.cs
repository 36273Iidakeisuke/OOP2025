using System.Runtime.CompilerServices;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";

            var array = line.Split(';');

            for (int i = 0; i < array.Length; i++) {
                var words = array[i].Split('=');
                Console.WriteLine(ToJapanese(words[0]) + "：" + words[1]);
            }
        }



        /// <summary>
        /// 引数の単語を日本語へ変換します
        /// </summary>
        /// <param name="key">"Novelist","BestWork","Born"</param>
        /// <returns>"「作家」,「代表作」,「誕生年」</returns>
        static string ToJapanese(string key) {
            switch (key) {
                case "Novelist":
                    return "作家";
                case "BestWork":
                    return "代表作";
                case "Born":
                    return "誕生年";
            }
            return ""; //エラーをなくすためのダミー
        }
    }
}