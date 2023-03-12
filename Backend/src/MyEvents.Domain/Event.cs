namespace MyEvents.Domain
{
    public class Event
    {
        public int ID { get; set; }
        public string Place { get; set; }
        public DateTime? Date { get; set; }
        public string Theme { get; set; }
        public int PeopleQty { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Batch> Batches { get; set; }
        public IEnumerable<Social> Socials { get; set; }
        public IEnumerable<EventSpeaker> EventSpeakers { get; set; }
    }
}