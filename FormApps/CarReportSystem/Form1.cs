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

        //���t�̎��ԕ\�����Ȃ���
        private void Form1_Load(object sender, EventArgs e) {
            InputItemsAllClear();

            //�ꗗ�Ō��݂ɐF��ݒ肷��i�f�[�^�O���b�h�r���[�j
            dgvRecord.DefaultCellStyle.BackColor = Color.White;
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow;

            //�ݒ�t�@�C���ւ�ǂݍ��ݔw�i�F��ݒ肷��i�t�V���A�����j
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
                    tsslbMessage.Text = "�G���[:" + ex.Message;
                }
            }
        }

        //�摜���J���{�^���C�x���g
        private void op1_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        //�摜�폜�{�^���C�x���g
        private void dt1_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        //�ǉ��{�^���̃C�x���g
        private void buru_Click(object sender, EventArgs e) {

            tsslbMessage.Text = string.Empty;

            if (cbCarName.Text == string.Empty || cbAuthor.Text == string.Empty) {
                tsslbMessage.Text = "�L�^�ҁA�܂��͎Ԗ��������͂ł�";
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

        //���[�J�[�I��
        private MakerGroup GetRadioButtonMaker() {
            if (rb�g���^.Checked) {
                return MakerGroup.�g���^;
            } else if (rb�X�o��.Checked) {
                return MakerGroup.�X�o��;
            } else if (rb�z���_.Checked) {
                return MakerGroup.�z���_;
            } else if (rb���Y.Checked) {
                return MakerGroup.���Y;
            } else if (rb�A����.Checked) {
                return MakerGroup.�A����;
            } else {
                return MakerGroup.���̑�;
            }
        }

        //���͍��ڂ����ׂăN���A
        private void InputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            pbPicture.Image = null;
            cbAuthor.Text = null;
            rbOther.Checked = true;
            rbOther.Checked = false;
            cbCarName.Text = null;
            tbReport.Text = null;
        }

        //1�s�폜
        private void btRecodDelete_Click(object sender, EventArgs e) {
            if (dgvRecord.Rows.Count == 0) {
                tsslbMessage.Text = "�폜���ׂ��ꏊ����������܂���B�B�B";
                return;
            }
            listCarReports.RemoveAt(dgvRecord.CurrentRow.Index);
        }

        //�ꗗ�ɒǉ�
        private void dgvRecord_Click(object sender, EventArgs e) {
            dtpDate.Value = (DateTime)dgvRecord.CurrentRow.Cells["Date"].Value;
            pbPicture.Image = (Image)dgvRecord.CurrentRow.Cells["Picture"].Value;
            cbAuthor.Text = (string)dgvRecord.CurrentRow.Cells["Auther"].Value;
            setRadioButtonMaker((MakerGroup)dgvRecord.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecord.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecord.CurrentRow.Cells["Report"].Value;
        }

        //�w�肵�����[�J�[�̃��W�I�{�^�����Z�b�g
        private void setRadioButtonMaker(MakerGroup targetMaker) {
            switch (targetMaker) {
                case MakerGroup.�Ȃ�:
                    return;
                case MakerGroup.�g���^:
                    return;
                case MakerGroup.���Y:
                    return;
                case MakerGroup.�z���_:
                    return;
                case MakerGroup.�X�o��:
                    return;
                case MakerGroup.�A����:
                    return;
                case MakerGroup.���̑�:
                    return;
            }
        }

        //�L�^�҂̗������R���{�{�b�N�X�֓o�^�i�d���Ȃ��j
        private void setCbAuthor(string author) {
            //���ɓo�^�ς݂��m�F
            if (cbAuthor.Items == null) {
                return;
            } else {
                if (cbAuthor.Items.Contains(author)) {
                } else {
                    //���o�^�Ȃ�o�^�y�o�^�ς݂Ȃ牽�����Ȃ��z
                    cbAuthor.Items.Add(author);
                }
            }
        }

        //�Ԗ��̗������R���{�{�b�N�X�֓o�^�i�d���Ȃ��j
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

        //�V�K���̓{�^���C�x���g
        private void btNewRecord_Click(object sender, EventArgs e) {
            InputItemsAllClear();
        }

        //�C���{�^���C�x���g
        private void btRecordModify_Click(object sender, EventArgs e) {

            tsslbMessage.Text = string.Empty;

            if (dgvRecord.Rows.Count == 0) {
                tsslbMessage.Text = "�C�����ׂ��ꏊ����������܂���B�B�B";
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

        //�I���{�^���C�x���g
        private void tsmiExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        //���̃A�v���ɂ��Ă�I�������Ƃ��̃C�x���g�n���h��
        private void tsmiAbout_Click(object sender, EventArgs e) {
            fmVersion fmv = new fmVersion();
            fmv.Show();
        }

        //�F�ݒ肩��w�i�F��ύX����
        private void �F�ݒ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cbColor.ShowDialog() == DialogResult.OK) {
                // �I�������F�Ŕw�i��ύX
                this.BackColor = cbColor.Color;
                //�ݒ�t�@�C���֕ۑ�
                settings.MainFormBackColor = cbColor.Color.ToArgb();//�w�i�F��ݒ�C���X�^���X�֕ۑ�
            }
        }

        //�t�@�C���I�[�v������
        private void reportOpenFile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //�t�V���A����
#pragma warning disable SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    using (FileStream fs = File.Open(ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {

                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;

                    }


                    cbAuthor.Items.Clear();
                    cbCarName.Items.Clear();
                    //�R���{�{�b�N�X�ɓo�^
                    foreach (var report in listCarReports) {
                        setCbAuthor(report.Auther);
                        setcbCarName(report.CarName);
                    }
                }
                catch (Exception) {
                    tsslbMessage.Text = "  �t�@�C���`�����Ⴂ�܂�";
                }
            }
        }

        //�t�@�C���Z�[�u����
        private void reportSaveFile() {

            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {

                    //�o�C�i���ŃV���A����
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning disable SYSLIB0011

                    using (FileStream fs = File.Open(sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "�t�@�C�������o���G���[";
                }
            }
        }

        private void �ۑ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();
        }

        private void �J��ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFile();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //�ݒ�t�@�C���֐F�̏���ۑ�����
            try {
                using (var writer = XmlWriter.Create("setting.xml")) {
                    var serializer = new XmlSerializer(settings.GetType());
                    serializer.Serialize(writer, settings);
                }
            }
            catch (Exception ex) {
                tsslbMessage.Text = "�G���[" + ex.Message;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e) {
            lbTimer.Text = DateTime.Now.ToString("HH:mm");
        }
    }
}
