using Adapters.Interfaces;
using Adapters.Services;
using Core.Interfaces;
using Core.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios del núcleo
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IWeatherServicePort, WeatherServiceAdapter>();

var app = builder.Build();

// Configurar el punto final de la API
app.MapGet("/api/weather/{city}", async (HttpContext context, IWeatherServicePort weatherService) =>
{
    var city = context.Request.RouteValues["city"] as string;
    var weatherData = weatherService.GetWeatherData(city);

    // Convertir el objeto WeatherData a JSON y devolverlo en la respuesta HTTP
    var response = JsonSerializer.Serialize(weatherData);
    await context.Response.WriteAsync(response);
});

app.Run();
