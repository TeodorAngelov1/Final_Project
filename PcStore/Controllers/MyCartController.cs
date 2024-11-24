using Microsoft.AspNetCore.Mvc;

namespace PcStore.Web.Controllers
{
    public class MyCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
