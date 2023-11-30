namespace Models
{
    public class Product
    {
        public int? Id { get; set; }
        public User? User { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
