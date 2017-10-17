using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace PomeloDbUpdateException
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var serviceBuilder = new ServiceCollection();
            serviceBuilder.AddLogging(x =>
            {
                x.AddDebug();
                x.AddConsole();

                x.SetMinimumLevel(LogLevel.Trace);
            });

            serviceBuilder.AddDbContext<ApplicationDbContext>(options =>
            {
                options.EnableSensitiveDataLogging();

                options.UseMySql("Server=localhost;Port=3306;User Id=ef_test;Password=ef_test;Database=ef_test");
                // options.UseSqlServer("data source=.;Trusted_Connection=True;Initial Catalog=ef_test");
            });

            var services = serviceBuilder.BuildServiceProvider();

            return services.GetRequiredService<ApplicationDbContext>();
        }
    }
}
