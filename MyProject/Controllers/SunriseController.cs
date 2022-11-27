using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using NPoco.fastJSON;
using System.Text.Json;

namespace MyProject.Controllers
{
    public class SunriseController : Controller
    {
        [HttpGet]
        public async void Index()
        {
            const string SunriseSunsetServiceUrl = "https://api.sunrise-sunset.org";
            var query = $"{SunriseSunsetServiceUrl}/json?lat=50.93&lng=5.33&date=today";
          
            var client = new HttpClient();
            var json = await client.GetStringAsync(query);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<SunriseData>(json, options);
            
        }
    }
}
