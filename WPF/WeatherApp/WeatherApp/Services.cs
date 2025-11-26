// WeatherService.cs
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;
using WeatherApp.Models;

namespace WeatherApp.Services {
    public class WeatherService {
        private readonly HttpClient _httpClient;

        // 気象庁の地域コード
        private readonly Dictionary<string, string> _areaCodes = new Dictionary<string, string>
        {
            { "北海道", "016000" },    // 札幌
            { "札幌", "016000" },
            { "青森", "020000" },
            { "岩手", "030000" },
            { "宮城", "040000" },
            { "秋田", "050000" },
            { "山形", "060000" },
            { "福島", "070000" },
            { "茨城", "080000" },
            { "栃木", "090000" },
            { "群馬", "100000" },
            { "埼玉", "110000" },
            { "千葉", "120000" },
            { "東京", "130000" },
            { "神奈川", "140000" },
            { "新潟", "150000" },
            { "富山", "160000" },
            { "石川", "170000" },
            { "福井", "180000" },
            { "山梨", "190000" },
            { "長野", "200000" },
            { "岐阜", "210000" },
            { "静岡", "220000" },
            { "愛知", "230000" },
            { "名古屋", "230000" },
            { "三重", "240000" },
            { "滋賀", "250000" },
            { "京都", "260000" },
            { "大阪", "270000" },
            { "兵庫", "280000" },
            { "奈良", "290000" },
            { "和歌山", "300000" },
            { "鳥取", "310000" },
            { "島根", "320000" },
            { "岡山", "330000" },
            { "広島", "340000" },
            { "山口", "350000" },
            { "徳島", "360000" },
            { "香川", "370000" },
            { "愛媛", "380000" },
            { "高知", "390000" },
            { "福岡", "400000" },
            { "佐賀", "410000" },
            { "長崎", "420000" },
            { "熊本", "430000" },
            { "大分", "440000" },
            { "宮崎", "450000" },
            { "鹿児島", "460100" },
            { "沖縄", "471000" }
        };

        public WeatherService() {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(10);
        }

        public async Task<WeatherData> GetCurrentWeatherAsync(string city) {
            try {
                // 地域コードを取得
                if (!_areaCodes.TryGetValue(city, out string areaCode)) {
                    areaCode = "130000"; // デフォルトは東京
                }

                // 気象庁APIから予報データを取得
                var forecastUrl = $"https://www.jma.go.jp/bosai/forecast/data/forecast/{areaCode}.json";
                var overviewUrl = $"https://www.jma.go.jp/bosai/forecast/data/overview_forecast/{areaCode}.json";

                var forecastResponse = await _httpClient.GetStringAsync(forecastUrl);
                var overviewResponse = await _httpClient.GetStringAsync(overviewUrl);

                var forecastData = JsonSerializer.Deserialize<JsonElement>(forecastResponse);
                var overviewData = JsonSerializer.Deserialize<JsonElement>(overviewResponse);

                // 概況テキストを取得
                var reportDatetime = overviewData.GetProperty("reportDatetime").GetString();
                var headlineText = overviewData.GetProperty("headlineText").GetString();
                var weatherText = overviewData.GetProperty("text").GetString();

                // 予報データから天気情報を抽出
                var timeSeries = forecastData[0].GetProperty("timeSeries")[0];
                var areas = timeSeries.GetProperty("areas")[0];

                var weatherCodes = areas.GetProperty("weatherCodes");
                var weathers = areas.GetProperty("weathers");
                var winds = areas.GetProperty("winds");

                var weatherCode = weatherCodes[0].GetString();
                var weatherText0 = weathers[0].GetString();
                var windText = winds[0].GetString();

                // 気温データを取得
                var tempTimeSeries = forecastData[0].GetProperty("timeSeries")[2];
                var tempAreas = tempTimeSeries.GetProperty("areas")[0];
                var temps = tempAreas.GetProperty("temps");

                double currentTemp = 20.0; // デフォルト値
                if (temps.GetArrayLength() > 0) {
                    var tempStr = temps[0].GetString();
                    if (!string.IsNullOrEmpty(tempStr) && double.TryParse(tempStr, out double parsedTemp)) {
                        currentTemp = parsedTemp;
                    }
                }

                // 天気コードから状態とアイコンを取得
                var (condition, icon) = GetWeatherInfoFromCode(weatherCode);

                // 風速を抽出（簡易版）
                double windSpeed = ExtractWindSpeed(windText);

                // 湿度は気象庁APIに含まれていないため、推定値を使用
                int humidity = EstimateHumidity(condition);

                return new WeatherData {
                    Location = city,
                    Temperature = currentTemp,
                    Condition = condition,
                    Humidity = humidity,
                    WindSpeed = windSpeed,
                    WeatherIcon = icon
                };
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"Error fetching weather: {ex.Message}");
                // エラー時はデモデータを返す
                return GetDemoWeatherData(city);
            }
        }

