using Microsoft.EntityFrameworkCore;
using PcStore.Data;
using PcStore.Data.Models;
using PcStore.Services.Data.Interfaces;
using PcStore.Web.ViewModels.MyCart;

namespace PcStore.Services.Data
{
    public class MyCartService : BaseService, IMyCartService
    {
        private readonly ApplicationDbContext context;

        public MyCartService(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public async Task<IEnumerable<MyCartViewModel>> GetAllProductsAsync()
        {
            List<MyCartViewModel> productList = new List<MyCartViewModel>();

            var laptop = await context.LaptopsClients
                .Select(p => new MyCartViewModel()
                {
                    Id = p.Laptop.Id.ToString(),
                    ProductName = p.Laptop.Brand,
                    ImageUrl = p.Laptop.ImageUrl,
                    Price = p.Laptop.Price,
                })
                .ToListAsync();
            if(laptop != null)
            {
                productList.AddRange(laptop);
            }

            var part = await context.PartsClients
                .Select(p => new MyCartViewModel()
                {
                    Id = p.Part.Id.ToString(),
                    ProductName = p.Part.Brand,
                    ImageUrl = p.Part.ImageUrl,
                    Price = p.Part.Price
                })
                .ToListAsync();
            if (part != null)
            {
                productList.AddRange(part);
            }

            var accessories = await context.AccessoriesClients
                .Select(p => new MyCartViewModel()
                {
                    Id = p.Accessory.Id.ToString(),
                    ProductName = p.Accessory.Brand,
                    ImageUrl = p.Accessory.ImageUrl,
                    Price = p.Accessory.Price
                })
                .ToListAsync();
            if (accessories != null)
            {
                productList.AddRange(accessories);
            }

            return productList;
        }

        public async Task<bool> RemoveFromCartAsync(Laptop laptop, ApplicationUser user)
        {
                LaptopClient? laptopClient = laptop.LaptopsClients.FirstOrDefault(pc => pc.ClientId == user.Id);
                if (laptopClient != null)
                {
                    laptop.LaptopsClients.Remove(laptopClient);
                    await context.SaveChangesAsync();
                }

            return true;
            
        }
        public async Task<bool> RemoveFromCartAsync(Part part, ApplicationUser user) 
        {
            PartClient? partClient = part.PartsClients.FirstOrDefault(pc => pc.ClientId == user.Id);
            if (partClient != null)
            {
                part.PartsClients.Remove(partClient);
                await context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> RemoveFromCartAsync(Accessory accessory, ApplicationUser user)
        {
            AccessoryClient? accessoryClient = accessory.AccessoriesClients.FirstOrDefault(pc => pc.ClientId == user.Id);
            if (accessoryClient != null)
            {
                accessory.AccessoriesClients.Remove(accessoryClient);
                await context.SaveChangesAsync();
            }

            return true;
        }
        public async Task<bool> AddLaptopAsync(Laptop laptop, Guid userId)
        {
            if (!laptop.LaptopsClients.Any(p => p.ClientId == userId))
            {
                laptop.LaptopsClients.Add(new LaptopClient()
                {
                    LaptopId = laptop.Id,
                    ClientId = userId
                });

                await context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> AddPartAsync(Part part, Guid userId)
        {
            if (!part.PartsClients.Any(p => p.ClientId == userId))
            {
                part.PartsClients.Add(new PartClient()
                {
                    PartId = part.Id,
                    ClientId = userId
                });

                await context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> AddAccessoryAsync(Accessory accessory, Guid userId)
        {
            if (!accessory.AccessoriesClients.Any(p => p.ClientId == userId))
            {
                accessory.AccessoriesClients.Add(new AccessoryClient()
                {
                    AccessoryId = accessory.Id,
                    ClientId = userId
                });

                await context.SaveChangesAsync();
            }
            return true;
        }
    }
}
