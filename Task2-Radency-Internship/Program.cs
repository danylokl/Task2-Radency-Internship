using Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Database.Models;
using Task2_Radency_Internship.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.HttpLogging;

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
            builder.Services.AddExceptionHandler(builder =>
            builder.ExceptionHandlingPath = "/error");
            builder.Services.AddHttpLogging(option =>
            {
                option.LoggingFields = HttpLoggingFields.Request;

            });
            builder.Services.AddDbContext<Context>(options =>
            options.UseInMemoryDatabase(databaseName: "Library"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseHttpLogging();
            app.UseHttpsRedirection();
            app.UseExceptionHandler();

            app.UseDeveloperExceptionPage();
            app.UseAuthorization();
            app.UseRouting();

            app.MapControllers();

            app.Run();
        }
    }
}