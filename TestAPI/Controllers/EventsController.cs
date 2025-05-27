using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/v1/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public EventsController(AppDbContext db) { _db = db; }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = _db.events.Select(
                e => new
                {
                    e.Id,
                    e.Name,
                    Date = _db.events.FirstOrDefault(x => x.Id == e.Id).Date.ToString("dd.MM.yyyy"),
                    AuthorName = _db.employees
                    .Where(emp => emp.Id == e.AuthorId).Select(emp => emp.FullName).FirstOrDefault() ?? "Invalid Author",
                    e.Description
                });
            return Ok(events);
        }

        [HttpGet("{eventId}/calendar")]
        public IActionResult DownloadCalendar(int eventId)
        {
            var ev = _db.events.Find(eventId);
            var authorName = _db.employees.FirstOrDefault(x => x.Id == ev.AuthorId).FullName;
            if (ev == null) return NotFound();
            var ics = $@"BEGIN:VCALENDAR
VERSION:2.0
BEGIN:VEVENT
SUMMARY:{ev.Name}
DTSTART:{ev.Date:yyyyMMddTHHmmssZ}
UID:{Guid.NewGuid()}
DESCRIPTION:{ev.Description}
ORGANIZER:{authorName}
STATUS:CONFIRMED
END:VEVENT
END:VCALENDAR";
            return File(Encoding.UTF8.GetBytes(ics), "text/calendar", $"event {eventId}.ics");
        }
    }
}
