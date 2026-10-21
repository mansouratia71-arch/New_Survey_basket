
using Survey_Basket.midlewire;
using Serilog;

namespace Survey_Basket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
         

            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen();

            builder.Services.addservises(builder.Configuration);

            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(builder.Configuration)
               .WriteTo.Console() 
               .CreateLogger();



            builder.Host.UseSerilog();

            var app = builder.Build();

            


            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

           app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseExceptionHandler();

            app.Run();
        }
    }
}
