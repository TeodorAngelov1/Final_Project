namespace PcStore.Test.Services
{
    using Moq;
    using PcStore.Data;
    using PcStore.Data.Models;
    using PcStore.Services.Data;
    using PcStore.Test.Mock;
    using PcStore.Web.ViewModels.Laptop;

    [TestFixture]
    internal class laptopService
    {

        private ApplicationDbContext dbContext;
        private LaptopService service;

        [SetUp]
        public void SetUp()
        {
            var laptop = new Laptop
            {
                Id = Guid.Parse("76164e24-b0f1-42cf-96da-c5601aeb7676"),
                Brand = "Dell",
                Description = "Best laptop",
                Price = 2500
            };

            dbContext = DataBaseMock.GetDatabase();
            dbContext.Laptops.Add(laptop);
            dbContext.SaveChanges();
            service = new LaptopService(dbContext);
        }

        [Test]
        public void IsLaptopCreated()
        {
            service.AddLaptopAsync(new AddLaptopModel
            {
                Brand = "Dell",
                Description = "Some info for create"
            }).Wait();

            Assert.Multiple(() =>
            {
                Assert.That(dbContext.Laptops.ToList().Count, Is.EqualTo(2));
                Assert.That(dbContext.Laptops.Any(x => x.Brand == "Dell"));
            });
        }

        [Test]
        public void IsLaptopEdited()
        {
            service.EditLaptopAsync(Guid.Parse("76164e24-b0f1-42cf-96da-c5601aeb7676"), new EditLaptopModel
            {
                Brand = "Lenovo",
                Description = "edited description"
            }).Wait();

            Assert.Multiple(() =>
            {
                Assert.That(dbContext.Laptops.Any(x => x.Description == "edited description"));
                Assert.That(dbContext.Laptops.Any(x => x.Brand == "Lenovo"));
            });
        }

        [Test]
        public void IsLaptopDeleted()
        {
            service.DeleteLaptopAsync(Guid.Parse("76164e24-b0f1-42cf-96da-c5601aeb7676")).Wait();

            Assert.That(dbContext.Laptops.Any(x => x.IsDeleted));
        }

        [Test]
        public async Task IsTakingById()
        {
           
            var result = await service.GetById(Guid.Parse("76164e24-b0f1-42cf-96da-c5601aeb7676"));

            Assert.That(result.Brand, Is.EqualTo("Dell"));
        }
    }
}