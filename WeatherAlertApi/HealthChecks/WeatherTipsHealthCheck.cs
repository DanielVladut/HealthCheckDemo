using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherAlertApi.HealthChecks
{
    public class WeatherTipsHealthCheck : IHealthCheck
    {
        private readonly IWeatherTipsService _weatherTipsService;

        public WeatherTipsHealthCheck(IWeatherTipsService weatherTipsService)
        {
            this._weatherTipsService = weatherTipsService;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                await _weatherTipsService.GetTips();
                return  HealthCheckResult.Healthy();
            }
            catch
            {
                // log ...
                return HealthCheckResult.Degraded("can't make extra bucks...");
            }
        }
    }
}
