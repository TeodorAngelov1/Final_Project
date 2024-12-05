using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PcStore.Services.Data.Interfaces;
using PcStore.Web.ViewModels.Laptop;
using PcStore.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace PcStore.Web.Controllers
{
    public class LaptopController : BaseController
    {
        private readonly ILaptopService laptopService;
        private readonly IMyCartService myCartService;
        private readonly UserManager<ApplicationUser> userManager;

        public LaptopController(ILaptopService _laptopService,
            IMyCartService _myCartService, UserManager<ApplicationUser> _userManager)
            : base()
        {
            this.laptopService = _laptopService;
            this.myCartService = _myCartService;
            this.userManager = _userManager;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] AllQueryLaptopsModel query)
        {
            var queryResult = this.laptopService.All(
                query.SearchTerm,
                query.CurrentPage,
                AllQueryLaptopsModel.LaptopsPerPage);

            query.TotalLaptops = queryResult.TotalLaptops;
            query.Laptops = queryResult.Laptops;

            return View(query);
        }


        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid laptopGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref laptopGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            LaptopDetailsModel? laptop = await this.laptopService
                .GetLaptopDetailsByIdAsync(laptopGuid);
            if (laptop == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(laptop);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Add()
        {
            var model = new AddLaptopModel();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddLaptopModel inputModel)
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
            var model = new DeleteLaptopModel();
            Guid laptopGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref laptopGuid);
            if (!isGuidValid)
            {
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
        public async Task<IActionResult> Edit(string? id, EditLaptopModel laptop)
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

        

        [HttpPost]
        public async Task<IActionResult> AddToCart(string? id)
        {
            Guid laptopGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref laptopGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            var laptop = await laptopService.TakeLaptop(laptopGuid);

            if (laptop == null)
            {
                return BadRequest();
            }

            string userId = this.userManager.GetUserId(User)!;
            Guid userGuid = Guid.Empty;
            if (this.IsGuidValid(userId, ref userGuid))
            {
                var product = await myCartService.AddLaptopAsync(laptop, userGuid);
            }
                
            return RedirectToAction(nameof(Index));
        }
    }
}
