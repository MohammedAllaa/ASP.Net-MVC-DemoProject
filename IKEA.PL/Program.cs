//using Fluent.Infrastructure.FluentModel;
using IKEA.BLL.Services;
using  IKEA.DAL.Contexts;
using IKEA.DAL.Repositories.DepartmentRepos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace IKEA.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentServices,DepartmentServices>();


            var app = builder.Build();

           

            app.UseRouting();


            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                

            app.Run();
        }
    }
}
