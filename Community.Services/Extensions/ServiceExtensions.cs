using Microsoft.Extensions.DependencyInjection;

namespace Community.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IExportService, ExportService>();
            services.AddScoped<ITreeService, TreeService>();
        }
    }
}
