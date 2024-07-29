using Microsoft.EntityFrameworkCore;
using BillLibrary.Repos;
using BillLibrary.Modal;
using Microsoft.Extensions.Configuration;
namespace BillWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

             var configuration=builder.Configuration;
            builder.Services.AddDbContext<BillDBContext>(options =>
            {
                //options.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; database=BillDB; integrated security=true");
                options.UseSqlServer(configuration.GetConnectionString("connectionString"));

            });
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IItemRepo,ItemRepo>();
            builder.Services.AddScoped<IBillRepo, BillRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();
            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.Run();
        }
    }
}
