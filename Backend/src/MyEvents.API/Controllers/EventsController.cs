using Microsoft.AspNetCore.Mvc;
using MyEvents.Persistance;
using MyEvents.Domain;

namespace MyEvents.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly MyEventsContext context;
    public EventsController(MyEventsContext context)
    {
      this.context = context;
    }

    [HttpGet]
    public IEnumerable<Event> Get()
    {
        return context.Events;
    }
    
    [HttpGet("{id}")]
    public Event GetByID(int id)
    {
        return context.Events.FirstOrDefault(e => e.ID == id);
    }
}