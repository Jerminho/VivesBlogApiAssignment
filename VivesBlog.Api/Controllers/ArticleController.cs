using Microsoft.AspNetCore.Mvc;
using VivesBlog.Dto.Requests;
using VivesBlog.Services;

namespace VivesBlog.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticleController(ArticleService articleService) : ControllerBase
    {
        private readonly ArticleService _articleService = articleService ;

        //Find (more) GET
        [HttpGet]
        public async Task<IActionResult> Find()
        {
            var organizations = await _articleService.Find();
            return Ok(organizations);
        }

        //Get (one) GET
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _articleService.Get(id);
            return Ok(result);
        }

        //Create POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArticleRequest request)
        {
            var result = await _articleService.Create(request);
            return Ok(result);
        }

        //Update PUT
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ArticleRequest request)
        {
            var result = await _articleService.Update(id, request);
            return Ok(result);
        }

        //Delete DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _articleService.Delete(id);
            return Ok(result);
        }
    }
}
