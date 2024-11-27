using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PcStore.Services.Data.Interfaces;
using PcStore.Web.ViewModels.Part;

namespace PcStore.Web.Controllers
{
    public class PartController : BaseController
    {
        private readonly IPartService partService;

        public PartController(IPartService _partService)
            : base()
        {
            this.partService = _partService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllPartModel> allParts =
                  await partService.GetAllPartsAsync();

            return this.View(allParts);
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
    }
}
