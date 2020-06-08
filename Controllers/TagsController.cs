using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShareEverything.Persistence;

namespace ShareEverything.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly SharedLinksContext context;

        public TagsController(SharedLinksContext context)
        {
            this.context = context;
        }

        [HttpGet]
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

            tags.Remove(""); //remove empty tag
            return this.Ok(tags);
        }
    }
}