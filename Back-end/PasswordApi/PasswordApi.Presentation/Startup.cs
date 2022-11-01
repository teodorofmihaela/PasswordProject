using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PasswordApi.Core.Interfaces;
using PasswordApi.Core.Services;
using PasswordApi.Infrastructure.Data;
using PasswordApi.Infrastructure.Repositories;
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
        services.AddControllers().ConfigureApiBehaviorOptions(options => { }).AddNewtonsoftJson(t =>
        {
            t.SerializerSettings.MaxDepth = 126;
            t.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });

        ResolveDependencies(services);
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
    {
        app.UseCors(x =>
            x.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        
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
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ITemporaryPasswordRepository, TemporaryPasswordRepository>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<ITemporaryPasswordService, TemporaryPasswordService>();
        
        
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