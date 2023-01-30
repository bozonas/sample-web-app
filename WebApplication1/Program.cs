using WebApplication1.Controllers;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // ConvfigureServices
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IRepository, Repository>();

            // ConvfigureServices

            //var console = iocContainer.GetService<IConsole>();
            //var applicate = iocContainer.GetService<IApplication>();
            //var service = iocContainer.GetService<IService>();
            //var controlelr = new CarsController(console);
            //var result = controlelr.GetAll();

            var app = builder.Build();


            // Configure
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();
            // Configure



            app.Run();
        }
    }
}