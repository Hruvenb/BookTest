using System.Collections.Generic;
using Book_Test.Model;
using Book_Test.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Book_Test.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _repository.GetAllBooks();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _repository.GetBookById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            if (book == null)
                return BadRequest();

            _repository.CreateBook(book);

            return Ok(book);
        }

        //// PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Book book)
        {
            if (book == null)
                return BadRequest();

            if (_repository.GetBookById(id) == null)
                return NotFound();

            book.Id = id;
            _repository.UpdateBook(book);

            return Ok(book);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.GetBookById(id) == null)
                return NotFound();

            _repository.DeleteBook(id);

            return Ok();
        }
    }
}
