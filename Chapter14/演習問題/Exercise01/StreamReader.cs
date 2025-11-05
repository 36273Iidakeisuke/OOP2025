using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    public class Reader {
        public async Task DoLongTimeWorkAsync( StreamReader Readers) {
            String? result;
            while ((result = await Readers.ReadLineAsync()) != null) {
                Console.WriteLine($"{result}");
            }
        }
    }
}
