using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CarWorkshopApp.Data;
using CarWorkshopApp.ViewModels;
using CarWorkshopApp.Services;
using CarWorkshopApp.Views;

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

        // Database Path
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "carworkshop.db");
        builder.Services.AddDbContext<CarWorkshopDbContext>(options =>
            options.UseSqlite($"Data Source={dbPath}"));

        // Register Services
        builder.Services.AddSingleton<BookingService>();

        // Register ViewModels
        builder.Services.AddTransient<BookingViewModel>();  // ViewModel for BookingPage
		builder.Services.AddTransient<OverviewViewModel>();

        // Register Views
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<BookingPage>();
		builder.Services.AddTransient<OverviewPage>();


        return builder.Build();
    }
}
