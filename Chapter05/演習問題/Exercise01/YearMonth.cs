using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    public class YearMonth {
        public readonly int Year;
        public readonly int Month;
        public bool Is21Century => 2000 < Year && Year <= 2100;

        public YearMonth(int year, int month) {
            Year = year;
            Month = month;
        }
        public YearMonth AddOneMonth() {
            YearMonth rtn;
            if (Month == 12) {
                rtn = new YearMonth(Year + 1, 1);
            } else {
                rtn = new YearMonth(Year, Month + 1);
            }
            return rtn;
        }

        public override string ToString() => $"{Year}年{Month}月";
    }
}
