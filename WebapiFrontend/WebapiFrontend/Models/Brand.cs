using System.ComponentModel.DataAnnotations;

namespace WebapiFrontend.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
