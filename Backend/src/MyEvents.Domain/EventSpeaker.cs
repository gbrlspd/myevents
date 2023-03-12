namespace MyEvents.Domain
{
    public class EventSpeaker
    {
        public int SpeakerID { get; set; }
        public Speaker Speaker { get; set; }
        public int EventID { get; set; }
        public Event Event { get; set; }
    }
}