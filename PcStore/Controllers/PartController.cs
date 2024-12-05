using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PcStore.Data.Models;
using PcStore.Services.Data;
using PcStore.Services.Data.Interfaces;
using PcStore.Web.ViewModels.Laptop;
using PcStore.Web.ViewModels.Part;

namespace PcStore.Web.Controllers
{
    public class PartController : BaseController
    {
        private readonly IPartService partService;
        private readonly IMyCartService myCartService;
        private readonly UserManager<ApplicationUser> userManager;
        public PartController(IPartService _partService, 
            IMyCartService _myCartService, UserManager<ApplicationUser> _userManager)
            : base()
        {
            this.partService = _partService;
            this.userManager = _userManager;
            this.myCartService = _myCartService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] AllQueryPartsModel query)
        {
            var queryResult = this.partService.All(
                 query.SearchTerm,
                 query.CurrentPage,
                 AllQueryPartsModel.PartsPerPage);

            query.TotalParts = queryResult.TotalParts;
            query.Parts = queryResult.Parts;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid partGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref partGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            PartDetailsModel? part = await this.partService
                .GetPartDetailsByIdAsync(partGuid);
            if (part == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(part);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Add()
        {
            var model = new AddPartModel();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddPartModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var result = await this.partService.AddPartAsync(inputModel);
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
            var model = new DeletePartModel();
            Guid partGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref partGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            var part = await this.partService
                .DeletePartAsync(partGuid);
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
            Guid partGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref partGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }
            var part = await partService.GetById(partGuid);

            return View(part);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(string? id, EditPartModel part)
        {
            Guid partGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref partGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            await partService
               .EditPartAsync(partGuid, part);
            return RedirectToAction(nameof(Details));
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(string? id)
        {
            Guid partGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref partGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            var part = await partService.TakePart(partGuid);

            if (part == null)
            {
                return BadRequest();
            }

            string userId = this.userManager.GetUserId(User)!;
            Guid userGuid = Guid.Empty;
            if (this.IsGuidValid(userId, ref userGuid))
            {
                var product = await myCartService.AddPartAsync(part, userGuid);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
