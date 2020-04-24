using Callhub.Application.Interfaces;
using Callhub.Application.ViewModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Callhub.Application.Services
{
    public class TokenService : ITokenService
    {
        public TokenService(IOptions<TokenSettings> settings)
        {
            this._settings = settings.Value;
        }

        private readonly TokenSettings _settings;

        public TokenViewModel Generate(UserViewModel Model)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(this._settings.PrivateKey);

            TokenViewModel tokenViewModel = new TokenViewModel();
            tokenViewModel.CreatedAt = DateTime.Now;
            tokenViewModel.ExpiressAt = tokenViewModel.CreatedAt.AddDays(this._settings.ExpirationDays);
            tokenViewModel.User = Model;

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Model.Email),
                    new Claim(ClaimTypes.NameIdentifier, Model.Id.ToString()),
                    new Claim(ClaimTypes.Role, Model.Role != null ? Model.Role.Name : "INTERN"),
                }),
                Expires = tokenViewModel.ExpiressAt,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(securityTokenDescriptor);
            tokenViewModel.AccessToken = tokenHandler.WriteToken(token);

            return tokenViewModel;
        }
    }
}
