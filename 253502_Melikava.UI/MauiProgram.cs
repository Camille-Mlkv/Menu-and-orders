using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using _253502_Melikava.ApplicationLayer;
using _253502_Melikava.Persistence;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using _253502_Melikava.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using _253502_Melikava.Domain.Abstractions;
using _253502_Melikava.Persistence.Repository;

namespace _253502_Melikava.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string settingsStream = "_253502_Melikava.UI.appsettings.json";

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream);

            var connStr = builder.Configuration.GetConnectionString("SqliteConnection");
            string dataDirectory = FileSystem.Current.AppDataDirectory + "/";
            connStr = String.Format(connStr, dataDirectory);
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connStr)
                .Options;

            builder.Services
                   .AddApplication()
                   .AddPersistence(options)
                   .RegisterPages()
                   .RegisterViewModels();

            DbInitializer
                .Initialize(builder.Services.BuildServiceProvider())
                .Wait();

            builder.UseMauiApp<App>().UseMauiCommunityToolkit();

            

            

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}