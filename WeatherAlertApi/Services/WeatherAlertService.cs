using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherAlertApi
{
    public class WeatherAlertService : IWeatherAlertService
    {
        private readonly IWeatherForecastService forecastService;
        private readonly IWeatherTipsService weatherTipsService;

        public WeatherAlertService(IWeatherForecastService forecastService,
            IWeatherTipsService weatherTipsService)
        {
            this.forecastService = forecastService;
            this.weatherTipsService = weatherTipsService;
        }

        public async Task<IEnumerable<WeatherAlert>> GetWeatherAlerts()
        {
            var forecasts = await forecastService.GetForecasts();

            var tips = await TryGetTips();

            return Combine(forecasts, tips);
        }

        private IEnumerable<WeatherAlert> Combine(IEnumerable<WeatherForecast> forecasts, IEnumerable<WeatherTip> tips)
        {
            var alerts = new List<WeatherAlert>();

            foreach (var forecast in forecasts)
            {
                var tip = tips.FirstOrDefault(t => t.Weather == forecast.Summary);

                alerts.Add(
                    new WeatherAlert
                    {
                        AlertType = GetAlertType(forecast.Summary),
                        Forecast = forecast,
                        Tip = tip?.Tip
                    });

            }

            return alerts;
        }

        private string GetAlertType(string summary)
        {
            if (summary == "Storm" || summary == "Huricane")
                return "Red";
            return "Normal";
        }

        private async Task<IEnumerable<WeatherTip>> TryGetTips()
        {
            try
            {
                return await weatherTipsService.GetTips();
            }
            catch (Exception ex)
            {

                return Enumerable.Empty<WeatherTip>();
            }
        }
    }

}

