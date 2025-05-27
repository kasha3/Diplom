using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/v1/positions")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public PositionsController(AppDbContext db) {  _db = db; }

        [HttpGet]
        public IActionResult GetPositions() { return Ok(_db.positions.ToList()); }

        [HttpPost]
        public IActionResult PostPosition([FromBody] Position position)
        {
            if (position == null)
            {
                return BadRequest("Invalid data");
            }
            try
            {
                _db.positions.Add(position);
                _db.SaveChanges();

                return Ok(position);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePosition(int id, [FromBody] Position updatedPosition)
        {
            if (updatedPosition == null || id != updatedPosition.Id)
            {
                return BadRequest("Invalid data.");
            }
            var position = _db.positions.Find(id);
            if (position == null)
            {
                return NotFound("Position not found");
            }
            position.DepartamentId = updatedPosition.DepartamentId;
            position.Name = updatedPosition.Name;
            try
            {
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
