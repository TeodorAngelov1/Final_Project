using Microsoft.EntityFrameworkCore;
using PcStore.Data;
using PcStore.Data.Models;
using PcStore.Services.Data.Interfaces;
using PcStore.Web.ViewModels.MyCart;
using PcStore.Web.ViewModels.Part;

namespace PcStore.Services.Data
{
    public class PartService : BaseService, IPartService
    {
        private readonly ApplicationDbContext context;
        public PartService(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<bool> AddPartAsync(AddPartModel inputModel)
        {
            Part part = new Part()
            {
                Brand = inputModel.Brand,
                Price = inputModel.Price,
                Description = inputModel.Description,
                ImageUrl = inputModel.ImageUrl
            };
            await context.Parts.AddAsync(part);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddToCart(Guid id)
        {
            var part = await context.PartsClients
                .Where(pc => pc.ClientId == id)
                .Select(pc => new MyCartViewModel()
                {
                    Id = pc.Part.Id.ToString(),
                    ProductName = pc.Part.Brand,
                    Price = pc.Part.Price,
                    ImageUrl = pc.Part.ImageUrl
                })
                .ToListAsync();

            return true;
        }

        public async Task<bool> DeletePartAsync(Guid id)
        {
            var model = await context.Parts
                .Where(p => p.Id == id)
                .Where(p => p.IsDeleted == false)
                .Select(p => new DeletePartModel()
                {
                    Id = p.Id.ToString(),
                    Brand = p.Brand
                })
                .FirstOrDefaultAsync();

            Part? part = await context.Parts
               .Where(p => p.Id.ToString() == model.Id)
               .Where(p => p.IsDeleted == false)
               .FirstOrDefaultAsync();

            if (part != null)
            {
                part.IsDeleted = true;
                await context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<EditPartModel> EditPartAsync(Guid id, EditPartModel model)
        {
            var entity = await context.Parts
                .Where(g => g.Id == id)
                .Where(g => g.IsDeleted == false)
                .FirstOrDefaultAsync();

            entity.Brand = model.Brand;
            entity.Price = model.Price;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;

            await context.SaveChangesAsync();


            return model;
        }

        public async Task<IEnumerable<AllPartModel>> GetAllPartsAsync()
        {
            var model = await context.Parts
                .Where(p => p.IsDeleted == false)
                .Select(p => new AllPartModel()
                {
                    Id = p.Id.ToString(),
                    Brand = p.Brand,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Description = p.Description
                })
                .ToListAsync();

            return model;
        }

        public async Task<EditPartModel> GetById(Guid id)
        {
            var model = await context.Parts
                .FindAsync(id);
            var entity = new EditPartModel()
            {
                Brand = model.Brand,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price
            };
            return entity;
        }

        public async Task<PartDetailsModel?> GetPartDetailsByIdAsync(Guid id)
        {
            var model = await context.Parts
               .Where(p => p.Id == id)
               .Where(p => p.IsDeleted == false)
               .Select(p => new PartDetailsModel()
               {
                   Id = p.Id.ToString(),
                   Brand = p.Brand,
                   Price = p.Price,
                   Description = p.Description,
                   ImageUrl = p.ImageUrl ?? string.Empty
               })
               .FirstOrDefaultAsync();

            return model;
        }

        public async Task<Part> TakePart(Guid id)
        {
            var part = await context.Parts
               .Where(p => p.Id == id)
               .Include(p => p.PartsClients)
               .FirstOrDefaultAsync();

            return part;
        }
    }
}
