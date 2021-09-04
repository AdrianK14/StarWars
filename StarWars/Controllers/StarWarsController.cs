using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StarWars.Contracts.Factory;
using StarWars.Contracts.Repositories;
using StarWars.Extensions;
using StarWars.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StarWars.Controllers
{
    [ApiController]
    public class StarWarsController : ControllerBase
    {
        private readonly ILogger<StarWarsController> _logger;
        private readonly IRetrievePersonInfoCommandFactory _retrievePersonInfoCommandFactory;

        public StarWarsController(ILogger<StarWarsController> logger, IRetrievePersonInfoCommandFactory retrievePersonInfoCommandFactory)
        {
            _logger = logger;
            _retrievePersonInfoCommandFactory = retrievePersonInfoCommandFactory;
        }

        [HttpGet]
        [Route("person/{personName}")]
        public IActionResult GetPersonInfo(string personName)
        {
            try
            {
                return Ok(_retrievePersonInfoCommandFactory.Create(personName).Execute());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Błąd podczas pobierania informacji o {personName}: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
