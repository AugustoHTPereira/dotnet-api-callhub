using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Callhub.Presentation.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MediaController : ControllerBase
    {
        public MediaController(IHostingEnvironment environment, IConfiguration configuration)
        {
            this._environment = environment;

            this._baseSource = Path.Combine(this._environment.WebRootPath, "calls");
            if (!Directory.Exists(this._baseSource))
                Directory.CreateDirectory(this._baseSource);
        }

        private readonly IHostingEnvironment _environment;
        private readonly string _baseSource;

        [HttpPost("call/{id}")]
        [Authorize]
        public async Task<IActionResult> PostFile(string id, IList<IFormFile> files)
        {
            long size = files.Sum(x => x.Length);

            if (size == 0)
                return BadRequest(new
                {
                    message = "no file content",
                    size,
                });

            if (!Directory.Exists(Path.Combine(this._baseSource, id)))
                Directory.CreateDirectory(Path.Combine(this._baseSource, id));

            IList<string> savedFilePaths = new List<string>();

            foreach (IFormFile file in files)
            {
                if (file.Length <= 0) continue;


                string filePath = Path.Combine(this._baseSource, id, DateTime.Now.Ticks + "-" + file.FileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }

                savedFilePaths.Add(filePath.Split("wwwroot/")[1]);
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
