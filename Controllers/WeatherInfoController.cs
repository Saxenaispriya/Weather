using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing;
using WeatherInfoApi.Models;
using System.Net.Http;
using System.Text.Json;


namespace WeatherInfoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherInfoController : ControllerBase
    {
       List<Weather> weatherList;

        public WeatherInfoController()
        {
            weatherList = new List<Weather>();
            weatherList.Add(new Weather { Name="India",degree=40});
            weatherList.Add(new Weather { Name = "Canada", degree = 10 });
        }

        [HttpGet]
        public async Task<IActionResult> WeatherinfoAsync(double lon,double lat)
        {

            var apikey = "d0019d247e30fabc42dc43cab0e5fb31";
            var endpoint = "https://api.openweathermap.org/data/2.5/weather";
            var url =string.Format("{0}?lat={1}&lon={2}&appid={3}",endpoint,lat,lon,apikey);


            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode(); // Throw an exception if error

            var body = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(body);

            return Ok(body);
        }

       
    }
  }