using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing;
using WeatherInfoApi.Models;

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
        public IActionResult Weatherinfo(string name1)
        {
            string name;
            foreach(var weather in weatherList)
            {
                name = weather.Name;
                if(name1 == name)
                {
                    return Ok(weather.degree);   
                }
                else if (name1 == weather.Name)
                {
                    return Ok(weather.degree);
                }
                

            }

            return Ok(20);
        }

       
    }
  }