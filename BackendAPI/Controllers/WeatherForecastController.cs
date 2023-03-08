using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly List<string> Summaries = new()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll(int? sortStrategy = null)
        {
            switch (sortStrategy)
            {
                case null:
                    {
                        return Ok(Summaries);
                        break;
                    }
                case 1:
                    {
                        return Ok(Summaries.OrderBy(el => el).ToList());
                        break;
                    }
                case -1:
                    {
                        return Ok(Summaries.OrderByDescending(el => el).ToList());
                        break;
                    }
                default:
                    {
                        BadRequest("Invalid Sort Strategy!");
                        break;
                    }
            }

            return BadRequest("Invalid Sort Strategy!");
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }


        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count) return BadRequest("Invalid Index!");

            Summaries[index] = name;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count) return BadRequest("Invalid Index!");

            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("{index}")]
        public IActionResult GetNameByIndex(int index)
        {
            if (index < 0 || index >= Summaries.Count) return BadRequest("Invalid Index!");

            return Ok(Summaries[index]);
        }

        [HttpGet("find-by-name")]
        public IActionResult GetCountOfName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return BadRequest("Invalid Name!");

            return Ok(Summaries.Where(el => el == name).Count());
        }
    }
}