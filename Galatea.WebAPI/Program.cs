using Galatea.Services.Data.Interfaces;
using Galatea.Web.Data;
using Galatea.Web.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Galatea.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<GalateaDbContext>(opt =>
                opt.UseSqlServer(connectionString));

            builder.Services.AddApplicationServices(typeof(IPublicationService));

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(setup =>
            {
                setup.AddPolicy("Galatea", policyBuilder =>
                {
                    policyBuilder
                        .WithOrigins("https://localhost:7126")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseCors("Galatea");

            app.Run();
        }
    }
}