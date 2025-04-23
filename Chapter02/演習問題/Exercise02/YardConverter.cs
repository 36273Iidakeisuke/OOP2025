using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02
{
    public static class YardConverter {

        //定数
        private const double ratio = 0.9144;

        //インチからメートルを求める
        public static double ToMeter(double meter) {
            return meter * ratio;
        }

        //メートルからフィールドを求める
        public static double FromMeter(double yard) {
            return yard / ratio;
        }

    }
}
