using Microsoft.EntityFrameworkCore;
using task1_day7.Context;
using task1_day7.Repository;

namespace task1_day7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();//register service (interface,class) to can inject it in the controller
            builder.Services.AddScoped<IDrugRepository, DrugRepository>();

            builder.Services.AddDbContext<ITIContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConn")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Drug}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
