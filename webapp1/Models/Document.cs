using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApp1.Models
{
    [Table("Documents")]

    public class Document
    {
        public int DocumentID { get; set; }
        public string? DocumentName { get; set; }
        public string? Description { get; set; }
        public string? FilePath { get; set; }
        public int SubjectID { get; set; }
        public virtual Subject? Subject { get; set; }

    }
}