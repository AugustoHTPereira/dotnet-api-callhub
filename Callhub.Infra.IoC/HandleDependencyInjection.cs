using Callhub.Application.Interfaces;
using Callhub.Application.Services;
using Callhub.Domain.Interfaces.Repository;
using Callhub.Infra.Data.Connection;
using Callhub.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Callhub.Infra.IoC
{
    public class HandleDependencyInjection
    {
        public HandleDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IConnection, ConnectionSqlServer>();


            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<ICallRepository, CallRespository>();
            services.AddTransient<ICategoryRespository, CategoryRepository>();


            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<ICallService, CallService>();
            services.AddTransient<ICategoryService, CategoryService>();
            

            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IHashService, HashService>();
        }
    }
}
