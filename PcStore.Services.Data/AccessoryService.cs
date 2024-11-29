using Microsoft.EntityFrameworkCore;
using PcStore.Data;
using PcStore.Data.Models;
using PcStore.Services.Data.Interfaces;
using PcStore.Web.ViewModels.Accessory;
using PcStore.Web.ViewModels.MyCart;

namespace PcStore.Services.Data
{
    public class AccessoryService : BaseService, IAccessoryService
    {
        private readonly ApplicationDbContext context;

        public AccessoryService(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<bool> AddAccessoryAsync(AddAccessoryModel inputModel)
        {
            Accessory accessory = new Accessory()
            {
                Brand = inputModel.Brand,
                Price = inputModel.Price,
                Description = inputModel.Description,
                ImageUrl = inputModel.ImageUrl
            };
            await context.Accessories.AddAsync(accessory);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddToCart(Guid id)
        {
            var accessory = await context.AccessoriesClients
               .Where(pc => pc.ClientId == id)
               .Select(pc => new MyCartViewModel()
               {
                   Id = pc.Accessory.Id.ToString(),
                   ProductName = pc.Accessory.Brand,
                   Price = pc.Accessory.Price,
                   ImageUrl = pc.Accessory.ImageUrl
               })
               .ToListAsync();

            return true;
        }

        public async Task<bool> DeleteAccessoryAsync(Guid id)
        {
            var model = await context.Accessories
                .Where(p => p.Id == id)
                .Where(p => p.IsDeleted == false)
                .Select(p => new DeleteAccessoryModel()
                {
                    Id = p.Id.ToString(),
                    Brand = p.Brand
                })
                .FirstOrDefaultAsync();

            Accessory? accessory = await context.Accessories
               .Where(p => p.Id.ToString() == model.Id)
               .Where(p => p.IsDeleted == false)
               .FirstOrDefaultAsync();

            if (accessory != null)
            {
                accessory.IsDeleted = true;
                await context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<EditAccessoryModel> EditAccessoryAsync(Guid id, EditAccessoryModel model)
        {
            var entity = await context.Accessories
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

        public async Task<AccessoryDetailsModel?> GetAccessoryDetailsByIdAsync(Guid id)
        {
            var model = await context.Accessories
               .Where(p => p.Id == id)
               .Where(p => p.IsDeleted == false)
               .Select(p => new AccessoryDetailsModel()
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

        public async Task<IEnumerable<AllAccessoryModel>> GetAllAccessoriesAsync()
        {
            var model = await context.Accessories
                .Where(p => p.IsDeleted == false)
                .Select(p => new AllAccessoryModel()
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

        public async Task<EditAccessoryModel> GetById(Guid id)
        {
            var model = await context.Accessories
                .FindAsync(id);
            var entity = new EditAccessoryModel()
            {
                Brand = model.Brand,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price
            };
            return entity;
        }

        public async Task<Accessory> TakeAccessory(Guid id)
        {
            var accessory = await context.Accessories
               .Where(p => p.Id == id)
               .Include(p => p.AccessoriesClients)
               .FirstOrDefaultAsync();

            return accessory;
        }
    }
}
