using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServerSchemaManagerSite.Models
{
    public class SsmUsage
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string FullName { get; set; } = string.Empty;
        [Column(TypeName = "nchar(4)")]
        public string ShortName { get; set; } = string.Empty;
    }
}