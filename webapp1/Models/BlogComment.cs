using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    [Table("BlogComment")]
    public partial class BlogComment
    {
        [Key]
        public int BlogCommentID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? Detail { get; set; }

        public int? BlogID { get; set; }

        public bool IsActive { get; set; }
        public int? AccountID { get; set; }
        public virtual Account? Account { get; set; }
        public virtual Blog? Blog { get; set; }
        public virtual ICollection<SubComment> SubComments { get; set; } = new List<SubComment>();

    }
}
