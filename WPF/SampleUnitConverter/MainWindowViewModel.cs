using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter {
    internal class MainWindowViewModel : ViewModel{

        //フィールド
        private double metricValue;
        private double imperialValue;

        //▲で呼ばれるコマンド
        public ICommand ImperialUnitToMetric { get; private set; }
        //▼で呼ばれるコマンド
        public ICommand MetricToImperialUnit { get; private set; }

        //上のCommboBoxで選択されている値
        public MetricUnit CurrentMetricUnit { get; set; }
        //下のCommboBoxで選択されている値
        public ImperialUnit CurrentImperialUnit { get; set; }

        //プロパティ
        public double MetricValue {
            get => metricValue;
            set {
                this.metricValue = value;
                this.OnPropertyChanged();

            }
        }

        public double ImperiaValue {
            get => imperialValue;
            set {
                this.imperialValue = value;
                this.OnPropertyChanged();
            }
        }

        public MainWindowViewModel() {
            CurrentMetricUnit = MetricUnit.Units.First();
            CurrentImperialUnit = ImperialUnit.Units.First();



            ImperialUnitToMetric = new DelegateCommand(
                () => MetricValue = CurrentMetricUnit.FromImperialUnit(
                    CurrentImperialUnit, ImperiaValue));

            MetricToImperialUnit = new DelegateCommand(
                () => ImperiaValue = CurrentImperialUnit.FromMetricUnit(
                    CurrentMetricUnit, MetricValue));

        }
    }
}
