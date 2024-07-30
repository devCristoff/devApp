using Microsoft.Extensions.DependencyInjection;
using Vimenpaq.Core.Application.Interfaces.Services;
using Vimenpaq.Core.Application.Services;

namespace Domex.Core.Application
{
    //Design pattern --> Decorator - Extensions methods
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region "Service"
            services.AddTransient<IOrderService, OrderService>();
            #endregion
        }
    }
}
