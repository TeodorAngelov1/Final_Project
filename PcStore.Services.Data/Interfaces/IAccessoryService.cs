using PcStore.Data.Models;
using PcStore.Web.ViewModels.Accessory;

namespace PcStore.Services.Data.Interfaces
{
    public interface IAccessoryService
    {
        Task<IEnumerable<AllAccessoryModel>> GetAllAccessoriesAsync();

        Task<bool> DeleteAccessoryAsync(Guid id);

        Task<bool> AddAccessoryAsync(AddAccessoryModel inputModel);

        Task<EditAccessoryModel> EditAccessoryAsync(Guid id, EditAccessoryModel model);

        Task<AccessoryDetailsModel?> GetAccessoryDetailsByIdAsync(Guid id);

        Task<EditAccessoryModel> GetById(Guid id);

        Task<Accessory> TakeAccessory(Guid id);
    }
}
