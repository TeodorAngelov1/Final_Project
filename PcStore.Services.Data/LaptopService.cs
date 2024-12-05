namespace PcStore.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using PcStore.Data;
    using PcStore.Data.Models;
    using PcStore.Services.Data.Interfaces;
    using PcStore.Web.ViewModels.Laptop;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class LaptopService : BaseService, ILaptopService
    {
        private readonly ApplicationDbContext context;
        public LaptopService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public LaptopQueryModel All(
            string searchTerm,
            int currentPage = 1,
            int laptopsPerPage = 3
            )
        {
            var laptopsQuery = this.context.Laptops
                .Where(x => x.IsDeleted == false);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                laptopsQuery = laptopsQuery.Where(c =>
                    c.Brand.ToLower().Contains(searchTerm.ToLower()));
            }

            var totalLaptops = laptopsQuery.Count();

            var laptops = GetLaptops(laptopsQuery
                .Skip((currentPage - 1) * laptopsPerPage)
                .Take(laptopsPerPage));

            return new LaptopQueryModel
            {
                TotalLaptops = totalLaptops,
                CurrentPage = currentPage,
                LaptopsPerPage = laptopsPerPage,
                Laptops = laptops
            };
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

        public async Task EditLaptopAsync(Guid id, EditLaptopModel model)
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


        public async Task<Laptop> TakeLaptop(Guid id)
        {
            var laptop = await context.Laptops
               .Where(p => p.Id == id)
               .Include(p => p.LaptopsClients)
               .FirstOrDefaultAsync();

            return laptop;
        }
        private IEnumerable<AllLaptopsModel> GetLaptops(IQueryable<Laptop> laptopQuery)
        {
            var laptops = laptopQuery
                .Select(l => new AllLaptopsModel()
                {
                    Id = l.Id.ToString(),
                    Brand = l.Brand,
                    Price = l.Price,
                    Description = l.Description,
                    ImageUrl = l.ImageUrl ?? string.Empty
                })
            .ToList();
            return laptops;
        }


       
    }
}
