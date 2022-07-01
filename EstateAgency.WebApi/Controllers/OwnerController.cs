using EstateAgency.Core.Models;
using EstateAgency.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EstateAgency.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerBL _bl;
        public OwnerController()
        {
            _bl = new OwnerBL();
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Owner>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public IActionResult GetOwners()
        {
            var owners = _bl.GetAllOwners();
            if(owners == null || !owners.Any())
                return NoContent();
            return Ok(owners);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Owner))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public IActionResult UpdateOwner([FromBody]Owner owner)
        {
            if (owner == null)
                return BadRequest();
            bool result = _bl.UpdateOwner(owner, out string errMsg);
            if (!result)
                return StatusCode(StatusCodes.Status500InternalServerError, errMsg);
            return Ok(owner);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Owner))]
        public IActionResult GetOwnerById(int id)
        {
            var owner = _bl.GetOwnerById(id);
            return Ok(owner);
        }
    }
}
