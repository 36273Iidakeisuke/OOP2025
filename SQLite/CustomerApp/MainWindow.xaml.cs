using CustomerApp.Data;
using Microsoft.Win32;
using SQLite;
using System.IO;
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

namespace CustomerApp {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private List<Customer> _Customers = new List<Customer>();

        public MainWindow() {
            InitializeComponent();
            ReadDatabase();
            CustomerListView.ItemsSource = _Customers;
            PictureButton.Click += PictureButton_Click;
        }

        private string _currentImagePath = null;

        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasepath)) {
                connection.CreateTable<Customer>();
                _Customers = connection.Table<Customer>().ToList();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            var Customer = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                Picture = _currentImageBytes,
            };
            using (var connection = new SQLiteConnection(App.databasepath)) {
                connection.CreateTable<Customer>();
                connection.Insert(Customer);
            }

            // データ再読み込みしてListView更新
            ReadDatabase();
            CustomerListView.ItemsSource = null;
            CustomerListView.ItemsSource = _Customers;
        }


        private void ReadButton_Click(object sender, RoutedEventArgs e) {
            ReadDatabase();
            CustomerListView.ItemsSource = _Customers;

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;

            if (item is not null) {
                //データベース接続
                using (var connection = new SQLiteConnection(App.databasepath)) {
                    connection.CreateTable<Customer>();
                    connection.Delete(item);  //データベースから選択されているレコードの削除
                    ReadDatabase();
                    CustomerListView.ItemsSource = _Customers;
                }
            } else {
                MessageBox.Show("削除するデータを選択してください", "削除エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer is null) return;

            using (var connection = new SQLiteConnection(App.databasepath)) {
                connection.CreateTable<Customer>();

                var Customer = new Customer() {
                    Id = (CustomerListView.SelectedItem as Customer).Id,
                    Name = NameTextBox.Text,
                    Phone = PhoneTextBox.Text,
                    Address = AddressTextBox.Text,
                    Picture = _currentImageBytes,
                };
                connection.Update(Customer);

                ReadDatabase();
                CustomerListView.ItemsSource = _Customers;
            }

        }

        private BitmapImage ByteArrayToBitmapImage(byte[] bytes) {
            if (bytes == null || bytes.Length == 0)
                return null;

            using (var stream = new MemoryStream(bytes)) {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
                image.Freeze();
                return image;
            }
        }


        //リストビューのフィルタリング
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _Customers.Where(s => s.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList;

        }
        //リストビューから1レコード選択
        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer is null) return;

            NameTextBox.Text = selectedCustomer.Name;
            PhoneTextBox.Text = selectedCustomer.Phone;
            AddressTextBox.Text = selectedCustomer.Address;
            _currentImageBytes = selectedCustomer.Picture;

            if (selectedCustomer.Picture != null && selectedCustomer.Picture.Length > 0) {
                PictureImage.Source = ByteArrayToBitmapImage(selectedCustomer.Picture);
            } else {
                PictureImage.Source = null;
            }
        }


        private byte[] _currentImageBytes;

        private void PictureButton_Click(object sender, RoutedEventArgs e) {
            var dialog = new OpenFileDialog();
            dialog.Filter = "画像ファイル (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|すべてのファイル (*.*)|*.*";

            if (dialog.ShowDialog() == true) {
                string selectedFile = dialog.FileName;

                var bitmap = new BitmapImage(new Uri(selectedFile, UriKind.Absolute));
                PictureImage.Source = bitmap;

                _currentImageBytes = LoadImageFileToByteArray(selectedFile);
            }
        }

        private byte[] LoadImageFileToByteArray(string filePath) {
            return File.ReadAllBytes(filePath);
        }

    }
}