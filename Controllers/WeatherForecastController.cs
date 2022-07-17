using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPISample.Model;
using WebAPISample.Interface;
namespace WebAPISample.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private readonly IPrintMessage _pm;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IPrintMessage pm)
    {
        _pm = pm;
        _logger = logger;
    }

    [HttpGet("GetWeatherForecast")]
    public IEnumerable<WeatherForecast> GetWeatherForecast()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost("TestPost")]
    public string TestPost(dynamic req)
    {
        var jsonObj = JsonConvert.DeserializeObject<SamplePostModel>(req.ToString());
        Console.WriteLine("req:" + _pm.Print(jsonObj.data));
        return jsonObj.data;
    }
}
