using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServerSchemaManagerSite.Models;

namespace ServerSchemaManagerSite.Pages
{
    public class ServersModel : PageModel
    {
        public void OnGet([FromServices]SsmDbContext data)
        {
            Servers = data.SsmServers.Include(p => p.Usage)
                .Include(p => p.Region);
        }

        public IEnumerable<SsmServer>? Servers { get; internal set; }
    }
}
