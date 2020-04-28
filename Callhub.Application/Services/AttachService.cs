using AutoMapper;
using Callhub.Application.Interfaces;
using Callhub.Application.ViewModels;
using Callhub.Domain.Interfaces.Repository;
using Callhub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Callhub.Application.Services
{
    public class AttachService : IAttachService
    {
        public AttachService(IAttachRepository attachRepository, IMapper mapper)
        {
            this._attachRepository = attachRepository;
            this._mapper = mapper;
        }

        private readonly IAttachRepository _attachRepository;
        private readonly IMapper _mapper;

        public async Task InsertAsync(AttachViewModel viewModel)
        {
            await this._attachRepository.InsertAsync(this._mapper.Map<Attach>(viewModel));
        }
    }
}
