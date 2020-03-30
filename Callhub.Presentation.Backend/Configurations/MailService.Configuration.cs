using Callhub.Application.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callhub.Presentation.Backend.Configurations
{
    public static class MailService
    {
        public static void HandleMailService(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null || configuration == null) throw new ArgumentNullException();

            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        }
    }
}
