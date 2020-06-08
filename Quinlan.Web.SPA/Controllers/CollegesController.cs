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
    public class CollegesController : ControllerBase
    {
        private readonly ILogger<CollegesController> _logger;
        IApiService<CollegeDTO> _collegesApiService;

        public CollegesController(ILogger<CollegesController> logger, IApiService<CollegeDTO> collegesApiService)
        {
            _logger = logger;
            _collegesApiService = collegesApiService;
        }

        [HttpGet]
        public IEnumerable<CollegeDTO> Get()
        {
            var colleges = _collegesApiService.Get();

            return colleges;
        }
        [HttpGet("{id}")]
        public CollegeDTO Get(int id)
        {
            var college = _collegesApiService.Get(id);

            return college;
        }
    }
}
