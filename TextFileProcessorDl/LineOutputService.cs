using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    internal class LineOutputService : ITextFileService{
        private int _count;
        public virtual void Initialize(string fname) {
            _count = 0;
        }
        public virtual void Execute(string line) {
            _count++;
            if (_count <= 20) {
                Console.WriteLine($"{_count,2}　|　{line}");
            }
        }
        public virtual void Terminate() {
            
        }
    }
}
