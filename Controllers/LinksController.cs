using Microsoft.AspNetCore.Mvc;
using ShareEverything.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShareEverything.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinksController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SharedLink link)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var path = "/Users/wahid/projects/shareEverything/code/ShareEverything/DB/Links.tsv";
            var file = new System.IO.FileStream(path, FileMode.Append);
            var line = link.ToString();
            await file.WriteAsync(System.Text.Encoding.UTF8.GetBytes(line + Environment.NewLine));
            await file.FlushAsync();
            await file.DisposeAsync();

            return this.Ok();
        }
    }
}