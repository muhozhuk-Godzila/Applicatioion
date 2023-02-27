using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Xml.Linq;

namespace BackendAPI.Controllers
{
    public class WeatherData
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Degree { get; set; }
        public string Location { get; set; }
    }
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public static List<WeatherData> weatherDatas = new()
        {
            new WeatherData(){Id = 1, Date="21.12.2022", Degree=-10, Location= "лСПMANЯЙ"},
            new WeatherData(){Id = 2, Date="28.12.2022", Degree=-12, Location= "лСПMANЯЙ"},
            new WeatherData(){Id = 3, Date="04.01.2023", Degree=-6, Location= "лНЯЙБЮ"},
            new WeatherData(){Id = 4, Date="11.01.2023", Degree=0, Location= "лНЯЙБЮ"},
            new WeatherData(){Id = 5, Date="18.01.2023", Degree=3, Location= "лНЯЙБЮ"},
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(string? index = null)
        {
            if (weatherDatas.Count == 0)
            {
                return BadRequest("лхмгдпюб опедсопефдюер!!! яохянй осяр, хдхнр!!!");
            }
            if (index == null)
            {
                return Ok(weatherDatas);
            }
            int indx = int.Parse(index);
            if (indx >= 0)
            {
                for (int i = 0; i < weatherDatas.Count; i++)
                {
                    if (weatherDatas[i].Id == indx)
                    {
                        return Ok(weatherDatas[i]);
                    }
                }
            }
            return BadRequest("лхмгдпюб опедсопефдюер!!! юбрнп API - хдхнр!!!");
        }

        [HttpGet("Found")]
        public IActionResult GetFound(string LocationName)
        {
            int Count = 0;
            for (int i = 0; i < weatherDatas.Count; i++)
            {    
                if (weatherDatas[i].Location == LocationName)
                {
                    Count++;
                }
                
            } 
            if(Count > 0)
            {
                return Ok("лхмгдпюб србепфдюер!!! мюидемн " + Count + " онкэгнбюрекеи!!!");
            }
            else { return NotFound("лхмгдпюб опедсопефдюер!!! юбрнп API - хдхнр!!!"); }
        }


        [HttpPost]
        public IActionResult Add(WeatherData data)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == data.Id)
                {
                    return BadRequest("лхмгдпюб опедсопефдюер!!! щрнр NAME мебепмши, хдхнр!!!");
                }
            }
            weatherDatas.Add(data);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(WeatherData data)
        {
            if (data.Id < 0)
            {
                return BadRequest("лхмгдпюб опедсопефдюер!!! щрнр INDEX мебепмши, хдхнр!!!");
            }
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == data.Id)
                {
                    weatherDatas[i] = data;
                    return Ok();
                }
            }
            return BadRequest("лхмгдпюб опедсопефдюер!!! щрнр INDEX мебепмши, хдхнр!!!");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest("лхмгдпюб опедсопефдюер!!! щрнр INDEX мебепмши, хдхнр!!!");
            }
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == id)
                {
                    Summaries.RemoveAt(i);
                    return Ok();
                }
            }
            return BadRequest("лхмгдпюб опедсопефдюер!!! гюохяэ ме намюпсфемю, хдхнр!!!");
        }
    }
}
