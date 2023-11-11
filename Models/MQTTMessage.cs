namespace Models
{
    public class MQTTMessage
    {
        public int Id { get; set; }
        public int Seconds { get; set; }
        public int Minutes { get; set; }
        public int Hours { get; set; }
        public DateTime DateSent { get; set; }
    }
}