using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PcStore.Data;
using PcStore.Data.Models;
using PcStore.Services.Data.Interfaces;
using PcStore.Web.ViewModels.Admin;

namespace PcStore.Services.Data
{
    public class AdminService : BaseService, IAdminService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;

        public AdminService(UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            this.userManager = _userManager;
            this.roleManager = roleManager;
        }
        public async Task<IEnumerable<AdminViewModel>> AllUsersAsync()
        {
            IEnumerable<ApplicationUser> allUsers = await this.userManager.Users
                .ToArrayAsync();
            ICollection<AdminViewModel> allUsersViewModel = new List<AdminViewModel>();

            foreach (ApplicationUser user in allUsers)
            {
                IEnumerable<string> roles = await this.userManager.GetRolesAsync(user);

                allUsersViewModel.Add(new AdminViewModel()
                {
                    Id = user.Id.ToString(),
                    Email = user.Email,
                    Roles = roles
                });
            }

            return allUsersViewModel;
        }

        public async Task<bool> UserExistsByIdAsync(Guid userId)
        {
            ApplicationUser? user = await this.userManager
                .FindByIdAsync(userId.ToString());

            return user != null;
        }


        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            ApplicationUser? user = await userManager
                .FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return false;
            }

            IdentityResult? result = await this.userManager
                .DeleteAsync(user);
            if (!result.Succeeded)
            {
                return false;
            }

            return true;
        }
    }
}
