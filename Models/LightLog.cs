namespace Models
{
    public class LightLog
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int TimeOnly { get; set; }
        public DateTime DateSent { get; set; }
    }
}