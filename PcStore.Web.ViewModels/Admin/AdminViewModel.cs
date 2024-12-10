using PcStore.Data.Models;

namespace PcStore.Web.ViewModels.Admin
{
    public class AdminViewModel
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;

        public IEnumerable<string> Roles { get; set; } = null!;
    }
}
