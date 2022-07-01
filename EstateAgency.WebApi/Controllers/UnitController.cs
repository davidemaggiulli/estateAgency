using EstateAgency.Core.Models;
using EstateAgency.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateAgency.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UnitController : ControllerBase
    {
        private readonly IUnitBL _bl;
        public UnitController()
        {
            _bl = new UnitBL();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Unit>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllUnits()
        {
            var units = await _bl.GetAllUnitsAsync();
            if(units == null || !units.Any())
                return NoContent();
            return Ok(units);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public IActionResult CreateUnit([FromBody] Unit unit)
        {
            if (unit == null)
                return BadRequest();
            var result = _bl.InsertUnit(unit, out string err);
            if (!result)
                return StatusCode(StatusCodes.Status500InternalServerError, err);
            return Ok();
        }
    }
}
