using System.Diagnostics;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            using (var streamReader = new StreamReader("‘–‚êƒƒƒX.txt")) {
                Reader s = new Reader();
                await s.DoLongTimeWorkAsync(streamReader);
                
            }
            toolStripStatusLabel1.Text = "Š®—¹";
        }
    }
}
