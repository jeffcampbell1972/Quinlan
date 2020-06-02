using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Quinlan.API.Models;
using Quinlan.API.Services;

namespace Quinlan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly ILogger<SportsController> _logger;
        IApiService<SportDTO> _sportsApiService;

        public SportsController(ILogger<SportsController> logger, IApiService<SportDTO> sportsApiService)
        {
            _logger = logger;
            _sportsApiService = sportsApiService;
        }

        [HttpGet]
        public IEnumerable<SportDTO> Get()
        {
            var sports = _sportsApiService.Get();

            return sports;
        }
        [HttpGet("{id}")]
        public SportDTO Get(int id)
        {
            var sport = _sportsApiService.Get(id);

            return sport;
        }
    }
}
