using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PcStore.Data.Models;
using PcStore.Services.Data.Interfaces;
using PcStore.Web.ViewModels.MyCart;

namespace PcStore.Web.Controllers
{
    public class MyCartController : BaseController
    {
        private readonly IMyCartService myCartService;
        private readonly ILaptopService laptopService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPartService partService;
        private readonly IAccessoryService accessoryService;
        public MyCartController(IMyCartService _myCartService, UserManager<ApplicationUser> _userManager,
            ILaptopService _laptopService, IPartService _partService, IAccessoryService _accessorySevice)
            : base()
        {
            this.myCartService = _myCartService;
            this.userManager = _userManager;
            this.laptopService = _laptopService;
            this.partService = _partService;
            this.accessoryService = _accessorySevice;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            IEnumerable<MyCartViewModel> allProducts =
                await myCartService.GetAllProductsAsync();

            return this.View(allProducts);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveFromCart(string? id)
        {
            Guid productGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref productGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }
            ApplicationUser user = await this.userManager.GetUserAsync(User)!;
            var laptop = await laptopService.TakeLaptop(productGuid);

            if (laptop != null)
            {
                await myCartService.RemoveFromCartAsync(laptop, user);
            }

            else
            {
                var part = await partService.TakePart(productGuid);
                if (part != null)
                {
                    await myCartService.RemoveFromCartAsync(part, user);
                }
                else
                {
                    var accessory = await accessoryService.TakeAccessory(productGuid);
                    if (accessory != null)
                    {
                        await myCartService.RemoveFromCartAsync(accessory, user);
                    }
                }
            }


            return RedirectToAction(nameof(Index));
        }


    }
}
