//using Fluent.Infrastructure.FluentModel;
using IKEA.BLL.Common.MappingProfiles;
using IKEA.BLL.Services.DepartmentServices;
using IKEA.BLL.Services.EmployeeServices;
using IKEA.DAL.Contexts;
using IKEA.DAL.Repositories.DepartmentRepos;
using IKEA.DAL.Repositories.EmployeeRepos;
using IKEA.DAL.UOW;
using Microsoft.AspNetCore.Mvc;
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
            builder.Services.AddControllersWithViews(Options =>
            {
                Options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());   
            });

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
            });

            
            //builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentServices,DepartmentServices>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            //builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            //builder.Services.AddAutoMapper(M=>M.AddProfile(new ProjectMapperProfile());
            builder.Services.AddAutoMapper(cfg => { }, typeof(ProjectMapperProfile));




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
