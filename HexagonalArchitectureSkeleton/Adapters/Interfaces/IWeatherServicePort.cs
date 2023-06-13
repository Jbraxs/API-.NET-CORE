using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.Interfaces
{
    public interface IWeatherServicePort
    {
        WeatherData GetWeatherData(string city);
    }
}
