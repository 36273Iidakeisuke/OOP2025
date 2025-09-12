using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = GetColorList();

        }
        /// <summary>
        /// すべての色を取得するメソッド
        /// </summary>
        /// <returns></returns>
        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }


        //すべてのスライダーから呼ばれるイベントパンドラ
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            colorArea.Background = new SolidColorBrush(Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value));
        }

        //色の登録
        private void Stock_Click(object sender, RoutedEventArgs e) {
            byte r = (byte)rSlider.Value;
            byte b = (byte)bSlider.Value;
            byte g = (byte)gSlider.Value;

            Color color = Color.FromRgb(r, g, b);
            MyColor[] tempColors = GetColorList();

            string record = "";

            foreach (MyColor c in tempColors) {
                if (color == c.Color) {
                    record = c.Name;
                    break;
                }
            }

            if (string.IsNullOrEmpty(record)) {
                record = $"R:{r} G:{g} B:{b}";
            }


            if (Record.Items.Contains(record)) {
            } else {
                //未登録なら登録【登録済みなら何もしない】
                Record.Items.Add(record);
            }
        }
        //コンボボックス色の選択
        private void colorSelectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var comboSelectMyColor = (MyColor)((ComboBox)sender).SelectedItem;
            setSliderValue(comboSelectMyColor.Color); //スライダー設定
        }

        //各スライダーの値を設定する
        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            bSlider.Value = color.B;
            gSlider.Value = color.G;
        }

        //ListBoxの色を呼び出し  
        private void Record_Selected(object sender, SelectionChangedEventArgs e) {

            if (Record.SelectedItem == null) return;

            MyColor[] tempColors = GetColorList();

            string record = Record.SelectedItem.ToString();

            foreach (MyColor c in tempColors) {
                if (c.Name == record) {
                    var color = c.Color;
                    setSliderValue(color);
                    return;
                }
            }

            var m = Regex.Match(record, @"^R:([0-9]{1,3})\sG:([0-9]{1,3})\sB:([0-9]{1,3})");
            var r = m.Groups[1].Value;
            var g = m.Groups[2].Value;
            var b = m.Groups[3].Value;


            if (byte.TryParse(r, out byte rb) &&
                byte.TryParse(g, out byte gb) &&
                byte.TryParse(b, out byte bb)) {
                var c = Color.FromRgb(rb, gb, bb);
                setSliderValue(c);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e) {
            var selectedItem = Record.SelectedItem as string;
            if (selectedItem != null) {
                Record.Items.Remove(selectedItem);
            } else {
                MessageBox.Show("削除する対象を選択してください。。。", "削除エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            bool flg = true;
            string[] message = { "画面を閉じます。よろしいですか？", "本当に？", "マジで？","えっ？","何で？","もう終わるんだよ？","さよなら。。。" };
            foreach (string m in message) {
                if (MessageBoxResult.Yes != MessageBox.Show(m, "確認", MessageBoxButton.YesNo, MessageBoxImage.Question)) {
                    flg = false;
                    break;
                }
            }
            if (!flg) {
                e.Cancel = true;
                return;
            }
           //new MainWindow().Show();
           //MessageBox.Show("また来たにょ～","こんにちわ", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        }
    }
}
