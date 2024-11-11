using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        public string? Name { get; set; }    
        public string? Email { get; set; }
        public string? Class { get; set; }
        public string? Message { get; set; }

    }
}
