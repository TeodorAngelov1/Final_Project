namespace PcStore.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using PcStore.Data;
    using PcStore.Data.Models;
    using PcStore.Services.Data.Interfaces;
    using PcStore.Web.ViewModels.Laptop;

    public class LaptopService : BaseService, ILaptopService
    {
        private readonly ApplicationDbContext context;
        public LaptopService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<bool> AddLaptopAsync(AddLaptopModel inputModel)
        {
           Laptop laptop = new Laptop()
            {
                LaptopName = inputModel.LaptopName,
                LaptopPrice = inputModel.LaptopPrice,
                LaptopDescription = inputModel.LaptopDescription,
                LaptopImageUrl = inputModel.LaptopImageUrl
            };
            await context.Laptops.AddAsync(laptop);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLaptopAsync(Guid id)
        {
            var model = await context.Laptops
                .Where(p => p.Id == id)
                .Where(p => p.IsDeleted == false)
                .AsNoTracking()
                .Select(p => new DeleteLaptopModel()
                {
                    Id = p.Id.ToString(),
                    LaptopName = p.LaptopName
                })
                .FirstOrDefaultAsync();

            Laptop? laptop = await context.Laptops
               .Where(p => p.Id.ToString() == model.Id)
               .Where(p => p.IsDeleted == false)
               .FirstOrDefaultAsync();

            if (laptop != null)
            {
                laptop.IsDeleted = true;
                await context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<EditLaptopModel> EditLaptopAsync(Guid id, EditLaptopModel model)
        {
             var entity = await context.Laptops
                .Where(g => g.Id == id)
                .Where(g => g.IsDeleted == false)
                .FirstOrDefaultAsync();

            entity.LaptopName = model.LaptopName;
            entity.LaptopPrice = model.LaptopPrice;
            entity.LaptopDescription = model.LaptopDescription;
            entity.LaptopImageUrl = model.LaptopImageUrl;

                await context.SaveChangesAsync();
            
            
            return model;
        }

        public async Task<IEnumerable<AllLaptopsModel>> GetAllLaptopsAsync()
        {
            var model = await context.Laptops
                .Where(p => p.IsDeleted == false)
                .Select(p => new AllLaptopsModel()
                {
                    Id = p.Id.ToString(),
                    LaptopName = p.LaptopName,
                    LaptopImageUrl = p.LaptopImageUrl,
                    LaptopPrice = p.LaptopPrice,
                    LaptopDescription = p.LaptopDescription
                })
                .AsNoTracking()
                .ToListAsync();

            return model;
        }

        public async Task<EditLaptopModel> GetById(Guid id)
        {
            var model = await context.Laptops
                .FindAsync(id);
            var entity = new EditLaptopModel()
            {
                LaptopName = model.LaptopName,
                LaptopDescription = model.LaptopDescription,
                LaptopImageUrl = model.LaptopImageUrl,
                LaptopPrice = model.LaptopPrice
            };
            return entity;
        }

        public async Task<LaptopDetailsModel?> GetLaptopDetailsByIdAsync(Guid id)
        {
            var model = await context.Laptops
               .Where(p => p.Id == id)
               .Where(p => p.IsDeleted == false)
               .AsNoTracking()
               .Select(p => new LaptopDetailsModel()
               {
                   Id = p.Id.ToString(),
                   LaptopName = p.LaptopName,
                   LaptopPrice = p.LaptopPrice,
                   LaptopDescription = p.LaptopDescription,
                   LaptopImageUrl = p.LaptopImageUrl ?? string.Empty
               })
               .FirstOrDefaultAsync();

            return model;
        }
    }
}
