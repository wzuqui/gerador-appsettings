using gerador_appsettings.Workers;
using GeradorAppSettings.Configurations;
using Microsoft.Extensions.Options;
using NLog.Web;

var xBuilder = WebApplication.CreateBuilder(args);
{
    xBuilder.Logging.ClearProviders();
    xBuilder.Logging.AddConsole();
    xBuilder.Host.UseNLog();

    // configurations
    xBuilder.Services.Configure<AppSettings>(xBuilder.Configuration);
    xBuilder.Services.AddSingleton(p => p.GetRequiredService<IOptions<AppSettings>>().Value);

    // contexts

    // automapper

    // repositories

    // services
    xBuilder.Services.AddMemoryCache();

    // http clients

    // workers
    xBuilder.Services.AddHostedService<MainWorker>();

    // swagger
    xBuilder.Services.AddEndpointsApiExplorer();
    xBuilder.Services.AddSwaggerGen();

    // controllers
    xBuilder.Services.AddControllers();
}

var xApp = xBuilder.Build();
{
    // swagger
    xApp.UseSwagger();
    xApp.UseSwaggerUI();

    // controllers
    xApp.MapControllers();
    xApp.MapGet("/", () => "Ok");
}

xApp.Run();