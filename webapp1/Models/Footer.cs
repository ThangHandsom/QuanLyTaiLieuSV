using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models
{
    [Table("Footer")]
    public class Footer
    {
        [Key]
        public int FooterID { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? SocialLinks { get; set; }
        public string? Copyright { get; set; }
    }

}
