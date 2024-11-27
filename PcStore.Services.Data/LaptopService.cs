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
                .Select(p => new DeleteLaptopModel()
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

        public async Task<EditLaptopModel> EditLaptopAsync(Guid id, EditLaptopModel model)
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

        public async Task<IEnumerable<AllLaptopsModel>> GetAllLaptopsAsync()
        {
            var model = await context.Laptops
                .Where(p => p.IsDeleted == false)
                .Select(p => new AllLaptopsModel()
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

        public async Task<EditLaptopModel> GetById(Guid id)
        {
            var model = await context.Laptops
                .FindAsync(id);
            var entity = new EditLaptopModel()
            {
                Brand = model.Brand,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price
            };
            return entity;
        }

        public async Task<LaptopDetailsModel?> GetLaptopDetailsByIdAsync(Guid id)
        {
            var model = await context.Laptops
               .Where(p => p.Id == id)
               .Where(p => p.IsDeleted == false)
               .Select(p => new LaptopDetailsModel()
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
