using System.ComponentModel.DataAnnotations;

namespace EC_ASP.NET.Models
{
    public class ProjectEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string Status { get; set; } = null!;

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(30);



        public int ClientId { get; set; }


        public ClientEntity? Client { get; set; }

        [Required]
        public string Budget { get; set; } = null!;




    }
}
