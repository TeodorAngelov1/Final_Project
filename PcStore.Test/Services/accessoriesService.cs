namespace PcStore.Test.Services
{
    using Moq;
    using PcStore.Data;
    using PcStore.Data.Models;
    using PcStore.Services.Data;
    using PcStore.Test.Mock;
    using PcStore.Web.ViewModels.Accessories;
    using PcStore.Web.ViewModels.Laptop;

    [TestFixture]
    public class accessoriesService
    {
        private ApplicationDbContext dbContext;
        private AccessoryService service;

        [SetUp]
        public void SetUp()
        {
            var accessory = new Accessory
            {
                Id = Guid.Parse("76164e24-b0f1-42cf-96da-c5601aeb7676"),
                Brand = "JBL T100",
                Description = "Headphones",
                Price = 100
            };

            dbContext = DataBaseMock.GetDatabase();
            dbContext.Accessories.Add(accessory);
            dbContext.SaveChanges();
            service = new AccessoryService(dbContext);
        }

        [Test]
        public void IsAccessoryCreated()
        {
            service.AddAccessoryAsync(new AddAccessoryModel
            {
                Brand = "Deluxe Keyboard",
                Description = "Some info for create"
            }).Wait();

            Assert.Multiple(() =>
            {
                Assert.That(dbContext.Accessories.ToList().Count, Is.EqualTo(2));
                Assert.That(dbContext.Accessories.Any(x => x.Brand == "JBL T100"));
            });
        }

        [Test]
        public void IsAccessoryEdited()
        {
            service.EditAccessoryAsync(Guid.Parse("76164e24-b0f1-42cf-96da-c5601aeb7676"), new EditAccessoryModel
            {
                Brand = "Deluxe Keyboard",
                Description = "edited description"
            }).Wait();

            Assert.Multiple(() =>
            {
                Assert.That(dbContext.Accessories.Any(x => x.Description == "edited description"));
                Assert.That(dbContext.Accessories.Any(x => x.Brand == "Deluxe Keyboard"));
            });
        }

        [Test]
        public void IsAccessoryDeleted()
        {
            service.DeleteAccessoryAsync(Guid.Parse("76164e24-b0f1-42cf-96da-c5601aeb7676")).Wait();

            Assert.That(dbContext.Accessories.Any(x => x.IsDeleted));
        }

        [Test]
        public async Task IsTakingById()
        {

            var result = await service.GetById(Guid.Parse("76164e24-b0f1-42cf-96da-c5601aeb7676"));

            Assert.That(result.Brand, Is.EqualTo("JBL T100"));
        }
    }
}
