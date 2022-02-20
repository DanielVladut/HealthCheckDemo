using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherAlertApi
{
    public class WeatherTipsService : IWeatherTipsService
    {
        private readonly HttpClient _httpClient;

        public WeatherTipsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:51955/");
            _httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        }

        public async Task<IEnumerable<WeatherTip>> GetTips()
        {
            var response = await _httpClient.GetAsync("WeatherTips");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<WeatherTip>>(responseStream);
        }
    }
}
