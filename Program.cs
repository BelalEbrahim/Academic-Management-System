using CRUD_Operations.Data;
using CRUD_Operations.Reposatory;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the DI container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IDepartmentRepo,DepartmentRepo>();
            builder.Services.AddScoped<IStudentRepo, StudentRepo>();
            builder.Services.AddScoped<ICourseRepo, CourseRepo>(); // Inject CourseRepo
            builder.Services.AddDbContext<ITIContext>(a =>
            {
                a.UseSqlServer(builder.Configuration.GetConnectionString("con1"));
            });

            builder.Services.AddSession();
            var app = builder.Build();





            // configure the http request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/home/error");
                // the default hsts value is 30 days. you may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=index}/{id?}");

            app.Run();




            //app.Use(async (context,next) => {
            //    await context.Response.WriteAsync("wlcome from first middleware");
            //    await next.Invoke();
            //    await context.Response.WriteAsync("\n after return from next middleware");

            //});

            //app.Run(async context => {
            //    await context.Response.WriteAsync("\n wlcome from first middleware");
            //});
        }
    }
}
