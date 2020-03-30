using Callhub.Application.Interfaces;
using Callhub.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callhub.Presentation.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        private readonly IUserService _userService;

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<UserViewModel> users = await this._userService.SelectAsync();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
