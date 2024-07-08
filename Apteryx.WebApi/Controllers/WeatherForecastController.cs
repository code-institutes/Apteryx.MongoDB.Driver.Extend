using Apteryx.WebApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace Apteryx.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApteryxDbContext _db;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,ApteryxDbContext context)
        {
            _logger = logger;
            _db = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var user = _db.Users.FindOne(f => true);
            if (user == null)
            {
                _db.Users.Add(new User()
                {
                    Name = "ÕÅÈý",
                    Email = "wyspaces@outlook.com",
                    Password = "asdlkfjaldk"
                });
            }

            await foreach (var item in _db.Users.FindAllAsync())
            {
                var r = await _db.Users.FindOneAsync(item.Id);
            }

            var count = await _db.Users.CountDocumentsAsync(_=>true);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}