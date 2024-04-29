using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data;
using System.Reflection;

namespace SchoolAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
            ));

            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IFinalRepository, FinalRepository>();

            // Konfiguracija AutoMappera za automatsko mapiranje entiteta i DTO modela
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
