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
    public class UserService : IUserService
    {
        public UserService(IUserRepository userRepository, IMapper mapper, IHashService hashService)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
            this._hashService = hashService;
        }

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;

        public async Task<IEnumerable<UserViewModel>> SelectAsync() => this._mapper.Map<IEnumerable<UserViewModel>>(await this._userRepository.SelectAsync());

        public async Task<UserViewModel> CreateAsync(RegisterViewModel Data)
        {
            Data.Password = this._hashService.Encode(Data.Password);
            await this._userRepository.InsertAsync(this._mapper.Map<User>(Data));
            return this._mapper.Map<UserViewModel>(await this._userRepository.SelectIdentityAsync());
        }
    }
}
