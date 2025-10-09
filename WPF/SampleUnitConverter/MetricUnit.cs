using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    internal class MetricUnit : DistanceUnit{
        private static List<MetricUnit> units = new List<MetricUnit> {
            new MetricUnit{Name = "mm", Coeffcient = 1,},
            new MetricUnit{Name = "cm", Coeffcient = 10,},
            new MetricUnit{Name = "m", Coeffcient = 10 * 100,},
            new MetricUnit{Name = "km", Coeffcient = 10 * 100 * 1000,},
        };
        public static ICollection<MetricUnit> Units { get => units; }


        /// <summary>
        /// ヤード単位からメートル単位に変換します
        /// </summary>
        /// <param name="unit">変換元の単位</param>
        /// <param name="value">変換する値</param>
        /// <returns>変換した値</returns>

        public double FromImperialUnit(ImperialUnit unit, double value) {
            return (value * unit.Coeffcient) * 25.4 / Coeffcient;
        }
    }
}
