using System.Net;
using System.Text.Json;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;


        Dictionary<string, string> rssUrlDict = new Dictionary<string, string>() {
                {"主要","https://news.yahoo.co.jp/rss/topics/top-picks.xml" },
                {"国内","https://news.yahoo.co.jp/rss/topics/domestic.xml" },
                {"国際","https://news.yahoo.co.jp/rss/topics/world.xml" },
                {"経済","https://news.yahoo.co.jp/rss/topics/business.xml" },
                {"スポーツ","https://news.yahoo.co.jp/rss/topics/sports.xml" },
        };
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            btBack.Enabled = webView21.CanGoBack;
            btforward.Enabled = webView21.CanGoForward;
            cbUrl.Items.AddRange(rssUrlDict.Select(k => k.Key).ToArray());

            // JSONデータの読み込みと復元
            try {
                string readJson = System.IO.File.ReadAllText("dictionary.json");
                var loadedDict = JsonSerializer.Deserialize<Dictionary<string, string>>(readJson);
                rssUrlDict = loadedDict ?? new Dictionary<string, string>();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private async void btRssGet_Click(object sender, EventArgs e) {
            using (var wc = new HttpClient()) {
                try {
                    using HttpResponseMessage response = await wc.GetAsync(getRssUrl(cbUrl.Text));
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    XDocument xdoc = XDocument.Parse(responseBody); //RKSの取得

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
                //リスボックスへタイトルを表示
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title ?? "データなし"));
            }
        }
        //コンボックスの文字列をチェックしてアクセス可能なURLを返却する
        private string getRssUrl(string str) {
            if (rssUrlDict.ContainsKey(str)) {
                return rssUrlDict[str];
            }
            return str;
        }
        //タイトルを選択（クリック）したときに呼ばれるイントハンドラ
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
        private void btfavorite_Click(object sender, EventArgs e) {
            if (cbUrl.Items.Contains(tbFavorite.Text) || rssUrlDict.ContainsKey(cbUrl.Text)) {
                return;
            }
            if (string.IsNullOrEmpty(tbFavorite.Text)) {
                if (!string.IsNullOrEmpty(cbUrl.Text)) {
                    rssUrlDict.Add(cbUrl.Text, cbUrl.Text);
                    cbUrl.Items.Add(cbUrl.Text);
                }

                return;
            } else {
                rssUrlDict.Add(tbFavorite.Text, cbUrl.Text);
                cbUrl.Items.Add(tbFavorite.Text);
            }
        }
        private void btdelete_Click(object sender, EventArgs e) {
            if (cbUrl.Items.Contains(cbUrl.Text)) {
                rssUrlDict.Remove(tbFavorite.Text);
                cbUrl.Items.Remove(tbFavorite.Text);
            }
        }
        private void webView21_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            btBack.Enabled = webView21.CanGoBack;
            btforward.Enabled = webView21.CanGoForward;
        }

        private void tsmEnd_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        // JSONとして保存
        private void tsmKeep_Click(object sender, EventArgs e) {
            var options = new JsonSerializerOptions { WriteIndented = true }; // 見やすいJSON
            string json = JsonSerializer.Serialize(rssUrlDict, options);
            System.IO.File.WriteAllText("dictionary.json", json);
        }
    }
}

