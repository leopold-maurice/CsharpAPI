using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shard.Api.model;
using Shard.Shared.Core;
using System.IO.Enumeration;

namespace Shard.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class SystemsController : ControllerBase
    {
        private readonly Sector _sector;
        public SystemsController(Sector sector)
        {
            _sector = sector;
        }

        [HttpGet]
        public ActionResult<List<StarSystem>> GetAllSystems()
        {
            return _sector.Systems;
        }

        [HttpGet("{systemName}")]
        public ActionResult<StarSystem> getSystem(string systemName)
        {
            foreach (StarSystem system in _sector.Systems)
            {
                if (system.Name == systemName)
                {
                    return system;
                }
            }
            return BadRequest();
        }

        [HttpGet("{systemName}/planets")]
        public ActionResult<List<Planet>> getPlanetsOfSystem(string systemName)
        {
            foreach (StarSystem system in _sector.Systems)
            {
                if (system.Name == systemName)
                {
                    return system.Planets;
                }
            }
            return BadRequest();

        }

        [HttpGet("{systemName}/planets/{planetName}")]
        public ActionResult<Planet> getPlanet(string systemName,string planetName)
        {
            foreach (StarSystem system in _sector.Systems)
            {
                if (system.Name == systemName)
                {
                    foreach(Planet planet in system.Planets)
                    {
                        if(planet.Name == planetName)
                        {
                            return planet;
                        }
                    }
                }
            }
            return BadRequest();
        }
    }
}
