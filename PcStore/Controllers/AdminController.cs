using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PcStore.Services.Data.Interfaces;
using PcStore.Web.Controllers;
using PcStore.Web.ViewModels.Admin;
using static PcStore.Common.AdminConstant;

namespace PcStore.Web.Areas.Admin.Controllers
{

    [Authorize(Roles = AdminRoleName)]
    public class AdminController : BaseController
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService _adminService)
        {
            adminService = _adminService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<AdminViewModel> Users = await adminService.AllUsersAsync();
            return View(Users);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string userId)
        {
            Guid userGuid = Guid.Empty;
            if (!this.IsGuidValid(userId, ref userGuid))
            {
                return this.RedirectToAction(nameof(Index));
            }

            bool userExists = await this.adminService
                .UserExistsByIdAsync(userGuid);
            if (!userExists)
            {
                return this.RedirectToAction(nameof(Index));
            }

            bool removeResult = await this.adminService
                .DeleteUserAsync(userGuid);
            if (!removeResult)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.RedirectToAction(nameof(Index));
        }
    }
}
