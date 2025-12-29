using MongoDB.Driver;
using Apteryx.WebApi.Data;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Linq;

namespace Apteryx.WebApi.Controllers;

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
    public WeatherForecastController(ILogger<WeatherForecastController> logger, ApteryxDbContext context)
    {
        _logger = logger;
        _db = context;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var user = _db.Users.Commands.FindOne(f => true);
        if (user == null)
        {
            _db.Users.Commands.Insert(new User()
            {
                Name = "张三",
                Email = "wyspaces@outlook.com",
                Password = "asdlkfjaldk"
            });
        }

        var userLinq = await _db.Users.FirstOrDefaultAsync(f => f.Name == "赵六");

        if (userLinq == null)
        {
            userLinq = new User()
            {
                Name = "李四",
                Email = "wyspaces@outlook.com",
                Password = "asdlkfjaldk"
            };

            _db.Users.Add(userLinq);
        }

        userLinq.Name = "赵六1";
        _db.Users.Update(userLinq);

        await _db.CommitCommandsAsync();




        var query = from u in _db.Users
                    where u.Name != null && u.Name.Contains("张")
                    select u;

        var list = _db.Users.Where(u => u.Name != null && u.Name.Contains("张")).ToList();

        await foreach (var item in _db.Users.Commands.FindAllAsync())
        {
            var r = await _db.Users.Commands.FindOneAsync(item.Id);
        }

        var dataBase = _db.Database;

        var count1 = await _db.Users.Commands.CountDocumentsAsync(_ => true);
        var count2 = await _db.Users.Native.CountDocumentsAsync(_ => true);

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}