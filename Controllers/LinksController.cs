using Microsoft.AspNetCore.Mvc;
using ShareEverything.DTOs;
using ShareEverything.Models;
using ShareEverything.Persistence;
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
        private readonly SharedLinksContext context;
        public LinksController(SharedLinksContext context) 
            => this.context = context ?? throw new ArgumentNullException(nameof(context));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SharedLinkDto linkDto)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var tags = linkDto.Tags.Select(t => new Tag { Name = t});
            var link = new SharedLink { Url = linkDto.Url };
            await this.context.AddRangeAsync(tags.Select(t => new SharedLinkTag { SharedLink = link, Tag = t }));
            await this.context.Tags.AddRangeAsync(tags);
            await this.context.SharedLinks.AddAsync(link);
            await this.context.SaveChangesAsync();

            return this.Ok();
        }
    }
}

// var path = "/Users/wahid/projects/shareEverything/code/ShareEverything/DB/Links.tsv";
// var file = new System.IO.FileStream(path, FileMode.Append);
// var line = link.ToString();
// await file.WriteAsync(System.Text.Encoding.UTF8.GetBytes(line + Environment.NewLine));
// await file.FlushAsync();
// await file.DisposeAsync();