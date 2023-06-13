using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class WeatherService : IWeatherService
    {
        public WeatherData GetWeatherData(string city)
        {
            // Lógica para obtener datos climáticos de una fuente externa
            // Por simplicidad, este ejemplo devuelve datos simulados
            return new WeatherData
            {
                City = city,
                Temperature = 25.0f,
                Description = "Sunny"
            };
        }
    }
}
