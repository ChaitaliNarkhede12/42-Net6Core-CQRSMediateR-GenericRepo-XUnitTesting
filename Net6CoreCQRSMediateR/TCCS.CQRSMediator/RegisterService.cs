
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TCCS.CQRSMediator
{
    public static class RegisterService
    {
        public static void ConfigureCQRSCommands(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
