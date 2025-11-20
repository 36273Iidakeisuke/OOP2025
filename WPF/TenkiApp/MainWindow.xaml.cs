using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace WeatherApp {
    public partial class MainWindow : Window {
        private WeatherViewModel _viewModel;
        private DispatcherTimer _updateTimer;

        public MainWindow() {
            InitializeComponent();

            _viewModel = new WeatherViewModel();
            DataContext = _viewModel;

            InitializeEventHandlers();
            StartAutoUpdate();

            // 初期アニメーション
            PlayFadeInAnimation();

            // 初期データ読み込み
            _ = _viewModel.LoadWeatherForCityAsync("東京");
        }

        private void InitializeEventHandlers() {
            // ウィンドウのドラッグ移動
            MouseLeftButtonDown += (s, e) => {
                try { if (e.ChangedButton == MouseButton.Left) DragMove(); }
                catch { }
            };
        }

        private void OnRegionSelected(object sender, RoutedEventArgs e) {
            if (sender is Button button) {
                string regionName = button.Tag?.ToString() ?? button.Content.ToString();
                _ = _viewModel.LoadWeatherForRegionAsync(regionName);
                AnimateButton(button);
            }
        }

        private void OnCitySelected(object sender, RoutedEventArgs e) {
            if (sender is Button button) {
                string cityName = button.Tag?.ToString() ?? button.Content.ToString();
                _ = _viewModel.LoadWeatherForCityAsync(cityName);
                AnimateButton(button);
            }
        }

        private void OnRefreshClicked(object sender, RoutedEventArgs e) {
            _ = _viewModel.RefreshWeatherAsync();
        }

        private void OnSettingsClicked(object sender, RoutedEventArgs e) {
            var settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
        }

        private void StartAutoUpdate() {
            _updateTimer = new DispatcherTimer {
                Interval = TimeSpan.FromMinutes(10)
            };
            _updateTimer.Tick += async (s, e) => await _viewModel.RefreshWeatherAsync();
            _updateTimer.Start();
        }

        private void AnimateButton(Button button) {
            var scaleTransform = new System.Windows.Media.ScaleTransform(1, 1);
            button.RenderTransform = scaleTransform;
            button.RenderTransformOrigin = new Point(0.5, 0.5);

            var animation = new DoubleAnimation {
                From = 1.0,
                To = 1.1,
                Duration = TimeSpan.FromMilliseconds(150),
                AutoReverse = true
            };

            scaleTransform.BeginAnimation(System.Windows.Media.ScaleTransform.ScaleXProperty, animation);
            scaleTransform.BeginAnimation(System.Windows.Media.ScaleTransform.ScaleYProperty, animation);
        }

        private void PlayFadeInAnimation() {
            var fadeIn = new DoubleAnimation {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(500)
            };
            BeginAnimation(OpacityProperty, fadeIn);
        }

        protected override void OnClosing(CancelEventArgs e) {
            _updateTimer?.Stop();
            base.OnClosing(e);
        }
    }

    // ViewModel
    public class WeatherViewModel : INotifyPropertyChanged {
        private WeatherData _currentWeather;
        private ObservableCollection<HourlyForecast> _hourlyForecasts;
        private ObservableCollection<DailyForecast> _weeklyForecasts;
        private WeatherService _weatherService;
        private bool _isLoading;

        public WeatherViewModel() {
            _weatherService = new WeatherService();
            _hourlyForecasts = new ObservableCollection<HourlyForecast>();
            _weeklyForecasts = new ObservableCollection<DailyForecast>();
        }

        public WeatherData CurrentWeather {
            get => _currentWeather;
            set {
                _currentWeather = value;
                OnPropertyChanged(nameof(CurrentWeather));
            }
        }

        public ObservableCollection<HourlyForecast> HourlyForecasts {
            get => _hourlyForecasts;
            set {
                _hourlyForecasts = value;
                OnPropertyChanged(nameof(HourlyForecasts));
            }
        }

        public ObservableCollection<DailyForecast> WeeklyForecasts {
            get => _weeklyForecasts;
            set {
                _weeklyForecasts = value;
                OnPropertyChanged(nameof(WeeklyForecasts));
            }
        }

        public bool IsLoading {
            get => _isLoading;
            set {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public async Task LoadWeatherForRegionAsync(string regionName) {
            IsLoading = true;
            try {
                var weatherData = await _weatherService.GetWeatherByRegionAsync(regionName);
                UpdateWeatherData(weatherData);
            }
            catch (Exception ex) {
                MessageBox.Show($"天気データの取得に失敗しました: {ex.Message}", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally {
                IsLoading = false;
            }
        }

        public async Task LoadWeatherForCityAsync(string cityName) {
            IsLoading = true;
            try {
                var weatherData = await _weatherService.GetWeatherByCityAsync(cityName);
                UpdateWeatherData(weatherData);
            }
            catch (Exception ex) {
                MessageBox.Show($"天気データの取得に失敗しました: {ex.Message}", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally {
                IsLoading = false;
            }
        }

        public async Task RefreshWeatherAsync() {
            if (CurrentWeather != null) {
                await LoadWeatherForCityAsync(CurrentWeather.LocationName);
            }
        }

        private void UpdateWeatherData(WeatherData data) {
            CurrentWeather = data;
            HourlyForecasts.Clear();
            foreach (var forecast in data.HourlyForecasts) {
                HourlyForecasts.Add(forecast);
            }
            WeeklyForecasts.Clear();
            foreach (var forecast in data.DailyForecasts) {
                WeeklyForecasts.Add(forecast);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Models
    public class WeatherData {
        public string LocationName { get; set; }
        public string Region { get; set; }
        public DateTime UpdateTime { get; set; }
        public double Temperature { get; set; }
        public double FeelsLike { get; set; }
        public string Condition { get; set; }
        public string WeatherIcon { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public int PrecipitationChance { get; set; }
        public string UVIndex { get; set; }
        public HourlyForecast[] HourlyForecasts { get; set; }
        public DailyForecast[] DailyForecasts { get; set; }
    }

    public class HourlyForecast {
        public string Time { get; set; }
        public string Icon { get; set; }
        public int Temperature { get; set; }
    }

    public class DailyForecast {
        public string DayOfWeek { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public int HighTemp { get; set; }
        public int LowTemp { get; set; }
        public int PrecipitationChance { get; set; }
    }

    // Open-Meteo API Service
    public class WeatherService {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.open-meteo.com/v1/forecast";

        // 日本の主要都市の座標
        private readonly System.Collections.Generic.Dictionary<string, (double lat, double lon)> _cityCoordinates = new()
        {
            { "札幌", (43.0642, 141.3469) },
            { "仙台", (38.2682, 140.8694) },
            { "東京", (35.6762, 139.6503) },
            { "名古屋", (35.1815, 136.9066) },
            { "大阪", (34.6937, 135.5023) },
            { "広島", (34.3853, 132.4553) },
            { "高松", (34.3402, 134.0434) },
            { "福岡", (33.5904, 130.4017) },
            { "那覇", (26.2124, 127.6809) }
        };

        // 地域のメイン都市マッピング
        private readonly System.Collections.Generic.Dictionary<string, string> _regionCities = new()
        {
            { "北海道", "札幌" },
            { "東北", "仙台" },
            { "関東", "東京" },
            { "中部", "名古屋" },
            { "近畿", "大阪" },
            { "中国", "広島" },
            { "四国", "高松" },
            { "九州", "福岡" },
            { "沖縄", "那覇" }
        };

        public WeatherService() {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<WeatherData> GetWeatherByRegionAsync(string regionName) {
            var cityName = _regionCities.ContainsKey(regionName) ? _regionCities[regionName] : "東京";
            return await GetWeatherByCityAsync(cityName);
        }

        public async Task<WeatherData> GetWeatherByCityAsync(string cityName) {
            if (!_cityCoordinates.ContainsKey(cityName)) {
                cityName = "東京";
            }

            var (lat, lon) = _cityCoordinates[cityName];

            var url = $"{BaseUrl}?" +
                      $"latitude={lat:F4}&longitude={lon:F4}" +
                      $"&hourly=temperature_2m,relative_humidity_2m,apparent_temperature,precipitation_probability,weathercode,windspeed_10m" +
                      $"&daily=weathercode,temperature_2m_max,temperature_2m_min,precipitation_probability_max,uv_index_max" +
                      $"&timezone=Asia/Tokyo" +
                      $"&forecast_days=7";

            try {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<OpenMeteoResponse>(json, new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true
                });

                return ParseWeatherData(apiResponse, cityName);
            }
            catch (Exception ex) {
                throw new Exception($"Open-Meteo APIからのデータ取得に失敗しました: {ex.Message}", ex);
            }
        }

        private WeatherData ParseWeatherData(OpenMeteoResponse response, string cityName) {
            var now = DateTime.Now;
            var currentHourIndex = now.Hour;

            // 現在の天気データ
            var currentTemp = response.Hourly.Temperature_2m[currentHourIndex];
            var currentFeelsLike = response.Hourly.Apparent_temperature[currentHourIndex];
            var currentHumidity = response.Hourly.Relative_humidity_2m[currentHourIndex];
            var currentWindSpeed = response.Hourly.Windspeed_10m[currentHourIndex];
            var currentPrecipProb = response.Hourly.Precipitation_probability[currentHourIndex];
            var currentWeatherCode = response.Hourly.Weathercode[currentHourIndex];

            // 時間別予報（次の6時間、3時間おき）
            var hourlyForecasts = new System.Collections.Generic.List<HourlyForecast>();
            for (int i = 0; i < 6; i++) {
                var index = currentHourIndex + (i * 3);
                if (index >= response.Hourly.Time.Length) break;

                var time = DateTime.Parse(response.Hourly.Time[index]);
                hourlyForecasts.Add(new HourlyForecast {
                    Time = time.ToString("HH:mm"),
                    Icon = GetWeatherIcon(response.Hourly.Weathercode[index], time.Hour),
                    Temperature = (int)Math.Round(response.Hourly.Temperature_2m[index])
                });
            }

            // 週間予報
            var dailyForecasts = new System.Collections.Generic.List<DailyForecast>();
            var daysOfWeek = new[] { "日曜日", "月曜日", "火曜日", "水曜日", "木曜日", "金曜日", "土曜日" };

            for (int i = 1; i < Math.Min(6, response.Daily.Time.Length); i++) {
                var date = DateTime.Parse(response.Daily.Time[i]);
                dailyForecasts.Add(new DailyForecast {
                    DayOfWeek = daysOfWeek[(int)date.DayOfWeek],
                    Icon = GetWeatherIcon(response.Daily.Weathercode[i], 12),
                    Description = GetWeatherDescription(response.Daily.Weathercode[i]),
                    HighTemp = (int)Math.Round(response.Daily.Temperature_2m_max[i]),
                    LowTemp = (int)Math.Round(response.Daily.Temperature_2m_min[i]),
                    PrecipitationChance = (int)Math.Round(response.Daily.Precipitation_probability_max[i])
                });
            }

            var uvIndex = response.Daily.Uv_index_max[0];
            var uvLevel = uvIndex < 3 ? "低い" : uvIndex < 6 ? "中程度" : uvIndex < 8 ? "高い" : "非常に高い";

            return new WeatherData {
                LocationName = cityName,
                Region = GetRegionForCity(cityName),
                UpdateTime = DateTime.Now,
                Temperature = Math.Round(currentTemp, 1),
                FeelsLike = Math.Round(currentFeelsLike, 1),
                Condition = GetWeatherDescription(currentWeatherCode),
                WeatherIcon = GetWeatherIcon(currentWeatherCode, now.Hour),
                Humidity = (int)Math.Round(currentHumidity),
                WindSpeed = Math.Round(currentWindSpeed, 1),
                PrecipitationChance = (int)Math.Round(currentPrecipProb),
                UVIndex = uvLevel,
                HourlyForecasts = hourlyForecasts.ToArray(),
                DailyForecasts = dailyForecasts.ToArray()
            };
        }

        private string GetWeatherIcon(int weatherCode, int hour) {
            bool isNight = hour < 6 || hour >= 18;

            return weatherCode switch {
                0 => isNight ? "🌙" : "☀️",              // Clear sky
                1 or 2 => isNight ? "⭐" : "🌤️",         // Mainly clear
                3 => "⛅",                                 // Partly cloudy
                45 or 48 => "🌫️",                        // Fog
                51 or 53 or 55 => "🌧️",                  // Drizzle
                61 or 63 or 65 => "🌧️",                  // Rain
                71 or 73 or 75 => "🌨️",                  // Snow
                77 => "🌨️",                               // Snow grains
                80 or 81 or 82 => "🌧️",                  // Rain showers
                85 or 86 => "🌨️",                        // Snow showers
                95 => "⛈️",                               // Thunderstorm
                96 or 99 => "⛈️",                         // Thunderstorm with hail
                _ => isNight ? "🌙" : "☀️"
            };
        }

        private string GetWeatherDescription(int weatherCode) {
            return weatherCode switch {
                0 => "快晴",
                1 or 2 => "晴れ",
                3 => "曇り",
                45 or 48 => "霧",
                51 or 53 or 55 => "小雨",
                61 or 63 or 65 => "雨",
                71 or 73 or 75 => "雪",
                77 => "霰",
                80 or 81 or 82 => "にわか雨",
                85 or 86 => "にわか雪",
                95 => "雷雨",
                96 or 99 => "雹を伴う雷雨",
                _ => "不明"
            };
        }

        private string GetRegionForCity(string city) {
            var cityRegionMap = new System.Collections.Generic.Dictionary<string, string>
            {
                { "札幌", "北海道" },
                { "仙台", "東北" },
                { "東京", "関東" },
                { "名古屋", "中部" },
                { "大阪", "近畿" },
                { "広島", "中国" },
                { "高松", "四国" },
                { "福岡", "九州" },
                { "那覇", "沖縄" }
            };

            return cityRegionMap.ContainsKey(city) ? cityRegionMap[city] : "関東";
        }
    }

    // Open-Meteo API Response Models
    public class OpenMeteoResponse {
        public HourlyData Hourly { get; set; }
        public DailyData Daily { get; set; }
    }

    public class HourlyData {
        public string[] Time { get; set; }
        public double[] Temperature_2m { get; set; }
        public double[] Relative_humidity_2m { get; set; }
        public double[] Apparent_temperature { get; set; }
        public double[] Precipitation_probability { get; set; }
        public int[] Weathercode { get; set; }
        public double[] Windspeed_10m { get; set; }
    }

    public class DailyData {
        public string[] Time { get; set; }
        public int[] Weathercode { get; set; }
        public double[] Temperature_2m_max { get; set; }
        public double[] Temperature_2m_min { get; set; }
        public double[] Precipitation_probability_max { get; set; }
        public double[] Uv_index_max { get; set; }
    }

    // 設定ウィンドウ
    public class SettingsWindow : Window {
        public SettingsWindow() {
            Title = "設定";
            Width = 400;
            Height = 300;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            var content = new StackPanel { Margin = new Thickness(20) };
            Content = content;
        }
    }
}