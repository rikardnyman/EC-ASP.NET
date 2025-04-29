namespace EC_ASP.NET.Models
{
    public class ClientEntity
    {
        public int id { get; set; }
        public string FullName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime Date { get; set; }
        public bool status { get; set; }
        public string Email { get; set; } = null!;
    }
}
