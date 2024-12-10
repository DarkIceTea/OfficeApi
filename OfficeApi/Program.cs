using OfficeApi.Interfaces;
using OfficeApi.Repositories;

namespace OfficeApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            var conStr = builder.Configuration.GetConnectionString("OfficeApiDB");
            builder.Services.AddTransient<IOfficeRepository, OfficeRepository>(provider => new OfficeRepository(conStr));

            var app = builder.Build();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}");

            app.Run();
        }
    }
}
