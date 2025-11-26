// WeatherData.cs
using System;
using System.ComponentModel;

namespace WeatherApp.Models {
    public class WeatherData : INotifyPropertyChanged {
        private string _location;
        private double _temperature;
        private string _condition;
        private int _humidity;
        private double _windSpeed;
        private string _weatherIcon;

        public string Location {
            get => _location;
            set { _location = value; OnPropertyChanged(nameof(Location)); }
        }

        public double Temperature {
            get => _temperature;
            set { _temperature = value; OnPropertyChanged(nameof(Temperature)); }
        }

        public string Condition {
            get => _condition;
            set { _condition = value; OnPropertyChanged(nameof(Condition)); }
        }

        public int Humidity {
            get => _humidity;
            set { _humidity = value; OnPropertyChanged(nameof(Humidity)); }
        }

        public double WindSpeed {
            get => _windSpeed;
            set { _windSpeed = value; OnPropertyChanged(nameof(WindSpeed)); }
        }

        public string WeatherIcon {
            get => _weatherIcon;
            set { _weatherIcon = value; OnPropertyChanged(nameof(WeatherIcon)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class HourlyForecast {
        public string Time { get; set; }
        public double Temperature { get; set; }
        public string Icon { get; set; }
        public int RainChance { get; set; }
        public int Humidity { get; set; }        // 追加
        public double WindSpeed { get; set; }    // 追加
    }

    public class DailyForecast {
        public string Day { get; set; }
        public double MaxTemp { get; set; }
        public double MinTemp { get; set; }
        public string Icon { get; set; }
        public string Condition { get; set; }
    }
}