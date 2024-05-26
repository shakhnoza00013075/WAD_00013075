using DAL_00013075.Models_00013075;
using DAL_00013075.Repositories_00013075;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_00013075.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IRepository<Author> repository;

        public AuthorController(IRepository<Author> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        { 
            return Ok(await repository.GetAll());
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var author = await repository.Get(id);
            if(author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
            await repository.Create(author);
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Edit(int id, Author author)
        {
            await repository.Edit(id, author);
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            await repository.Delete(id);
            return Ok();
        }
    }
}
