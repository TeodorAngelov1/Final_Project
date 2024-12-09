using Microsoft.AspNetCore.Mvc;

namespace PcStore.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
