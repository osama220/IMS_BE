using Microsoft.EntityFrameworkCore;
using IMS_BE.Extensions;
using IMS.DataAccess;
using IMS.Application;

var builder = WebApplication.CreateBuilder(args);
SetupServices(builder);
SetupAppPipeline(builder);


static void SetupServices(WebApplicationBuilder builder)
{
    // Add services to the container.
    var services = builder.Services;
    services.AddHttpContextAccessor();
    services.AddControllers();
    services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));    
    services.AddSignalR();
    //services.AddApplication();
    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    services.AddSwaggerExtension(builder.Configuration);
    services.AddApiVersioningExtension();
    services.AddHealthChecks();
    services.AddCors();
    services.AddResponseCaching();
}


// <summary>
// Setup App Pipeline for the Web Application Builder
// </summary>
static void SetupAppPipeline(WebApplicationBuilder builder)
{
    var app = builder.Build();
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
    }
    app.UseCors(options => options
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowAnyOrigin());
    app.UseHttpsRedirection();
    // Use the response caching
    app.UseResponseCaching();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseSwaggerExtension();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
    app.Run();
}