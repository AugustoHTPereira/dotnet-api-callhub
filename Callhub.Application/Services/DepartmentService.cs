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
    public class DepartmentService : IDepartmentService
    {
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            this._departmentRepository = departmentRepository;
            this._mapper = mapper;
        }

        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public async Task<IEnumerable<DepartmentViewModel>> SelectAllByCompanyAsync(Guid CompanyId)
        {
            return this._mapper.Map<IEnumerable<DepartmentViewModel>>(await this._departmentRepository.SelectAllByCompanyAsync(CompanyId));
        }

        public async Task<DepartmentViewModel> Select(Guid Id)
        {
            return this._mapper.Map<DepartmentViewModel>(await this._departmentRepository.SelectAsync(Id));
        }

        public Task<IEnumerable<DepartmentViewModel>> Select()
        {
            throw new NotImplementedException();
        }
    }
}
