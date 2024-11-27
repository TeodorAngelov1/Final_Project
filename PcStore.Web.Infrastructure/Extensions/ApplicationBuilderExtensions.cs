namespace PcStore.Web.Infrastructure.Extensions
{
    using Data;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope serviceScope = app.ApplicationServices.CreateScope();
            
            ApplicationDbContext dbContext = serviceScope
                .ServiceProvider
                .GetRequiredService<ApplicationDbContext>()!;

            return app;
        }
    }
}
