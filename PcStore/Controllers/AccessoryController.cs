using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PcStore.Data.Models;
using PcStore.Services.Data.Interfaces;
using PcStore.Web.ViewModels.Accessories;
using PcStore.Web.ViewModels.Accessory;
using static PcStore.Common.TempConstants.Accessories;


namespace PcStore.Web.Controllers
{
    public class AccessoryController : BaseController
    {
        private readonly IAccessoryService accessoryService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMyCartService myCartService;

        public AccessoryController(IAccessoryService _accessoryService, 
            UserManager<ApplicationUser> _userManager, IMyCartService _myCartService) 
            : base()
        {
            this.accessoryService = _accessoryService;
            this.userManager = _userManager;
            this.myCartService = _myCartService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] AllQueryAccessoriesModel query)
        {
            var queryResult = this.accessoryService.All(
                query.SearchTerm,
                query.CurrentPage,
                AllQueryAccessoriesModel.AccessoriesPerPage);

                query.TotalAccessories = queryResult.TotalAccessories;
                query.Accessories = queryResult.Accessories;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid accessoryGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref accessoryGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            AccessoryDetailsModel? accessory = await this.accessoryService
                .GetAccessoryDetailsByIdAsync(accessoryGuid);
            if (accessory == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(accessory);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Add()
        {
            var model = new AddAccessoryModel();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddAccessoryModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var result = await this.accessoryService.AddAccessoryAsync(inputModel);
            if (result == false)
            {
                return this.View(inputModel);
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(string? id)
        {
            var model = new DeleteAccessoryModel();
            Guid accessoryGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref accessoryGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            var laptop = await this.accessoryService
                .DeleteAccessoryAsync(accessoryGuid);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete()
        {
            return this.RedirectToAction(nameof(Index));
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string? id)
        {
            Guid accessoryGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref accessoryGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }
            var laptop = await accessoryService.GetById(accessoryGuid);

            return View(laptop);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(string? id, EditAccessoryModel laptop)
        {
            Guid accessoryGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref accessoryGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            await accessoryService
               .EditAccessoryAsync(accessoryGuid, laptop);
            return RedirectToAction(nameof(Details));
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(string? id)
        {
            Guid accessoryGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref accessoryGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            var accessory = await accessoryService.TakeAccessory(accessoryGuid);

            if (accessory == null)
            {
                return BadRequest();
            }

            string userId = this.userManager.GetUserId(User)!;
            Guid userGuid = Guid.Empty;
            if (this.IsGuidValid(userId, ref userGuid))
            {
                var product = await myCartService.AddAccessoryAsync(accessory, userGuid);
            }
            this.TempData[AccessoriesMessage] = "Accessory was added to your cart!";
            return RedirectToAction(nameof(Index));
        }
    }
}
