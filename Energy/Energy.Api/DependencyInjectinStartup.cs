using Energy.DataAccess.Repositories.Implementations;
using Energy.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Energy.Services.Implementations;
using Energy.Services.Interfaces;

namespace Energy.Api
{
    public static class DependencyInjectionStartup
    {
        public static void Inject(IServiceCollection services)
        {
           
            services.AddTransient<IElectricityService, ElectricityService>();
            
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        }
    }
}