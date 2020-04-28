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
        public UserService(IUserRepository userRepository,
            IMapper mapper,
            IHashService hashService,
            IMailService mailService,
            IRoleRepository roleRepository
        )
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
            this._hashService = hashService;
            this._mailService = mailService;
            this._roleRepository = roleRepository;
        }

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;
        private readonly IMailService _mailService;
        private readonly IRoleRepository _roleRepository;

        public async Task<IEnumerable<UserViewModel>> SelectAsync() => this._mapper.Map<IEnumerable<UserViewModel>>(await this._userRepository.SelectAsync());

        public async Task<UserViewModel> CreateAsync(RegisterViewModel Data)
        {
            Data.Password = this._hashService.Encode(Data.Password);
            await this._userRepository.InsertAsync(this._mapper.Map<User>(Data));
            UserViewModel user = this._mapper.Map<UserViewModel>(await this._userRepository.SelectIdentityAsync());
            await this._mailService.SendMessageAsync("Welcome to Callhub " + Data.Name + "!", Data.Email);
            return user;
        }

        public async Task UpdateAsync(UserViewModel Data)
        {
            User user = this._mapper.Map<User>(Data);
            await this._userRepository.UpdateAsync(user);

            this._mailService.SetSubject("Data updated.");
            await this._mailService.SendMessageAsync("Successfully data updated!", Data.Email);
        }

        public async Task<UserViewModel> SelectAsync(Guid Id)
        {
            UserViewModel user = this._mapper.Map<UserViewModel>(await this._userRepository.SelectAsync(Id));
            if (user.RoleId != Guid.Empty)
            {
                user.Role = this._mapper.Map<RoleViewModel>(await this._roleRepository.SelectAsync(user.RoleId));
            }
            else
            {
                user.Role = new RoleViewModel
                {
                    Name = "INTERN"
                };
            }

            return user;
        }

        public async Task<UserViewModel> SelectByCredentialsAsync(string Email, string Password)
        {
            UserViewModel user = this._mapper.Map<UserViewModel>(await this._userRepository.SelectByCredentialsAsync(Email, this._hashService.Encode(Password)));
            if (user != null)
                if (user.RoleId != Guid.Empty)
                    user.Role = this._mapper.Map<RoleViewModel>(await this._roleRepository.SelectAsync(user.RoleId));
                else user.Role = new RoleViewModel { Name = "INTERN" };

            return user;
        }
    }
}
