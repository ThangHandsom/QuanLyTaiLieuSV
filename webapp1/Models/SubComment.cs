using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models
{
    [Table("SubComment")]

    public class SubComment
    {
        [Key]
        public int SubCommentID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? Detail { get; set; }

        public int? BlogCommentID { get; set; }

        public int? AccountID { get; set; }
        public virtual Account? Account { get; set; }
        public virtual BlogComment? BlogComment { get; set; }
    }
}
