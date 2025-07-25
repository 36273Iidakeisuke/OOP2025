using System.Net;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;


        Dictionary<string, string> rssUrlDict = new Dictionary<string, string>() {
                {"��v","https://news.yahoo.co.jp/rss/topics/top-picks.xml" },
                {"����","https://news.yahoo.co.jp/rss/topics/domestic.xml" },
                {"����","https://news.yahoo.co.jp/rss/topics/world.xml" },
                {"�o��","https://news.yahoo.co.jp/rss/topics/business.xml" },
                {"�G���^��","https://news.yahoo.co.jp/rss/topics/entertainment.xml" },
                {"�X�|�[�c","https://news.yahoo.co.jp/rss/topics/sports.xml" },
        };
        public Form1() {
            InitializeComponent();
        }
        private async void btRssGet_Click(object sender, EventArgs e) {
            using (var wc = new HttpClient()) {
                try {
                    using HttpResponseMessage response = await wc.GetAsync(getRssUrl(cbUrl.Text));
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    XDocument xdoc = XDocument.Parse(responseBody); //RKS�̎擾

                    items = xdoc.Root.Descendants("item")
                        .Select(x =>
                            new ItemData {
                                Title = (string)x.Element("title"),
                                Link = (string)x.Element("link"),
                            }
                        ).ToList();
                }
                catch (Exception) {
                    return;
                }
                //���X�{�b�N�X�փ^�C�g����\��
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title ?? "�f�[�^�Ȃ�"));
            }
        }
        //�R���{�{�b�N�X�̕�������`�F�b�N���ăA�N�Z�X�\��URL��ԋp����
        private string getRssUrl(string str) {
            if (rssUrlDict.ContainsKey(str)) {
                return rssUrlDict[str];
            }
            return str;
        }
        //�^�C�g����I���i�N���b�N�j�����Ƃ��ɌĂ΂��C�x���g�n���h��
        private void lbTitles_Click(object sender, EventArgs e) {
            if (lbTitles.SelectedIndex >= 0 && lbTitles.SelectedIndex < items.Count) {
                webView21.Source = new Uri(items[lbTitles.SelectedIndex].Link);
            }
        }
        private void btforward_Click(object sender, EventArgs e) {
            webView21.GoForward();
        }
        private void btBack_Click(object sender, EventArgs e) {
            webView21.GoBack();
        }
        private void Form1_Load(object sender, EventArgs e) {
            btBack.Enabled = webView21.CanGoBack;
            btforward.Enabled = webView21.CanGoForward;
            cbUrl.Items.AddRange(rssUrlDict.Select(k => k.Key).ToArray());
        }
        private void btfavorite_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(tbFavorite.Text)) {
                if (!string.IsNullOrEmpty(cbUrl.Text)) {
                    rssUrlDict.Add(cbUrl.Text, cbUrl.Text);
                    cbUrl.Items.Add(cbUrl.Text);
                }

                return;
            }
            if (cbUrl.Items.Contains(tbFavorite.Text)) {
                return;
            } else {
                rssUrlDict.Add(tbFavorite.Text, cbUrl.Text);
                cbUrl.Items.Add(tbFavorite.Text);
            }
        }
        private void btdelete_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(tbFavorite.Text)) {
                return;
            } else if (cbUrl.Items.Contains(tbFavorite.Text)) {
                rssUrlDict.Remove(tbFavorite.Text);
                cbUrl.Items.Remove(tbFavorite.Text);
            }
        }
        private void webView21_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            btBack.Enabled = webView21.CanGoBack;
            btforward.Enabled = webView21.CanGoForward;
        }
    }
}

