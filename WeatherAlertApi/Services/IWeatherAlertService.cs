using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherAlertApi
{
    public interface IWeatherAlertService
    {
        Task<IEnumerable<WeatherAlert>> GetWeatherAlerts();
    }
}