using Microsoft.AspNetCore.Mvc;

namespace PcStore.Web.Controllers
{
    public class AccessoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
