using Adapters.Interfaces;
using Core.Interfaces;
using Core.Models;

namespace Adapters.Services
{
    public class WeatherServiceAdapter : IWeatherServicePort
    {
        private readonly IWeatherService _weatherService;

        public WeatherServiceAdapter(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public WeatherData GetWeatherData(string city)
        {
            // Adaptador que utiliza el servicio de clima del núcleo
            return _weatherService.GetWeatherData(city);
        }
    }
}
