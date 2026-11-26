
using KonyvtarWebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace KonyvtarWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<KonyvtarDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("KonyvtarDbKapcsolat"));
            });

            builder.Services.AddCors(options =>
            {
                //options.AddDefaultPolicy(builder =>
                //{
                //    builder.WithOrigins("http://localhost:5500")
                //           .WithMethods("POST", "DELETE")
                //           .WithHeaders("Content Type");
                //});

                options.AddPolicy("FrontendPolicy", builder =>
                    builder.WithOrigins(
                                "https://localhost:5500",
                                "https://sajatoldal.hu"
                                )
                        .WithMethods("GET", "POST")
                        .AllowAnyHeader()
                );

                options.AddPolicy("BackendPolicy", builder =>
                    builder.WithOrigins(
                                "https://localhost:5500",
                                "https://sajatoldal.hu"
                                )
                        .WithMethods("GET", "POST", "PUT", "DELETE")
                        .AllowAnyHeader()

                );
            });

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("FrontendPolicy");


            app.MapControllers();

            app.Run();
        }
    }
}
