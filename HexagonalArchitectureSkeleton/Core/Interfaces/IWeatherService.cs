using Core.Models;

namespace Core.Interfaces
{
    public interface IWeatherService
    {
        WeatherData GetWeatherData(string city);
    }
}
