using InfoHub.CustomEventArgs;
using Microsoft.Extensions.Logging;

namespace InfoHub
{
    public delegate void ClickedEventArgs(object sender, InContentViewClickedEventArgs e);
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
                    fonts.AddFont("FAbrands.otf", "FAbrands");
                    fonts.AddFont("FAregular.otf", "FAregular");
                    fonts.AddFont("FAsolid900.otf", "FAsolid");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}