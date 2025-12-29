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
        var user = _db.Users.Immediate.FindOne(f => true);
        if (user == null)
        {
            _db.Users.Immediate.Insert(new User()
            {
                Name = "张三",
                Email = "wyspaces@outlook.com",
                Password = "asdlkfjaldk"
            });
        }

        var userLinq = await _db.Users.FirstOrDefaultAsync(f => f.Name == "李四");
 

        userLinq.Name = "李四";

        await _db.SaveChangesAsync();




        var query = from u in _db.Users
                    where u.Name != null && u.Name.Contains("张")
                    select u;
        
        var list = _db.Users.Where(u => u.Name != null && u.Name.Contains("张")).ToList();

        await foreach (var item in _db.Users.Immediate.FindAllAsync())
        {
            var r = await _db.Users.Immediate.FindOneAsync(item.Id);
        }

        var dataBase = _db.Database;

        var count1 = await _db.Users.Immediate.CountDocumentsAsync(_ => true);
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