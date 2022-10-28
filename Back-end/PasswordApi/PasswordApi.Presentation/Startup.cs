using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using PasswordApi.Infrastructure.Data;
using ServerVersion = Pomelo.EntityFrameworkCore.MySql.Storage;

namespace PasswordApi.Presentation;

public class Startup
{
    private IConfiguration Configuration { get; }
    
    public Startup(IConfiguration config)
    {
        Configuration = config;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().ConfigureApiBehaviorOptions(options => { });

        ResolveDependencies(services);
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            endpoints.MapDefaultControllerRoute();
        });
    }
    
    private void ResolveDependencies(IServiceCollection services)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

        services.AddDbContext<DataContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                    serverVersion,b => b.MigrationsAssembly("PasswordApi.Presentation"))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );
    }
}