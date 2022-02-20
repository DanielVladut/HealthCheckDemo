using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherAlertApi
{
    public interface IWeatherTipsService
    {
        Task<IEnumerable<WeatherTip>> GetTips();
    }
}