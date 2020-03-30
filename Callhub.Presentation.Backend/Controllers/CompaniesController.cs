using Callhub.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callhub.Presentation.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        public CompaniesController(ICompanyService companyService)
        {
            this._companyService = companyService;
        }

        private readonly ICompanyService _companyService;

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await this._companyService.Select());
        }

        [HttpGet("{Id}/departments")]
        public async Task<IActionResult> Departments(string Id, [FromServices]IDepartmentService departmentService)
        {
            return Ok(await departmentService.SelectAllByCompanyAsync(Guid.Parse(Id)));
        }
    }
}
