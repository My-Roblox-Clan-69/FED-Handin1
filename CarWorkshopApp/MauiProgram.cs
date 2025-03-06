using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CarWorkshopApp.Data;


namespace CarWorkshopApp;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
#if DEBUG
        builder.Logging.AddDebug();
#endif

string dbPath = Path.Combine(FileSystem.AppDataDirectory, "carworkshop.db");
builder.Services.AddDbContext<CarWorkshopDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

        return builder.Build();
    }
}