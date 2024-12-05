
using Microsoft.AspNetCore.Mvc;
using PcStore.Models;

namespace PcStore.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
