using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Callhub.Application.Interfaces;
using Callhub.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Callhub.Presentation.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CallsController : ControllerBase
    {
        public CallsController(ICallService callService)
        {
            this._callService = callService;
        }

        private readonly ICallService _callService;


        [HttpPost("")]
        [Authorize]
        public async Task<IActionResult> Store([FromBody]CallViewModel call)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                call.UserId = Guid.Parse(this.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                await this._callService.InsertAsync(call);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex);
            }

            return Ok();
        }

        [HttpGet("{CallId}")]
        [Authorize]
        public async Task<IActionResult> Details(string CallId)
        {
            if (!Guid.TryParse(CallId, out Guid Id)) return BadRequest();

            return Ok(await this._callService.SelectAsync(Id));
        }
    }
}