using PcStore.Data.Models;
using PcStore.Web.ViewModels.Part;
namespace PcStore.Services.Data.Interfaces
{
    public interface IPartService
    {
        Task<bool> DeletePartAsync(Guid id);

        Task<bool> AddPartAsync(AddPartModel inputModel);

        Task EditPartAsync(Guid id, EditPartModel model);

        Task<PartDetailsModel?> GetPartDetailsByIdAsync(Guid id);

        Task<EditPartModel> GetById(Guid id);

        Task<Part> TakePart(Guid id);

        PartQueryModel All(
            string searchTerm = null,
            int currentPage = 1,
            int partsPerPage = int.MaxValue);
    }
}
