using PcStore.Data.Models;
using PcStore.Web.ViewModels.MyCart;

namespace PcStore.Services.Data.Interfaces
{
    public interface IMyCartService
    {
        Task<bool> RemoveFromCartAsync(Accessory accessory, ApplicationUser user);
        Task<bool> RemoveFromCartAsync(Part part, ApplicationUser user);
        Task<bool> RemoveFromCartAsync(Laptop laptop, ApplicationUser user);

        Task<IEnumerable<MyCartViewModel>> GetAllProductsAsync();

        Task<bool> AddLaptopAsync(Laptop laptop, Guid userId);

        Task<bool> AddPartAsync(Part part, Guid userId);

        Task<bool> AddAccessoryAsync(Accessory accessory, Guid userId);

    }

}