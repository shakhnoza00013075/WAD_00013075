using DAL_00013075.Models_00013075;
using DAL_00013075.Repositories_00013075;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_00013075.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book> repository;

        public BookController(IRepository<Book> repository)
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
            var book = await repository.Get(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            await repository.Create(book);
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            await repository.Edit(id, book);
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
