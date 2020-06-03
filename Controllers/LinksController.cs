using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShareEverything.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinksController : ControllerBase
    {
        [HttpGet("tags")]
        public async Task<IActionResult> GetTags()
        {
            var db = "/Users/wahid/projects/shareEverything/code/ShareEverything/DB/Links.tsv";
            var lines = await System.IO.File.ReadAllLinesAsync(db);

            var tags = new HashSet<string>();
            foreach (var line in lines)
            {
                var tagsInLine = line.Split('\t').Skip(1);
                foreach (var t in tagsInLine)
                    tags.Add(t);
            }
            tags.Remove(""); //there can be empty columns
            return this.Ok(tags);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SharedLink link)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var path = "/Users/wahid/projects/shareEverything/code/ShareEverything/DB/Links.tsv";
            var file = new System.IO.FileStream(path, FileMode.Append);
            var line = link.ToString();
            await file.WriteAsync(System.Text.Encoding.UTF8.GetBytes(line));
            await file.FlushAsync();
            await file.DisposeAsync();

            return this.Ok();
        }
    }

    public class SharedLink
    {
        public string Url { get; set; }

        public ICollection<string> Tags { get; set; } = new Collection<string>();

        public override string ToString()
        {
            return $"{this.Url}\t{string.Join('\t', this.Tags)}"; 
        }
    }
}