namespace PcStore.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using PcStore.Data;
    using PcStore.Data.Models;
    using PcStore.Services.Data.Interfaces;
    using PcStore.Web.ViewModels.Laptop;
    using System.Security.Claims;

    public class LaptopService : BaseService, ILaptopService
    {
        private readonly ApplicationDbContext context;
        public LaptopService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<bool> AddLaptopAsync(AddPartModel inputModel)
        {
           Laptop laptop = new Laptop()
            {
                Brand = inputModel.Brand,
                Price = inputModel.Price,
                Description = inputModel.Description,
                ImageUrl = inputModel.ImageUrl
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
                .Select(p => new DeletePartModel()
                {
                    Id = p.Id.ToString(),
                    Brand = p.Brand
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

        public async Task<EditPartModel> EditLaptopAsync(Guid id, EditPartModel model)
        {
             var entity = await context.Laptops
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

        public async Task<IEnumerable<AllPartModel>> GetAllLaptopsAsync()
        {
            var model = await context.Laptops
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
            var model = await context.Laptops
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

        public async Task<PartDetailsModel?> GetLaptopDetailsByIdAsync(Guid id)
        {
            var model = await context.Laptops
               .Where(p => p.Id == id)
               .Where(p => p.IsDeleted == false)
               .AsNoTracking()
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

       public async Task<Laptop> GetLaptopAsync(string id)
        {
           var laptop = await context.Laptops
               .Where(p => p.Id.ToString() == id)
               .Include(p => p.LaptopsClients)
               .FirstOrDefaultAsync();

            return laptop;
        }
    }
}
