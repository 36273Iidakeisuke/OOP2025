using System.Diagnostics;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            var elapsed = await DoLongTimeWorkAsync(4000);
            toolStripStatusLabel1.Text = $"{elapsed}�~���b";
        }

        private async Task DoLongTimeWorkAsync(int milliseconds) {
            var sw = Stopwatch.StartNew();
            await Task.Run(() => {
                System.Threading.Thread.Sleep(milliseconds);
            });
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
