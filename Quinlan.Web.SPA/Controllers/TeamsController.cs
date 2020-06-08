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
    public class TeamsController : ControllerBase
    {
        private readonly ILogger<TeamsController> _logger;
        IApiService<TeamDTO> _teamsApiService;

        public TeamsController(ILogger<TeamsController> logger, IApiService<TeamDTO> teamsApiService)
        {
            _logger = logger;
            _teamsApiService = teamsApiService;
        }

        [HttpGet]
        public IEnumerable<TeamDTO> Get()
        {
            var teams = _teamsApiService.Get();

            return teams;
        }
        [HttpGet("{id}")]
        public TeamDTO Get(int id)
        {
            var team = _teamsApiService.Get(id);

            return team;
        }
    }
}
