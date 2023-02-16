using Microsoft.AspNetCore.Mvc;
using MyEvents.API.Models;

namespace MyEvents.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    public IEnumerable<Event> _event = new Event[] {
        new Event() {
            EventID = 1,
            Place = "Piracicaba",
            Date = DateTime.Now.AddDays(2).ToString("dd/mm/yyyy"),
            Theme = "Test Event",
            PeopleQty = 175,
            Batch = "1st Batch"
        },
        new Event() {
            EventID = 2,
            Place = "Limeira",
            Date = DateTime.Now.AddDays(3).ToString("dd/mm/yyyy"),
            Theme = "Test Event 2",
            PeopleQty = 180,
            Batch = "1st Batch"
        }
    };
    
    public EventController()
    {

    }

    [HttpGet]
    public IEnumerable<Event> Get()
    {
        return _event;
    }
    
    [HttpGet("{id}")]
    public IEnumerable<Event> GetByID(int id)
    {
        return _event.Where(e => e.EventID == id);
    }
}