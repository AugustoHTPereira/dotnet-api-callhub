using Callhub.Application.Interfaces;
using Callhub.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Callhub.Presentation.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttachController : ControllerBase
    {
        public AttachController(
            IHostingEnvironment environment,
            IAttachService attachService,
            ICallService callService
        )
        {
            this._environment = environment;
            this._attachService = attachService;
            this._callService = callService;

            this._baseSource = Path.Combine(this._environment.WebRootPath, "calls");
            if (!Directory.Exists(this._baseSource))
                Directory.CreateDirectory(this._baseSource);
        }

        private readonly IHostingEnvironment _environment;
        private readonly IAttachService _attachService;
        private readonly ICallService _callService;
        private readonly string _baseSource;

        [HttpPost("call/{id}")]
        [Authorize]
        public async Task<IActionResult> PostFile(string id, IList<IFormFile> files)
        {
            CallViewModel call = await this._callService.SelectAsync(Guid.Parse(id));
            if (call == null)
                return NotFound();

            if (call.UserId != Guid.Parse(this.User.Claims.FirstOrDefault(x => x.Type == "Id").Value))
                return Forbid();

            long size = files.Sum(x => x.Length);

            if (size == 0)
                return BadRequest(new
                {
                    message = "no file content",
                    size,
                });

            IList<string> savedFilePaths = new List<string>();

            foreach (IFormFile file in files)
            {
                if (file.Length <= 0) continue;


                string filePath = Path.Combine(this._baseSource, DateTime.Now.Ticks + "-" + file.FileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }

                AttachViewModel attach = new AttachViewModel();
                attach.Size = file.Length;
                attach.Name = file.FileName;
                attach.RelativePath = filePath.Split("wwwroot")[1];
                attach.TableName = "Calls";
                attach.TableRegisterId = Guid.Parse(id);
                attach.FullPath = filePath;

                await this._attachService.InsertAsync(attach);

                savedFilePaths.Add(attach.RelativePath);
            }

            return Ok(new
            {
                size,
                saved_count = files.Count,
                saved_files = savedFilePaths
            });
        }
    }
}
