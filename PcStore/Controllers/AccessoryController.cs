using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PcStore.Services.Data.Interfaces;
using PcStore.Web.ViewModels.Accessory;

namespace PcStore.Web.Controllers
{
    public class AccessoryController : BaseController
    {
        private readonly IAccessoryService accessoryService;

        public AccessoryController(IAccessoryService _accessoryService) 
            : base()
        {
            this.accessoryService = _accessoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllAccessoryModel> accessory =
                 await accessoryService.GetAllAccessoriesAsync();

            return this.View(accessory);
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
    }
}
