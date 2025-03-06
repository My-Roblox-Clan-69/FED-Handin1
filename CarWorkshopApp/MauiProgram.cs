using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using CarWorkshopApp.Data;
using CarWorkshopApp.ViewModels;
using CarWorkshopApp.Services;
using CarWorkshopApp.Views;
using System.IO;

namespace CarWorkshopApp;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .UseMauiCommunityToolkit();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // ✅ SQLite Database Path
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "carworkshop.db");
        Console.WriteLine($"📌 Database Path: {dbPath}");

        // ✅ Register SQLite Database
        builder.Services.AddSingleton(new CarWorkshopDbContext(dbPath));

        // Register Services
        builder.Services.AddSingleton<BookingService>();

        // Register ViewModels
        builder.Services.AddTransient<BookingViewModel>(); 
        builder.Services.AddTransient<OverviewViewModel>(); 

        // Register Views
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<BookingPage>();
        builder.Services.AddTransient<OverviewPage>();

        return builder.Build();
    }
}
