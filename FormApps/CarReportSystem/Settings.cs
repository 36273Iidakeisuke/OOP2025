using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    public class Settings {
        //設定した色情報を格納

        private static Settings instance;

        public int MainFormBackColor { get; set; } //自分自身のインスタンスを格納

        //コンストラクタ（privateにすることによりnewできなくなる）
        private Settings() {
        }
        public static Settings getInstance() {
            if (instance == null) {
                instance = new Settings();
            }
            return instance;
        }
    }
}
