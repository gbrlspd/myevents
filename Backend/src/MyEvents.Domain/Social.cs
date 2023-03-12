namespace MyEvents.Domain
{
    public class Social
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int? EventID { get; set; }
        public Event Event { get; set; }
        public int? SpeakerID { get; set; }
        public Speaker Speaker { get; set; }
    }
}