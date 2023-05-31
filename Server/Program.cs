using Microsoft.EntityFrameworkCore;
using Server.Context;
using Server.Services;
using Server.Services.Interfaces;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<CommerceContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("CommerceDatabase")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IProductService, ProductService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors(
                options => options.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader()
            );

            app.MapControllers();

            app.Run();
        }
    }
}