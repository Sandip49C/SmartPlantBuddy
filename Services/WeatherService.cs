using System.Net.Http.Json;

namespace SmartPlantBuddy.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _http = new();

        public async Task<string> GetCurrentWeatherAsync()
        {
            try
            {
                var location = await Geolocation.GetLocationAsync();
                if (location == null)
                    return "Weather unavailable";

                var url = $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&current=temperature_2m,relative_humidity_2m";
                var data = await _http.GetFromJsonAsync<OpenMeteoResponse>(url);
                return $"{data?.current?.temperature_2m}°C, {data?.current?.relative_humidity_2m}% humidity";
            }
            catch { return "Weather unavailable"; }
        }
    }

    public class OpenMeteoResponse
    {
        public CurrentWeather? current { get; set; }
    }

    public class CurrentWeather
    {
        public double temperature_2m { get; set; }
        public int relative_humidity_2m { get; set; }
    }
}