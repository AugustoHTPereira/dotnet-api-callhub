using AutoMapper;
using Callhub.Application.Interfaces;
using Callhub.Application.ViewModels;
using Callhub.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Callhub.Application.Services
{
    public class CompanyService : ICompanyService
    {
        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            this._companyRepository = companyRepository;
            this._mapper = mapper;
        }

        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public async Task<IEnumerable<CompanyViewModel>> Select()
        {
            return this._mapper.Map<IEnumerable<CompanyViewModel>>(await this._companyRepository.SelectAsync());
        }
    }
}
