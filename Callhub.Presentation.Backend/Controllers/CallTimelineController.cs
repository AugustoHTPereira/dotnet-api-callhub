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
    public class CallTimelineController : ControllerBase
    {
        public CallTimelineController(ICallTimelineService callTimelineService)
        {
            this._callTimelineService = callTimelineService;
        }

        private readonly ICallTimelineService _callTimelineService;


        [HttpPost("")]
        [Authorize]
        public async Task<IActionResult> Store([FromBody]CallTimelineViewModel callTimeline)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Guid UserId = Guid.Parse(this.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                callTimeline.UserId = UserId;
                await this._callTimelineService.InsertAsync(callTimeline);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex);
            }

            return Ok();
        }
    }
}