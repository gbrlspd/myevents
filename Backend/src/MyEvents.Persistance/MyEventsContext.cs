using Microsoft.EntityFrameworkCore;
using MyEvents.Domain;

namespace MyEvents.Persistance
{
    public class MyEventsContext : DbContext
    {
        public MyEventsContext(DbContextOptions<MyEventsContext> options) : base(options) { }
        public DbSet<Event> Events { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<EventSpeaker> EventSpeakers { get; set; }
        public DbSet<Social> Socials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventSpeaker>()
            .HasKey(ES => new { ES.EventID, ES.SpeakerID });
        }
    }
}