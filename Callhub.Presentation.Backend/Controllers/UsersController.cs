using Callhub.Application.Interfaces;
using Callhub.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Callhub.Presentation.Backend.Controllers
{
  [ApiController]
  [Route("[controller]")]
  [Authorize]
  public class UsersController : ControllerBase
  {
    public UsersController(
        IUserService userService,
        ICallService callService
    )
    {
      this._userService = userService;
      this._callService = callService;
    }

    private readonly IUserService _userService;
    private readonly ICallService _callService;

    [HttpPost("department/{DepartmentId}")]
    public async Task<IActionResult> UpdateDepartment([FromRoute]string DepartmentId, [FromServices]IDepartmentService departmentService)
    {
      DepartmentViewModel department = await departmentService.Select(Guid.Parse(DepartmentId));
      if (department == null)
        return NotFound(new
        {
          message = "No department found"
        });

      UserViewModel userViewModel = await this._userService.SelectAsync(Guid.Parse(this.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value));
      userViewModel.Department = department;
      await this._userService.UpdateAsync(userViewModel);

      return Ok();
    }

    [HttpGet("calls")]
    public async Task<IActionResult> GetCalls()
    {
      try
      {
        Guid UserId = Guid.Parse(this.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
        return Ok(await this._callService.SelectAllByOwner(UserId));
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }
  }
}
