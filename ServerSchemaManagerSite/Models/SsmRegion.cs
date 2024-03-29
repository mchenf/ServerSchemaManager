﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerSchemaManagerSite.Models
{
    public class SsmRegion
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string FullName { get; set; } = string.Empty;
        [Column(TypeName = "nchar(4)")]
        public string ShortName { get; set; } = string.Empty;
    }
}