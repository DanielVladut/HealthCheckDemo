using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WeathterTipsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherTipsController : ControllerBase
    {

        private readonly ILogger<WeatherTipsController> _logger;

        public WeatherTipsController(ILogger<WeatherTipsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherTip> Get()
        {
            return new WeatherTip[]
            {
               new WeatherTip
               {
                   Weather = "Storm",
                   Tip = "Sports Channel ABC"
               },

               new WeatherTip
               {
                   Weather = "Hot",
                   Tip = "Super Drink"
               },

               new WeatherTip
               {
                   Weather = "Sunny",
                   Tip = "Super Suncreme"
               }
            };
        }
    }
}
