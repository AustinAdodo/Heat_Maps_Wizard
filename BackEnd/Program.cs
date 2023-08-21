using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HeatMaps.Utilities.Products;
using HeatMaps.Utilities.Sales;

namespace HeatMaps
{
    //dotnet --list-sdks
    //dotnet --version

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductsDBConnection")));
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ISalesService, SalesService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //app.MapGet("/", async (MyService myService, HttpContext context) =>
            //{
            //    // Use the injected service
            //    await context.Response.WriteAsync(myService.DoSomething());
            //});
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}