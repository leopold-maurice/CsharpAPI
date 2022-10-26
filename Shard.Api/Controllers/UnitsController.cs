using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shard.Api.model;
using System.Text.RegularExpressions;

namespace Shard.Api.Controllers
{
    [ApiController]
    [Route("/users/{id}/[controller]")]
    [Produces("application/json")]
    public class UnitsController : ControllerBase
    {
        private List<User> _users;
        public UnitsController(List<User> user)
        {
            _users = user;
        }

        [HttpGet]
        public ActionResult<List<Unit>> getUnitsByUser(string id)
        {
            foreach(User u in _users)
            {
                if(u.id == id)
                {
                    return u.units;
                }
            }
            return NotFound();
        }
        [HttpGet("{unitId}")]
        public ActionResult<Unit> getUnitById(string id, string unitId)
        {
            foreach (User u in _users)
            {
                if (u.id == id)
                {
                    foreach(Unit unit in u.units)
                    {
                        if(unit.id == unitId)
                        {
                            return unit;
                        }
                    }
                }
            }
            return NotFound();
        }

        [HttpPut("{unitId}")]
        public ActionResult<Unit> ChangeScoutDestination(string id, string unitId, [FromBody] Unit unitWithModification)
        {
            foreach (User u in _users)
            {
                if (u.id == id)
                {
                    foreach (Unit unit in u.units)
                    {
                        if (unit.id == unitId)
                        {
                            unit.ChangeDestination(unitWithModification.system, unitWithModification.planet);
                            return unit;
                        }
                    }
                }
            }
            return NotFound();
        }

        [HttpGet("{unitId}/location")]
        public ActionResult<UnitLocation> getUnitLocation(string id, string unitId)
        {
            foreach (User u in _users)
            {
                if (u.id == id)
                {
                    foreach (Unit unit in u.units)
                    {
                        if (unit.id == unitId)
                        {
                            return unit.location;
                        }
                    }
                }
            }
            return NotFound();
        }

    }
}
