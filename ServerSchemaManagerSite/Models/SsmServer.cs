using System.ComponentModel.DataAnnotations.Schema;

namespace ServerSchemaManagerSite.Models
{
    public class SsmServer
    {
        public int Id { get; set; }
        [Column(TypeName = "nchar(16)")]
        public string HostName { get; set; } = string.Empty;
        public int IPv4_Internal { get; set; }
        [Column(TypeName = "binary(16)")]
        public byte[] IPv6_Internal { get; set; } = new byte[16];

        [ForeignKey(nameof(SsmRegion))]
        public int RegionId { get; set; }
        public SsmRegion? Region { get; set; }


        [ForeignKey(nameof(SsmUsage))]
        public int UsageId { get; set; }
        public SsmUsage? Usage { get; set; }

    }
}
