using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherAlertApi
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecast>> GetForecasts();
    }
}