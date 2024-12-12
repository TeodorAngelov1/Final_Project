using Microsoft.EntityFrameworkCore;
using PcStore.Data;

namespace PcStore.Test.Mock
{
    public static class DataBaseMock
    {
        public static ApplicationDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(dbOptions);
        }
    }
}
