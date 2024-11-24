using Microsoft.AspNetCore.Mvc;

namespace PcStore.Web.Controllers
{
    public class PartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
