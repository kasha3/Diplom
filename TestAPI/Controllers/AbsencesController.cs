using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/v1/absences")]
    [ApiController]
    public class AbsencesController : ControllerBase
    {
        private readonly AppDbContext _db;
        public AbsencesController(AppDbContext db) {  _db = db; }

        /// <summary>
        /// Получить список прогулов
        /// </summary>
        /// <returns>Список прогулов</returns>
        [HttpGet]
        public IActionResult GetAbsences()
        {
            return Ok(_db.absences.ToList());
        }

        /// <summary>
        /// Создать новый прогул
        /// </summary>
        /// <param name="abs">Прогул</param>
        /// <returns>Новый прогул</returns>
        [HttpPost]
        public IActionResult PostAbsences([FromBody] Absences abs)
        {
            if (abs == null)
            {
                return BadRequest("Invalid data.");
            }
            try
            {
                _db.absences.Add(abs);
                _db.SaveChanges();

                return Ok(abs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Редактировать прогул
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="updatedAbsence">Отредактируйте прогул</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateAbsences(int id, [FromBody] Absences updatedAbsence)
        {
            if (updatedAbsence == null || id != updatedAbsence.Id)
            {
                return BadRequest("Invalid data.");
            }

            var absence = _db.absences.Find(id);
            if (absence == null)
            {
                return NotFound("Absence not found.");
            }

            absence.EmployeeId = updatedAbsence.EmployeeId;
            absence.StartDate = updatedAbsence.StartDate;
            absence.EndDate = updatedAbsence.EndDate;
            absence.Type = updatedAbsence.Type;
            absence.Description = updatedAbsence.Description;
            absence.Paid = updatedAbsence.Paid;

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
