using System.ComponentModel.DataAnnotations.Schema;

namespace ServerSchemaManagerSite.Models
{
    public class SsmServer
    {
        public int Id { get; set; }
        public string HostName { get; set; } = string.Empty;
        public int IPv4_Internal { get; set; }
        [Column(TypeName = "Byte(16)")]
        public byte[] IPv6_Internal { get; set; } = new byte[16];

        public int RegionId { get; set; }
        public SsmRegion? Region { get; set; }

        public int UsageId { get; set; }
        public SsmUsage? Usage { get; set; }

    }
}
