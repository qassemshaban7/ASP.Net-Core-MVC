using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Built in need to register
            builder.Services.AddControllersWithViews();
            //.AddSessionStateTempDataProvider();

            builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            builder.Services.AddDbContext<ITIEntity>(optionBuilder => {
                optionBuilder.UseSqlServer("Data Source=.;Initial Catalog=demoMCchrestina;Integrated Security=True");
            });
            //register usermanager,rolemanager==>userrole
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                options=>options.Password.RequireDigit=true
                ).
                AddEntityFrameworkStores<ITIEntity>();

            //Custom Service --REgister
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            #region Custom Middlemware "Inline Middleware"
            //app.Use(async (httpContext, next) => {
            //    await  httpContext.Response.WriteAsync("MiddleWare 1\n");
            //    await  next.Invoke();
            //    await httpContext.Response.WriteAsync("MiddleWare 1_1\n");


            //});

            //app.Run(async (context) => {
            //    await context.Response.WriteAsync("Terminate\n");
            //});
            //app.Use(async (httpContext, next) => {
            //    await httpContext.Response.WriteAsync("MiddleWare 2\n");
            //    await next.Invoke();
            //    await httpContext.Response.WriteAsync("MiddleWare 2_2\n");

            //});
            #endregion


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();//requet
           
            app.UseAuthorization();
            app.UseSession();
            app.MapControllerRoute(
               name: "default",
               pattern: "ITI/{age:int:max(50)}/{name:alpha}",
               defaults: new { controller ="Student" ,action="TestRoute"});
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}