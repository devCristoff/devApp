using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Fedex.Core.Application
{
    //Design pattern --> Decorator - Extensions methods
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
