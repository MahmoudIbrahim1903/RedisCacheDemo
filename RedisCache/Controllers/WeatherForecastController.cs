using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedisCache.Models;
using RedisCache.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedisCache.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public WeatherForecastController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksService.LoadBooks());
        }
    }
}
