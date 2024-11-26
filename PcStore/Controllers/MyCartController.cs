using Microsoft.AspNetCore.Mvc;
using PcStore.Services.Data;
using PcStore.Web.ViewModels.Laptop;
using PcStore.Web.ViewModels.MyCart;

namespace PcStore.Web.Controllers
{
    public class MyCartController : BaseController
    {
        public IActionResult Index()
        {
            //IEnumerable<MyCartViewModel> allLaptops =
                // await MyCartService.GetAllProductsAsync();

            return this.View();
        }
    }
}
