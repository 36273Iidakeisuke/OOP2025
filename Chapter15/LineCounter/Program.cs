using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {
            string fileName = string.Empty;
            Console.Write("ファイルを入力 : ");
            fileName = Console.ReadLine() ?? string.Empty;
            if (!File.Exists(fileName)) {
                Console.WriteLine("存在してねぇよ");
                return;
            }
            Console.Write("検索用語 : ");
            TextProcessor.Run<LineCounterProcessor>(fileName);
        }
    }
}
