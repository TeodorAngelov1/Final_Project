namespace PcStore.Test.Services
{
    using Moq;
    using PcStore.Data;
    using PcStore.Data.Models;
    using PcStore.Services.Data;
    using PcStore.Test.Mock;
    using PcStore.Web.ViewModels.Part;

    [TestFixture]
    public class partService
    {
        private ApplicationDbContext dbContext;
        private PartService service;

        [SetUp]
        public void SetUp()
        {
            var part = new Part
            {
                Id = Guid.Parse("76164e24-b0f1-42cf-96da-c5601aeb7676"),
                Brand = "Kingston",
                Description = "SSD 1TB",
                Price = 200
            };

            dbContext = DataBaseMock.GetDatabase();
            dbContext.Parts.Add(part);
            dbContext.SaveChanges();
            service = new PartService(dbContext);
        }

        [Test]
        public void IsPartCreated()
        {
            service.AddPartAsync(new AddPartModel
            {
                Brand = "Seagate",
                Description = "HDD 2TB"
            }).Wait();

            Assert.Multiple(() =>
            {
                Assert.That(dbContext.Parts.ToList().Count, Is.EqualTo(2));
                Assert.That(dbContext.Parts.Any(x => x.Brand == "Seagate"));
            });
        }

        [Test]
        public void IsPartEdited()
        {
            service.EditPartAsync(Guid.Parse("76164e24-b0f1-42cf-96da-c5601aeb7676"), new EditPartModel
            {
                Brand = "Seagate",
                Description = "edited description"
            }).Wait();

            Assert.Multiple(() =>
            {
                Assert.That(dbContext.Parts.Any(x => x.Description == "edited description"));
                Assert.That(dbContext.Parts.Any(x => x.Brand == "Seagate"));
            });
        }

        [Test]
        public void IsPartDeleted()
        {
            service.DeletePartAsync(Guid.Parse("76164e24-b0f1-42cf-96da-c5601aeb7676")).Wait();

            Assert.That(dbContext.Parts.Any(x => x.IsDeleted));
        }

        [Test]
        public async Task IsTakingById()
        {

            var result = await service.GetById(Guid.Parse("76164e24-b0f1-42cf-96da-c5601aeb7676"));

            Assert.That(result.Brand, Is.EqualTo("Kingston"));
        }
    }
}
