using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WeatherAlertApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherAlertsController : ControllerBase
    {

        private readonly ILogger<WeatherAlertsController> _logger;
        private readonly IWeatherAlertService _weatherAlertService;

        public WeatherAlertsController(ILogger<WeatherAlertsController> logger,
            IWeatherAlertService weatherAlertService)
        {
            _logger = logger;
            this._weatherAlertService = weatherAlertService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherAlert>> Get()
        {
            return await _weatherAlertService.GetWeatherAlerts();
        }
    }
}
