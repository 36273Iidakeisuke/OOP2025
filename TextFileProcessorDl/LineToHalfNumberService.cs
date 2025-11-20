using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessorDI;
using static System.Net.Mime.MediaTypeNames;

namespace TextFileProcessorDl {
    //362 問題15.1
    public class LineToHalfNumberService : ITextFileService {
        private int _count;
        public void Initialize(string fname) {
            _count = 0;
        }

        public void Execute(string line) {

            //
            string result = new string(
                    line.Select(c => ('０' <= c && c <= '９') ? (char)(c - '０' + '0') : c).ToArray()
                );
            Console.WriteLine(result);
            //_count++;
            //string normalized = line.Normalize(NormalizationForm.FormKD);
            //Console.WriteLine(normalized);
        }

        public void Terminate() {

        }
    }
}
