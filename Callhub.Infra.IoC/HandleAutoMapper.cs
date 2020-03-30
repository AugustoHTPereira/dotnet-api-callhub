using AutoMapper;
using Callhub.Application.ViewModels;
using Callhub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Callhub.Infra.IoC
{
    public class HandleAutoMapper : Profile
    {
        public HandleAutoMapper()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();

            CreateMap<RegisterViewModel, User>();
            CreateMap<User, RegisterViewModel>();

            CreateMap<CompanyViewModel, Company>();
            CreateMap<Company, CompanyViewModel>();

            CreateMap<DepartmentViewModel, Department>();
            CreateMap<Department, DepartmentViewModel>();
        }
    }
}