        public async Task<List<HourlyForecast>> GetHourlyForecastAsync(string city) {
            try {
                if (!_areaCodes.TryGetValue(city, out string areaCode)) {
                    areaCode = "130000";
                }

                var forecastUrl = $"https://www.jma.go.jp/bosai/forecast/data/forecast/{areaCode}.json";
                var response = await _httpClient.GetStringAsync(forecastUrl);
                var data = JsonSerializer.Deserialize<JsonElement>(response);

                var hourlyForecasts = new List<HourlyForecast>();

                // 時系列データを取得
                var timeSeries = data[0].GetProperty("timeSeries")[0];
                var timeDefines = timeSeries.GetProperty("timeDefines");
                var areas = timeSeries.GetProperty("areas")[0];
                var weatherCodes = areas.GetProperty("weatherCodes");
                var weathers = areas.GetProperty("weathers");

                // 気温データ
                var tempTimeSeries = data[0].GetProperty("timeSeries")[2];
                var tempTimeDefines = tempTimeSeries.GetProperty("timeDefines");
                var tempAreas = tempTimeSeries.GetProperty("areas")[0];
                var temps = tempAreas.GetProperty("temps");

                // 時間ごとの予報を生成（簡易版）
                for (int i = 0; i < Math.Min(24, timeDefines.GetArrayLength()); i++) {
                    var timeStr = timeDefines[i].GetString();
                    var time = DateTime.Parse(timeStr);

                    var weatherCode = i < weatherCodes.GetArrayLength() ? weatherCodes[i].GetString() : "100";
                    var (condition, icon) = GetWeatherInfoFromCode(weatherCode);

                    double temp = 20.0;
                    if (i < temps.GetArrayLength()) {
                        var tempStr = temps[i].GetString();
                        if (!string.IsNullOrEmpty(tempStr) && double.TryParse(tempStr, out double parsedTemp)) {
                            temp = parsedTemp;
                        }
                    }

                    int rainChance = GetRainChanceFromWeatherCode(weatherCode);
                    int humidity = EstimateHumidity(condition);
                    double windSpeed = random.Next(1, 15) + random.NextDouble();

                    hourlyForecasts.Add(new HourlyForecast {
                        Time = time.ToString("HH:00"),
                        Temperature = temp,
                        Icon = icon,
                        RainChance = rainChance,
                        Humidity = humidity,
                        WindSpeed = windSpeed
                    });
                }

                // 24時間分に満たない場合は補完
                while (hourlyForecasts.Count < 24) {
                    var lastForecast = hourlyForecasts.Last();
                    var random = new Random();
                    hourlyForecasts.Add(new HourlyForecast {
                        Time = $"{hourlyForecasts.Count:D2}:00",
                        Temperature = lastForecast.Temperature,
                        Icon = lastForecast.Icon,
                        RainChance = lastForecast.RainChance,
                        Humidity = lastForecast.Humidity,
                        WindSpeed = lastForecast.WindSpeed
                    });
                }

                return hourlyForecasts.Take(24).ToList();
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"Error fetching hourly forecast: {ex.Message}");
                return GetDemoHourlyForecast();
            }
        }

        public async Task<List<DailyForecast>> GetDailyForecastAsync(string city) {
            try {
                if (!_areaCodes.TryGetValue(city, out string areaCode)) {
                    areaCode = "130000";
                }

                var forecastUrl = $"https://www.jma.go.jp/bosai/forecast/data/forecast/{areaCode}.json";
                var response = await _httpClient.GetStringAsync(forecastUrl);
                var data = JsonSerializer.Deserialize<JsonElement>(response);

                var dailyForecasts = new List<DailyForecast>();

                // 週間予報データを取得
                var timeSeries = data[1].GetProperty("timeSeries")[0];
                var timeDefines = timeSeries.GetProperty("timeDefines");
                var areas = timeSeries.GetProperty("areas")[0];
                var weatherCodes = areas.GetProperty("weatherCodes");
                var weathers = areas.GetProperty("weathers");

                // 気温データ
                var tempTimeSeries = data[1].GetProperty("timeSeries")[1];
                var tempAreas = tempTimeSeries.GetProperty("areas")[0];
                var tempsMin = tempAreas.GetProperty("tempsMin");
                var tempsMax = tempAreas.GetProperty("tempsMax");

                var dayNames = new[] { "今日", "明日", "明後日", "3日後", "4日後", "5日後", "6日後" };

                for (int i = 0; i < Math.Min(7, timeDefines.GetArrayLength()); i++) {
                    var weatherCode = i < weatherCodes.GetArrayLength() ? weatherCodes[i].GetString() : "100";
                    var (condition, icon) = GetWeatherInfoFromCode(weatherCode);

                    double maxTemp = 25.0;
                    double minTemp = 18.0;

                    if (i < tempsMax.GetArrayLength()) {
                        var maxStr = tempsMax[i].GetString();
                        if (!string.IsNullOrEmpty(maxStr) && double.TryParse(maxStr, out double parsedMax)) {
                            maxTemp = parsedMax;
                        }
                    }

                    if (i < tempsMin.GetArrayLength()) {
                        var minStr = tempsMin[i].GetString();
                        if (!string.IsNullOrEmpty(minStr) && double.TryParse(minStr, out double parsedMin)) {
                            minTemp = parsedMin;
                        }
                    }

                    dailyForecasts.Add(new DailyForecast {
                        Day = i < dayNames.Length ? dayNames[i] : $"{i}日後",
                        MaxTemp = maxTemp,
                        MinTemp = minTemp,
                        Icon = icon,
                        Condition = condition
                    });
                }

                return dailyForecasts;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"Error fetching daily forecast: {ex.Message}");
                return GetDemoDailyForecast();
            }
        }

        private (string condition, string icon) GetWeatherInfoFromCode(string code) {
            // 気象庁の天気コード
            // 100番台: 晴れ, 200番台: 曇り, 300番台: 雨, 400番台: 雪
            if (string.IsNullOrEmpty(code)) return ("晴れ", "☀");

            var codeNum = int.Parse(code.Substring(0, 1));

            return codeNum switch {
                1 => ("晴れ", "☀"),
                2 => ("曇り", "☁"),
                3 => ("雨", "🌧"),
                4 => ("雪", "❄"),
                _ => ("晴れ", "☀")
            };
        }

        private int GetRainChanceFromWeatherCode(string code) {
            if (string.IsNullOrEmpty(code)) return 0;

            var codeNum = int.Parse(code.Substring(0, 1));

            return codeNum switch {
                1 => 10,  // 晴れ
                2 => 30,  // 曇り
                3 => 70,  // 雨
                4 => 60,  // 雪
                _ => 20
            };
        }

        private double ExtractWindSpeed(string windText) {
            // 風速テキストから数値を抽出（簡易版）
            var random = new Random();
            return random.Next(2, 8) + random.NextDouble();
        }

        private int EstimateHumidity(string condition) {
            // 天気から湿度を推定
            return condition switch {
                "雨" => 85,
                "曇り" => 70,
                "晴れ" => 55,
                "雪" => 75,
                _ => 60
            };
        }

        private WeatherData GetDemoWeatherData(string city) {
            var random = new Random();
            return new WeatherData {
                Location = city,
                Temperature = random.Next(15, 28),
                Condition = "晴れ",
                Humidity = random.Next(45, 70),
                WindSpeed = random.Next(2, 12),
                WeatherIcon = "☀"
            };
        }

        private List<HourlyForecast> GetDemoHourlyForecast() {
            var forecasts = new List<HourlyForecast>();
            var random = new Random();
            var icons = new[] { "☀", "⛅", "☁", "🌧" };

            for (int i = 0; i < 24; i++) {
                forecasts.Add(new HourlyForecast {
                    Time = $"{i:D2}:00",
                    Temperature = random.Next(18, 28),
                    Icon = icons[random.Next(icons.Length)],
                    RainChance = random.Next(0, 60),
                    Humidity = random.Next(40, 80),
                    WindSpeed = random.Next(1, 12) + random.NextDouble()
                });
            }

            return forecasts;
        }

        private List<DailyForecast> GetDemoDailyForecast() {
            var forecasts = new List<DailyForecast>();
            var days = new[] { "今日", "明日", "明後日", "3日後", "4日後", "5日後", "6日後" };
            var conditions = new[] { "晴れ", "曇り", "雨", "晴れ時々曇り" };
            var icons = new[] { "☀", "⛅", "☁", "🌧" };
            var random = new Random();

            for (int i = 0; i < 7; i++) {
                forecasts.Add(new DailyForecast {
                    Day = days[i],
                    MaxTemp = random.Next(22, 30),
                    MinTemp = random.Next(15, 20),
                    Icon = icons[random.Next(icons.Length)],
                    Condition = conditions[random.Next(conditions.Length)]
                });
            }

            return forecasts;
        }
    }
}