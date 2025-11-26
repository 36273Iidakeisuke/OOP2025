// MainViewModel.cs
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels {
    public class MainViewModel : INotifyPropertyChanged {
        private readonly WeatherService _weatherService;
        private WeatherData _currentWeather;
        private string _searchCity = "東京";
        private bool _isLoading;

        public WeatherData CurrentWeather {
            get => _currentWeather;
            set { _currentWeather = value; OnPropertyChanged(nameof(CurrentWeather)); }
        }

        public string SearchCity {
            get => _searchCity;
            set { _searchCity = value; OnPropertyChanged(nameof(SearchCity)); }
        }

        public bool IsLoading {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(nameof(IsLoading)); }
        }

        public ObservableCollection<HourlyForecast> HourlyForecasts { get; set; }
        public ObservableCollection<DailyForecast> DailyForecasts { get; set; }

        public ICommand SearchCommand { get; }
        public ICommand RefreshCommand { get; }

        public MainViewModel() {
            _weatherService = new WeatherService();
            HourlyForecasts = new ObservableCollection<HourlyForecast>();
            DailyForecasts = new ObservableCollection<DailyForecast>();

            SearchCommand = new RelayCommand(async () => await LoadWeatherDataAsync());
            RefreshCommand = new RelayCommand(async () => await LoadWeatherDataAsync());

            _ = LoadWeatherDataAsync();
        }

        private async Task LoadWeatherDataAsync() {
            IsLoading = true;

            try {
                CurrentWeather = await _weatherService.GetCurrentWeatherAsync(SearchCity);

                var hourly = await _weatherService.GetHourlyForecastAsync(SearchCity);
                HourlyForecasts.Clear();
                foreach (var forecast in hourly)
                    HourlyForecasts.Add(forecast);

                var daily = await _weatherService.GetDailyForecastAsync(SearchCity);
                DailyForecasts.Clear();
                foreach (var forecast in daily)
                    DailyForecasts.Add(forecast);
            }
            catch (Exception ex) {
                // エラーハンドリング
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
            }
            finally {
                IsLoading = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // シンプルなRelayCommandの実装
    public class RelayCommand : ICommand {
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Func<Task> execute, Func<bool> canExecute = null) {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();
        public async void Execute(object parameter) => await _execute();
    }
}