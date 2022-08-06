using Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Database.Models;
using Task2_Radency_Internship.Services;

namespace Task2_Radency_Internship
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<BookService>();
            builder.Services.Add(ServiceDescriptor.Scoped(typeof(IRepository<>), typeof(BookRepository<>)));
            builder.Services.AddDbContext<Context>(options =>
            options.UseInMemoryDatabase(databaseName: "Library"));
            //builder.Services.AddDbContext<Context>(option => option.UseSqlServer(@"Data Source=DESKTOP-E3LF3J7\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();
            app.UseAuthorization();
           app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}