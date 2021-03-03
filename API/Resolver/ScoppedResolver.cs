using Core.Infrastructure.ErrorHandler;
using Core.Interfaces;
using CarsbyServices.Services;
using Microsoft.Extensions.DependencyInjection;
using CarsbyServices.Interfaces;

namespace CarsbyAPI.Resolver
{
    internal static class ScoppedResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISearchRepository, SearchService>();
            services.AddScoped<IAddNewVehicleRepository, AddNewVehicleService>();
            services.AddScoped<IFeatureProductsRepository, FeatureProductsService>();
            services.AddScoped<IImageServiceRepository, ImageServiceService>();
            services.AddScoped<IWhistListRepository, WhistListService>();
            services.AddScoped<IErrorHandler, ErrorHandler>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAddVehicleRepository, AddVehicleService>();

        }
    }
}
