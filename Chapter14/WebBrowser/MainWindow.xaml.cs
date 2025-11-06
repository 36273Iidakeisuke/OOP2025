using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebBrowser;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        WebView.EnsureCoreWebView2Async(null);
    }

    private void BackButton_Click(object sender, RoutedEventArgs e) {
        // WebView2 に戻る履歴があるかチェック
        if (WebView.CanGoBack) {
            WebView.GoBack();
        }
    }

    private void FowardButton_Click(object sender, RoutedEventArgs e) {
        // WebView2 に進む履歴があるかチェック
        if (WebView.CanGoForward) {
            WebView.GoForward();
        }
    }

    private void GoButton_Click(object sender, RoutedEventArgs e) {
            WebView.Source = new Uri(AddressBar.Text);
    }
}
