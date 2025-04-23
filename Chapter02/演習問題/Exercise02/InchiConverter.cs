using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02
{
    public static class InchiConverter {

        //定数
        private const double ratio = 0.0254;

        //インチからメートルを求める
        public static double ToMeter(double inchi) {
            return inchi * ratio;
        }

        //メートルからフィールドを求める
        public static double FromMeter(double meter) {
            return meter / ratio;
        }

    }
}