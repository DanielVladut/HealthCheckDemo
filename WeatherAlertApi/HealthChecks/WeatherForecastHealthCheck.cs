using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherAlertApi.HealthChecks
{
    public class WeatherForecastHealthCheck : IHealthCheck
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastHealthCheck(IWeatherForecastService weatherForecastService)
        {
            this._weatherForecastService = weatherForecastService;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                await _weatherForecastService.GetForecasts();
                return HealthCheckResult.Healthy();
            }
            catch
            {
                // log ...
                return HealthCheckResult.Unhealthy("forecast service not callable");
            }
        }
    }
}
