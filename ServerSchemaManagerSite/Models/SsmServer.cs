using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace ServerSchemaManagerSite.Models
{
    public class SsmServer
    {
        public int Id { get; set; }
        [Column(TypeName = "nchar(16)")]
        public string HostName { get; set; } = string.Empty;

        [Column(TypeName = "binary(4)")]
        public byte[] IPv4_Internal { get; set; } = new byte[4];

        [NotMapped]
        public IPAddress IPv4
        {
            get
            {
                return new IPAddress(IPv4_Internal);
            }
            set
            {
                IPv4 = value;
                IPv4_Internal = value.GetAddressBytes();
            }
        }

        [Column(TypeName = "binary(16)")]
        public byte[] IPv6_Internal { get; set; } = new byte[16];

        [NotMapped]
        public IPAddress IPv6
        {
            get
            {
                return new IPAddress(IPv6_Internal);
            }
            set
            {
                IPv6 = value;
                IPv6_Internal = value.GetAddressBytes();
            }
        }
        [ForeignKey(nameof(SsmRegion))]
        public int RegionId { get; set; }
        public SsmRegion? Region { get; set; }


        [ForeignKey(nameof(SsmUsage))]
        public int UsageId { get; set; }
        public SsmUsage? Usage { get; set; }

    }
}
