using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServerSchemaManagerSite.Models;

namespace ServerSchemaManagerSite.Pages.Servers
{
    public class ServerDetailsModel : PageModel
    {
        private readonly SsmDbContext? _data;

        public ServerDetailsModel([FromServices]SsmDbContext data)
        {
            _data = data;
        }

        public SsmServer? Server { get; set; }


        public void OnGet(int id)
        {
            Server = _data!.SsmServers.Find(id);
            Server!.Region = _data!.SsmRegions.Find(Server.RegionId);
            Server!.Usage = _data!.SsmUsages.Find(Server.UsageId);

        }
    }
}
