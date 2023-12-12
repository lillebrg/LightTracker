using System.Net.Http.Headers;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
    }
}
