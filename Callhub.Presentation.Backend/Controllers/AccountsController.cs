using Callhub.Application.Interfaces;
using Callhub.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Callhub.Presentation.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        public AccountsController(
            IUserService userService,
            ITokenService tokenService
        )
        {
            this._userService = userService;
            this._tokenService = tokenService;
        }

        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        [HttpPost("")]
        public async Task<IActionResult> Store([FromBody]RegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UserViewModel user = await this._userService.CreateAsync(register);
                return Ok(this._tokenService.Generate(user));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            UserViewModel userViewModel = await this._userService.SelectByCredentialsAsync(loginViewModel.Email, loginViewModel.Password);
            if (userViewModel == null) return Unauthorized();

            return Ok(this._tokenService.Generate(userViewModel));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            if (!this.User.Identity.IsAuthenticated)
                return Forbid();

            return Ok(this.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier).Value);
        }
    }
}
