using Microsoft.EntityFrameworkCore;
using MyEvents.Domain;

namespace MyEvents.Persistance
{
  public class MyEventsPersistance : IMyEventsPersistance
  {
    private readonly MyEventsContext _context;
    public MyEventsPersistance(MyEventsContext context)
    {
        this._context = context;
    }

    public void Add<T>(T entity) where T : class
    {
        _context.Add(entity);
    }

    public void Update<T>(T entity) where T : class
    {
        _context.Update(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }

    public void DeleteRange<T>(T[] entityArray) where T : class
    {
        _context.RemoveRange(entityArray);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }

    public async Task<Event[]> GetEventsAsync(bool includeSpeakers = false)
    {
        IQueryable<Event> query = _context.Events
            .Include(e => e.Batches)
            .Include(e => e.Socials);

        if (includeSpeakers)
        {
            query = query
                .Include(e => e.EventSpeakers)
                .ThenInclude(es => es.Speaker);
        }
        
        query = query.OrderBy(e => e.ID);
        
        return await query.ToArrayAsync();
    }

    public async Task<Event[]> GetEventsByThemeAsync(string theme, bool includeSpeakers = false)
    {
      IQueryable<Event> query = _context.Events
            .Include(e => e.Batches)
            .Include(e => e.Socials);

        if (includeSpeakers)
        {
            query = query
                .Include(e => e.EventSpeakers)
                .ThenInclude(es => es.Speaker);
        }
        
        query = query.OrderBy(e => e.ID)
            .Where(e => e.Theme.ToLower().Contains(theme.ToLower()));
        
        return await query.ToArrayAsync();
    }

    public async Task<Event> GetEventByIDAsync(int id, bool includeSpeakers = false)
    {
      IQueryable<Event> query = _context.Events
            .Include(e => e.Batches)
            .Include(e => e.Socials);

        if (includeSpeakers)
        {
            query = query
                .Include(e => e.EventSpeakers)
                .ThenInclude(es => es.Speaker);
        }
        
        query = query.OrderBy(e => e.ID)
            .Where(e => e.ID == id);
        
        return await query.FirstOrDefaultAsync();
    }

    public async Task<Speaker[]> GetSpeakersAsync(bool includeEvents = false)
    {
      IQueryable<Speaker> query = _context.Speakers
            .Include(s => s.Socials);

        if (includeEvents)
        {
            query = query
                .Include(s => s.EventSpeakers)
                .ThenInclude(es => es.Event);
        }
        
        query = query.OrderBy(s => s.ID);
        
        return await query.ToArrayAsync();
    }

    public async Task<Speaker[]> GetSpeakersByNameAsync(string name, bool includeEvents = false)
    {
      IQueryable<Speaker> query = _context.Speakers
            .Include(s => s.Socials);

        if (includeEvents)
        {
            query = query
                .Include(s => s.EventSpeakers)
                .ThenInclude(es => es.Event);
        }
        
        query = query.OrderBy(s => s.ID)
            .Where(s => s.Name.ToLower().Contains(name.ToLower()));
        
        return await query.ToArrayAsync();
    }

    public async Task<Speaker> GetSpeakerByIDAsync(int id, bool includeEvents)
    {
      IQueryable<Speaker> query = _context.Speakers
            .Include(s => s.Socials);

        if (includeEvents)
        {
            query = query
                .Include(s => s.EventSpeakers)
                .ThenInclude(es => es.Event);
        }
        
        query = query.OrderBy(s => s.ID)
            .Where(s => s.ID == id);
        
        return await query.FirstOrDefaultAsync();
    }
  }
}