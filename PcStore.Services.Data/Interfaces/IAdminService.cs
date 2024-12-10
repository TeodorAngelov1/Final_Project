using PcStore.Web.ViewModels.Admin;

namespace PcStore.Services.Data.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminViewModel>> AllUsersAsync();

        Task<bool> UserExistsByIdAsync(Guid userId);
        Task<bool> DeleteUserAsync(Guid userId);
    }
}
