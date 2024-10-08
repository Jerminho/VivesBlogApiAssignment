using Microsoft.AspNetCore.Mvc;
using VivesBlog.Dto.Requests;
using VivesBlog.Dto.Results;
using VivesBlog.Services;

namespace VivesBlog.Api.Controllers
{
    // [Route("[api\controller]")] ??
    [Route("[controller]")]
    [ApiController]
    public class PeopleController(PersonService personService) : ControllerBase
    {
        private readonly PersonService _personService = personService;

        //Find (more) GET api/people
        [HttpGet]
        public async Task<ActionResult<IList<PersonResult>>> Find()
        {
            var people = await _personService.Find();
            return Ok(people);
        }

        //Get (one) GET
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _personService.Get(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Errors);
            }
            return Ok(result.Data);
        }

        //Create POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonRequest request)
        {
            var result = await _personService.Create(request);
            return Ok(result);
        }

        //Update PUT
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PersonRequest request)
        {
            var result = await _personService.Update(id, request);
            return Ok(result);
        }

        //Delete DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _personService.Delete(id);
            return Ok(result);
        }
    }
}
