using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static CarReportSystem.CarReport;
using static CarReportSystem.fmVersion;

namespace CarReportSystem {
    public partial class Form1 : Form {

        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        Settings settings = Settings.getInstance();


        public Form1() {
            InitializeComponent();
            dgvRecord.DataSource = listCarReports;
        }

        //日付の時間表示をなくす
        private void Form1_Load(object sender, EventArgs e) {
            InputItemsAllClear();

            //一覧で交互に色を設定する（データグリッドビュー）
            dgvRecord.DefaultCellStyle.BackColor = Color.White;
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow;

            //設定ファイルへを読み込み背景色を設定する（逆シリアル化）
            if (File.Exists("setting.xml")) {
                try {
                    using (var reader = XmlReader.Create("setting.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        var dt = serializer.Deserialize(reader) as Settings;
                        settings = dt ?? Settings.getInstance();
                        this.BackColor = Color.FromArgb(settings.MainFormBackColor);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "エラー:" + ex.Message;
                }
            }
        }

        //画像を開くボタンイベント
        private void op1_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        //画像削除ボタンイベント
        private void dt1_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        //追加ボタンのイベント
        private void buru_Click(object sender, EventArgs e) {

            tsslbMessage.Text = string.Empty;

            if (cbCarName.Text == string.Empty || cbAuthor.Text == string.Empty) {
                tsslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }

            var carReport = new CarReport {
                Auther = cbAuthor.Text,
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
                Date = dtpDate.Value,
                Maker = GetRadioButtonMaker()
            };
            listCarReports.Add(carReport);
            setCbAuthor(cbAuthor.Text);
            setcbCarName(cbCarName.Text);
            InputItemsAllClear();
        }

        //メーカー選択
        private MakerGroup GetRadioButtonMaker() {
            if (rbトヨタ.Checked) {
                return MakerGroup.トヨタ;
            } else if (rbスバル.Checked) {
                return MakerGroup.スバル;
            } else if (rbホンダ.Checked) {
                return MakerGroup.ホンダ;
            } else if (rb日産.Checked) {
                return MakerGroup.日産;
            } else if (rb輸入車.Checked) {
                return MakerGroup.輸入車;
            } else {
                return MakerGroup.その他;
            }
        }

        //入力項目をすべてクリア
        private void InputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            pbPicture.Image = null;
            cbAuthor.Text = null;
            rbOther.Checked = true;
            rbOther.Checked = false;
            cbCarName.Text = null;
            tbReport.Text = null;
        }

        //1行削除
        private void btRecodDelete_Click(object sender, EventArgs e) {
            if (dgvRecord.Rows.Count == 0) {
                tsslbMessage.Text = "削除すべき場所が見当たりません。。。";
                return;
            }
            listCarReports.RemoveAt(dgvRecord.CurrentRow.Index);
        }

        //一覧に追加
        private void dgvRecord_Click(object sender, EventArgs e) {
            dtpDate.Value = (DateTime)dgvRecord.CurrentRow.Cells["Date"].Value;
            pbPicture.Image = (Image)dgvRecord.CurrentRow.Cells["Picture"].Value;
            cbAuthor.Text = (string)dgvRecord.CurrentRow.Cells["Auther"].Value;
            setRadioButtonMaker((MakerGroup)dgvRecord.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecord.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecord.CurrentRow.Cells["Report"].Value;
        }

        //指定したメーカーのラジオボタンをセット
        private void setRadioButtonMaker(MakerGroup targetMaker) {
            switch (targetMaker) {
                case MakerGroup.なし:
                    return;
                case MakerGroup.トヨタ:
                    return;
                case MakerGroup.日産:
                    return;
                case MakerGroup.ホンダ:
                    return;
                case MakerGroup.スバル:
                    return;
                case MakerGroup.輸入車:
                    return;
                case MakerGroup.その他:
                    return;
            }
        }

        //記録者の履歴をコンボボックスへ登録（重複なし）
        private void setCbAuthor(string author) {
            //既に登録済みか確認
            if (cbAuthor.Items == null) {
                return;
            } else {
                if (cbAuthor.Items.Contains(author)) {
                } else {
                    //未登録なら登録【登録済みなら何もしない】
                    cbAuthor.Items.Add(author);
                }
            }
        }

        //車名の履歴をコンボボックスへ登録（重複なし）
        private void setcbCarName(string carName) {
            if (cbCarName.Items == null) {
                return;
            } else {
                if (cbCarName.Items.Contains(carName)) {
                } else {
                    cbCarName.Items.Add(carName);
                }

            }
        }

        //新規入力ボタンイベント
        private void btNewRecord_Click(object sender, EventArgs e) {
            InputItemsAllClear();
        }

        //修正ボタンイベント
        private void btRecordModify_Click(object sender, EventArgs e) {

            tsslbMessage.Text = string.Empty;

            if (dgvRecord.Rows.Count == 0) {
                tsslbMessage.Text = "修正すべき場所が見当たりません。。。";
                return;
            }

            listCarReports[dgvRecord.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvRecord.CurrentRow.Index].Auther = cbAuthor.Text;
            listCarReports[dgvRecord.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvRecord.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvRecord.CurrentRow.Index].Picture = pbPicture.Image;
            listCarReports[dgvRecord.CurrentRow.Index].Maker = GetRadioButtonMaker();
            dgvRecord.Refresh();
        }

        //終了ボタンイベント
        private void tsmiExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        //このアプリについてを選択したときのイベントハンドラ
        private void tsmiAbout_Click(object sender, EventArgs e) {
            fmVersion fmv = new fmVersion();
            fmv.Show();
        }

        //色設定から背景色を変更する
        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cbColor.ShowDialog() == DialogResult.OK) {
                // 選択した色で背景を変更
                this.BackColor = cbColor.Color;
                //設定ファイルへ保存
                settings.MainFormBackColor = cbColor.Color.ToArgb();//背景色を設定インスタンスへ保存
            }
        }

        //ファイルオープン処理
        private void reportOpenFile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {

                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;

                    }


                    cbAuthor.Items.Clear();
                    cbCarName.Items.Clear();
                    //コンボボックスに登録
                    foreach (var report in listCarReports) {
                        setCbAuthor(report.Auther);
                        setcbCarName(report.CarName);
                    }
                }
                catch (Exception) {
                    tsslbMessage.Text = "  ファイル形式が違います";
                }
            }
        }

        //ファイルセーブ処理
        private void reportSaveFile() {

            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {

                    //バイナリでシリアル化
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning disable SYSLIB0011

                    using (FileStream fs = File.Open(sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "ファイル書き出しエラー";
                }
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFile();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルへ色の情報を保存する
            try {
                using (var writer = XmlWriter.Create("setting.xml")) {
                    var serializer = new XmlSerializer(settings.GetType());
                    serializer.Serialize(writer, settings);
                }
            }
            catch (Exception ex) {
                tsslbMessage.Text = "エラー" + ex.Message;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e) {
            lbTimer.Text = DateTime.Now.ToString("HH:mm");
        }
    }
}
