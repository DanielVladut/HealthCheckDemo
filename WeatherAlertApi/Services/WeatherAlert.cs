using System;

namespace WeatherAlertApi
{
    public class WeatherAlert
    {
        public WeatherForecast Forecast { get; set; }

        public string AlertType { get; set; }

        public string Tip { get; set; }
    }
}
