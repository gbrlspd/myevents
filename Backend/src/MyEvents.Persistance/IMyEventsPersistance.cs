using MyEvents.Domain;

namespace MyEvents.Persistance
{
    public interface IMyEventsPersistance
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Event[]> GetEventsAsync(bool includeSpeakers);
        Task<Event[]> GetEventsByThemeAsync(string theme, bool includeSpeakers);
        Task<Event> GetEventByIDAsync(int id, bool includeSpeakers);

        Task<Speaker[]> GetSpeakersAsync(bool includeEvents);
        Task<Speaker[]> GetSpeakersByNameAsync(string name, bool includeEvents);
        Task<Speaker> GetSpeakerByIDAsync(int id, bool includeEvents);
    }
}