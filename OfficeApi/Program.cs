using FluentValidation;
using FluentValidation.AspNetCore;
using OfficeApi.ActionFilters;
using OfficeApi.Interfaces;
using OfficeApi.Repositories;
using OfficeApi.Validators;

namespace OfficeApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers(option =>
            {
                option.Filters.Add<ValidationActionFilter>();
            });

            var conStr = builder.Configuration.GetConnectionString("OfficeApiDB");
            builder.Services.AddTransient<IOfficeRepository, OfficeRepository>(provider => new OfficeRepository(conStr));

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<OfficeDtoValidator>();

            builder.Services.AddMemoryCache();

            var app = builder.Build();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}");

            app.Run();
        }
    }
}
