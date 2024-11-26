using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PcStore.Services.Data.Interfaces;
using PcStore.Web.ViewModels.Laptop;
using System.Security.Claims;

namespace PcStore.Web.Controllers
{
    public class LaptopController : BaseController
    {
        private readonly ILaptopService laptopService;

        public LaptopController(ILaptopService _laptopService)
            : base()
        {
            this.laptopService = _laptopService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllPartModel> allLaptops =
                 await laptopService.GetAllLaptopsAsync();

             return this.View(allLaptops);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid laptopGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref laptopGuid);
            if (!isGuidValid)
            {
                // Invalid id format
                return this.RedirectToAction(nameof(Index));
            }

            PartDetailsModel? laptop = await this.laptopService
                .GetLaptopDetailsByIdAsync(laptopGuid);
            if (laptop == null)
            {
                // Non-existing movie guid
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(laptop);
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

            var result = await this.laptopService.AddLaptopAsync(inputModel);
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
            Guid laptopGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref laptopGuid);
            if (!isGuidValid)
            {
                // Invalid id format
                return this.RedirectToAction(nameof(Index));
            }

            var laptop = await this.laptopService
                .DeleteLaptopAsync(laptopGuid);
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
            Guid laptopGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref laptopGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }
            var laptop = await laptopService.GetById(laptopGuid);
           
            return View(laptop);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(string? id, EditPartModel laptop)
        {
            Guid laptopGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref laptopGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            await laptopService
               .EditLaptopAsync(laptopGuid, laptop);
            return RedirectToAction(nameof(Details));
        }

        
    }
}
