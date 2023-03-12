namespace MyEvents.Domain
{
    public class Speaker
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Resume { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Social> Socials { get; set; }
        public IEnumerable<EventSpeaker> EventSpeakers { get; set; }
    }
}