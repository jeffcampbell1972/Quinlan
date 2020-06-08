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
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        IApiService<PersonDTO> _peopleApiService;

        public PeopleController(ILogger<PeopleController> logger, IApiService<PersonDTO> peopleApiService)
        {
            _logger = logger;
            _peopleApiService = peopleApiService;
        }

        [HttpGet]
        public IEnumerable<PersonDTO> Get()
        {
            var people = _peopleApiService.Get();

            return people;
        }
        [HttpGet("{id}")]
        public PersonDTO Get(int id)
        {
            var person = _peopleApiService.Get(id);

            return person;
        }
    }
}
