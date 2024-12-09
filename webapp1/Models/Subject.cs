using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models
{
    [Table("Subjects")]
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        public string? SubjectName { get; set; }
        public int? Credits { get; set; }
        public string? Department { get; set; }
        public int? Semester { get; set; }
        public string? Alias { get; set; }
        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    }

}

