using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherAlertApi
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:51948/");
            _httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        }

        public async Task<IEnumerable<WeatherForecast>> GetForecasts()
        {
            var response = await _httpClient.GetAsync("WeatherForecast");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<WeatherForecast>>(responseStream);
        }
    }

}

