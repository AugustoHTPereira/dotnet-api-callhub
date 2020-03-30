using Callhub.Infra.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callhub.Presentation.Backend.Configurations
{
    public static class DependencyInjection
    {
        public static void HandleDependencyInjection(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException("Services null");

            new HandleDependencyInjection(services);
        }
    }
}
