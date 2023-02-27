using Microsoft.AspNetCore.Mvc;
using MyEvents.API.Data;
using MyEvents.API.Models;

namespace MyEvents.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly DataContext context;
    public EventsController(DataContext context)
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
        return context.Events.FirstOrDefault(e => e.EventID == id);
    }
}