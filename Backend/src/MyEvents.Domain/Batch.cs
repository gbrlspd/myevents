namespace MyEvents.Domain
{
    public class Batch
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? InitDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Quantity { get; set; }
        public int EventID { get; set; }
        public Event Event { get; set; }
    }
}