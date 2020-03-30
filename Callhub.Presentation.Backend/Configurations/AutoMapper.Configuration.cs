using AutoMapper;
using Callhub.Infra.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callhub.Presentation.Backend.Configurations
{
    public static class AutoMapper
    {
        public static void HandleAutoMapper(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException();

            MapperConfiguration configuration = new MapperConfiguration(x =>
            {
                x.AllowNullCollections = true;
                x.AddProfile(new HandleAutoMapper());
            });

            IMapper mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
